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
        [SerializeField] private Transform _droppedPoint;

        private ICarrier<IThingPortable<IWeapon>> _carier;
        private IPlayerLookService _look;
        private IClickedService _clicked;
        private IHolderService _holder;
        private IWeaponReloaderObserverService _reloader;

        private IPlayerShooter _shooter;
        private IPlayerThingCarier _picker;

        [Inject]
        private void Construct(IHolderService holder, IClickedService clicked, IPlayerThingCarier picker, IWeaponReloaderObserverService reloader)
        {
            _clicked = clicked;
            _holder = holder;
            _picker = picker;
            _reloader = reloader;
        }

        private void Awake()
        {
            _look = GetComponent<IPlayerLookService>();
            _carier = GetComponent<ICarrier<IThingPortable<IWeapon>>>();
        }

        private void OnEnable() =>
            _picker.OnTakenOrDropped += OnChangeDropOrTake;

        private void OnDisable()
        {
            _picker.OnTakenOrDropped -= OnChangeDropOrTake;
            _shooter?.Disable();
        }

        private void Arm(IWeapon weapon)
        {
            _shooter = weapon as IWeaponRapidFire == null ?
                new PlayerShooterTapping(_look, weapon as IWeaponTappingFire, _reloader, _clicked) :
                new PlayerShooterHolding(_look, weapon as IWeaponRapidFire, _reloader, _holder);

            _shooter.Enable();
        }

        private void OnChangeDropOrTake()
        {
            if (_carier.HasPortable == true)
            {
                Drop();
                return;
            }

            if (_carier.IsNearbyPortable == true)
                Take();
        }

        private void Drop()
        {
            _carier.Drop(_droppedPoint.position);
            _shooter?.Disable();
        }

        private void Take()
        {
            IWeapon weapon = _carier.Take().Thing;
            Arm(weapon);
        }
    }
}