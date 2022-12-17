using Invaders.Gear;
using Invaders.InputSystem;
using Invaders.Movement;
using UnityEngine;
using Zenject;

namespace Invaders.Battle
{
    [RequireComponent(typeof(IPlayerLookService))]
    [RequireComponent(typeof(ICarrier<IThingPortable<IWeapon>>))]
    public class PlayerWeaponShooter : MonoBehaviour
    {
        [SerializeField] private Transform _droppedWeaponPoint;

        private ICarrier<IThingPortable<IWeapon>> _carier;
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

        private void Awake()
        {
            _look = GetComponent<IPlayerLookService>();
            _carier = GetComponent<ICarrier<IThingPortable<IWeapon>>>();
        }

        private void OnEnable() =>
            _bearer.OnTakenOrDroppedWeapon += ChangeDropOrTakeWeapon;

        private void OnDisable()
        {
            _bearer.OnTakenOrDroppedWeapon -= ChangeDropOrTakeWeapon;
            _shooter?.Disable();
        }

        private void Arm(IWeapon weapon)
        {
            _shooter = weapon as IWeaponRapidFire == null ?
                new PlayerShooterTapping(_look, weapon as IWeaponTappingFire, _reloader, _clicked) :
                new PlayerShooterHolding(_look, weapon as IWeaponRapidFire, _reloader, _holder);

            _shooter.Enable();
        }

        private void ChangeDropOrTakeWeapon()
        {
            if (_carier.HasPortable == true)
            {
                _carier.Drop(_droppedWeaponPoint.position);
                _shooter?.Disable();

                return;
            }

            if (_carier.IsNearbyPortable == true)
            {
                IWeapon weapon = _carier.Take().Thing;
                Arm(weapon);
            }
        }
    }
}