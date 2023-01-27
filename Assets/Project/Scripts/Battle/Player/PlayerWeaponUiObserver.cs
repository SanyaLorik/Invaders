using Invaders.Gear;
using System;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(ICarrierObserver<IThingPortable<IWeapon>>))]
    public class PlayerWeaponUiObserver : MonoBehaviour, IWeaponHavingObserver, IWeaponAmmoObserver, IWeaponReloadingObserver
    {
        public event Action OnDropped = delegate { };
        public event Action<int, int> OnNumberOfBulletChanged = delegate { };
        public event Action OnOutOfAmmo = delegate { };
        public event Action OnReloadingStarted = delegate { };
        public event Action OnReloadingStopped = delegate { };

        private ICarrierObserver<IThingPortable<IWeapon>> _carrier;
        private IWeaponFire _weapon;

        private void Awake() =>
            _carrier = GetComponent<ICarrierObserver<IThingPortable<IWeapon>>>();

        private void OnEnable()
        {
            _carrier.OnTaken += OnTaken;
            _carrier.OnDropped += OnDrop;
        }

        private void OnDisable()
        {
            _carrier.OnTaken -= OnTaken;
            _carrier.OnDropped -= OnDrop;
        }

        public float ReloadedTime { get; private set; }

        private void OnTaken(IThingPortable<IWeapon> weaponFire)
        {
            _weapon = weaponFire.Thing as IWeaponFire;
            SetInformationAboutWeaponFire();
        }

        private void OnDrop()
        {
            ClearInformationAboutWeaponFire();
            OnDropped.Invoke();
            OnReloadingStopped.Invoke();
        }

        private void SetInformationAboutWeaponFire()
        {
            _weapon.OnChangeNubmerOfBullet((remaining, total) => OnNumberOfBulletChanged.Invoke(remaining, total));
            _weapon.OnOutOfAmmo(OnOutOfAmmo.Invoke);
            _weapon.OnStartReloading(OnReloadingStarted.Invoke);
            _weapon.OnStopReloading(OnReloadingStopped.Invoke);

            ReloadedTime = _weapon.ReloaingTime;
        }

        private void ClearInformationAboutWeaponFire()
        {
            _weapon.OnChangeNubmerOfBullet(null);
            _weapon.OnOutOfAmmo(null);
            _weapon.OnStartReloading(null);
            _weapon.OnStopReloading(null);

            ReloadedTime = 0;
        }
    }
}