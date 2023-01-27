﻿using Invaders.Gear;
using System;

namespace Invaders.Battle
{
    public class PlayerWeaponUiObserver : IWeaponHavingObserver, IWeaponAmmoObserver, IWeaponReloadingObserver
    {
        public event Action OnDropped = delegate { };
        public event Action<int, int> OnNumberOfBulletChanged = delegate { };
        public event Action OnOutOfAmmo = delegate { };
        public event Action OnReloadingStarted = delegate { };
        public event Action OnReloadingStopped = delegate { };

        private ICarrierObserver<IThingPortable<IWeapon>> _carrier;
        private IWeaponFire _weapon;

        public PlayerWeaponUiObserver(ICarrierObserver<IThingPortable<IWeapon>> carrier)
        {
            _carrier = carrier;

            _carrier.OnTaken += OnTaken;
            _carrier.OnDropped += OnDrop;
        }

        ~PlayerWeaponUiObserver()
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