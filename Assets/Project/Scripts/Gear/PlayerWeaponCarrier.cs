using Invaders.Battle;
using Invaders.InputSystem;
using Invaders.Movement;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    [RequireComponent(typeof(IPlayerLookService))]
    public class PlayerWeaponCarrier : WeaponCarrier
    {
        [SerializeField] private Transform _droppedWeaponPoint;

        private IPlayerLookService _look;
        private IClickedService _clicked;
        private IHolderService _holder;
        private IWeaponReloaderObserverService _reloader;

        private IPlayerShooter _shooter;
        private IPlayerWeaponBearer _bearer;

        [Inject]
        private void Construct(IHolderService holderService, IClickedService clicked, IPlayerWeaponBearer bearer, IWeaponReloaderObserverService reloader)
        {
            _clicked = clicked;
            _holder = holderService;
            _bearer = bearer;
            _reloader = reloader;
        }

        private void Awake() =>
            _look = GetComponent<IPlayerLookService>();

        protected override void OnEnable()
        {
            base.OnEnable();

            _bearer.OnTakenOrDroppedWeapon += ChangeDropOrTakeWeapon;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _bearer.OnTakenOrDroppedWeapon -= ChangeDropOrTakeWeapon;
            _shooter?.Disable();
        }

        protected sealed override void Arm(IWeapon weapon)
        {
            _shooter = weapon as IWeaponRapidFire == null ?
                new PlayerShooterTapping(_look, weapon as IWeaponTappingFire, _reloader, _clicked) : 
                new PlayerShooterHolding(_look, weapon as IWeaponRapidFire, _reloader, _holder);

            _shooter.Enable();
        }

        private void ChangeDropOrTakeWeapon()
        {
            if (HasPortable == true)
            {
                Drop(_droppedWeaponPoint.position);
                _shooter?.Disable();

                return;
            }

            if (IsNearbyPortable == true)
                Take();
        }
    }
}