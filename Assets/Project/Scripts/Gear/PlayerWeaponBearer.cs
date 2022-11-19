using Invaders.Battle;
using Invaders.InputSystem;
using Invaders.Movement;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    [RequireComponent(typeof(IPlayerLookService))]
    public class PlayerWeaponBearer : WeaponBearer
    {
        [SerializeField] private Transform _droppedWeaponPoint;

        private IPlayerLookService _look;
        private IPlayerShooter _shooter;
        private IClickedService _clicked;
        private IHolderService _holder;
        private IPlayerWeaponBearer _playerWeaponBearer;

        [Inject]
        private void Construct(IHolderService holderService, IClickedService clicked, IPlayerWeaponBearer playerWeaponBearer)
        {
            _clicked = clicked;
            _holder = holderService;
            _playerWeaponBearer = playerWeaponBearer;
        }

        private void Awake() =>
            _look = GetComponent<IPlayerLookService>();

        private void OnEnable() =>
            _playerWeaponBearer.OnDroppedWeapon += DropWeapon;

        private void OnDisable()
        {
            _playerWeaponBearer.OnDroppedWeapon -= DropWeapon;
            _shooter?.Disable();
        }

        protected sealed override void Take(IWeapon weapon)
        {
            _shooter = weapon as IWeaponRapidFire == null ?
                new PlayerShooterTapping(_look, _clicked, weapon as IWeaponTappingFire) : 
                new PlayerShooterHolding(_look, _holder, weapon as IWeaponRapidFire);

            _shooter.Enable();
        }

        protected override void DropWeapon()
        {
            if (HasWeapon == false)
                return;

            Transfer.Throw(_droppedWeaponPoint.position);
            _shooter?.Disable();

            base.DropWeapon();
        }
    }
}