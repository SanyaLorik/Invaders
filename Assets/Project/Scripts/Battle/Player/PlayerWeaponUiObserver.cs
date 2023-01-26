using Invaders.Gear;
using System;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(ICarrierObserver<IThingPortable<IWeapon>>))]
    public class PlayerWeaponUiObserver : MonoBehaviour, IWeaponAmmoObserver, IWeaponReloadingObserver
    {
        public event Action<int, int> OnNumberOfBulletChanged = delegate { };
        public event Action OnStartReloaded = delegate { };
        public event Action OnStopReloaded = delegate { };

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

        private void OnDrop() =>
            ClearInformationAboutWeaponFire();

        private void SetInformationAboutWeaponFire()
        {
            _weapon.OnChangeNubmerOfBullet((remaining, total) => OnNumberOfBulletChanged.Invoke(remaining, total));
            _weapon.OnReloadingStarted(() => OnStartReloaded.Invoke());
            _weapon.OnReloadingStopped(() => OnStopReloaded.Invoke());

            ReloadedTime = _weapon.ReloaingTime;
        }

        private void ClearInformationAboutWeaponFire()
        {
            _weapon.OnChangeNubmerOfBullet(null);
            _weapon.OnReloadingStarted(null);
            _weapon.OnReloadingStopped(null);

            ReloadedTime = 0;

            OnNumberOfBulletChanged.Invoke(0, 0);
        }
    }
}