using Invaders.Gear;
using Invaders.Ui;
using System;
using UnityEngine;

namespace Invaders.Battle
{
    public class PlayerWeaponUiObserver : MonoBehaviour, IWeaponHavingObserver, IWeaponAmmoObserver, IWeaponReloadingObserver
    {
        [SerializeField] private UsedInventorySlot _usedSlot;

        public event Action<string> OnHad = delegate { };
        public event Action OnNoHad = delegate { };
        public event Action<int, int> OnNumberOfBulletChanged = delegate { };
        public event Action OnOutOfAmmo = delegate { };
        public event Action OnReloadingStarted = delegate { };
        public event Action OnReloadingStopped = delegate { };

        private IWeaponFire _weapon;

        private void OnEnable()
        {
            _usedSlot.OnTaken += OnTake;
            _usedSlot.OnDeprived += OnDrop;
        }

        public float ReloadedTime { get; private set; }

        private void OnTake(IItem item)
        {
            if (item is IWeaponFire weapon == false)
                return;

            _weapon = weapon;
            OnHad.Invoke(_weapon.Name);
            SetInformationAboutWeaponFire();
        }

        private void OnDrop()
        {
            if (_usedSlot.ItemCell.Item is IWeaponFire weapon == false)
                return;

            _weapon = weapon;

            ClearInformationAboutWeaponFire();
            OnNoHad.Invoke();
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