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
        private IClickedService _clicked;
        private IHolderService _holder;
        private IReloaderObserverService _reloader;

        private IPlayerShooter _shooter;
        private IPlayerWeaponBearer _bearer;

        [Inject]
        private void Construct(IHolderService holderService, IClickedService clicked, IPlayerWeaponBearer bearer, IReloaderObserverService reloader)
        {
            _clicked = clicked;
            _holder = holderService;
            _bearer = bearer;
            _reloader = reloader;
        }

        private void Awake() =>
            _look = GetComponent<IPlayerLookService>();

        private void OnEnable() =>
            _bearer.OnDroppedWeapon += DropWeapon;

        private void OnDisable()
        {
            _bearer.OnDroppedWeapon -= DropWeapon;
            _shooter?.Disable();
        }

        protected sealed override void Take(IWeapon weapon)
        {
            _shooter = weapon as IWeaponRapidFire == null ?
                new PlayerShooterTapping(_look, weapon as IWeaponTappingFire, _reloader, _clicked) : 
                new PlayerShooterHolding(_look, weapon as IWeaponRapidFire, _reloader, _holder);

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