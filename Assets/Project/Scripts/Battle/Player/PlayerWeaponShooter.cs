using Invaders.Gear;
using Invaders.InputSystem;
using Invaders.Movement;
using UnityEngine;
using Zenject;

namespace Invaders.Battle
{
    [RequireComponent(typeof(IPlayerLookService))]
    public class PlayerWeaponShooter : MonoBehaviour
    {
        private IClickedService _clicked;
        private IHolderService _holder;
        private IWeaponReloaderService _reloader;

        private IPlayerLookService _look;
        private IPlayerInteractableHandler _shooter;

        //private IWeapon _current;

        [Inject]
        private void Construct(IHolderService holder, IClickedService clicked, IWeaponReloaderService reloader)
        {
            _clicked = clicked;
            _holder = holder;
            _reloader = reloader;
        }

        private void Awake() =>
            _look = GetComponent<IPlayerLookService>();

        /*
        private void OnEnable() =>
            _picker.OnTakenOrDropped += OnChangeDropOrTake;

        private void OnDisable()
        {
            _picker.OnTakenOrDropped -= OnChangeDropOrTake;
            _shooter?.Disable();
        }
        */
        public float ReloadedTime { get; private set; }

        private void Arm(IWeapon weapon)
        {
            /*
             * This method developed only for firearms, but is a temporary solution.
             * In the future, it will be developed for handguns.
             */

            if (weapon is IWeaponFire weaponFire == false)
                return;

            _shooter = weaponFire as IWeaponRapidFire == null ?
                new PlayerShooterTapping(_look, weapon as IWeaponTappingFire, _reloader, _clicked) :
                new PlayerShooterHolding(_look, weapon as IWeaponRapidFire, _reloader, _holder);

            _shooter.Enable();
        }

        /*
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

            _current.Drop();
            _current = null;
        }

        private void Take()
        {
            IWeapon weapon = _carier.Take().Thing;
            Arm(weapon);

            _current = weapon;
            _current.PickUp();
        }
        */
    }
}