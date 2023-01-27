using Invaders.Battle;
using Invaders.Gear;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerUiWraponBinder : MonoInstaller
    {
        [SerializeField] private WeaponCarrier _weaponCarrier;
        
        private PlayerWeaponUiObserver _information;

        public override void InstallBindings()
        {
            _information = new PlayerWeaponUiObserver(_weaponCarrier);

            BindAmmoInformation();
            BindReloadingInformation();
            BindHaving();
        }

        private void BindAmmoInformation()
        {
            Container
                .Bind<IWeaponAmmoObserver>()
                .FromInstance(_information)
                .AsCached()
                .NonLazy();
        }

        private void BindReloadingInformation()
        {
            Container
                .Bind<IWeaponReloadingObserver>()
                .FromInstance(_information)
                .AsCached()
                .NonLazy();
        }

        private void BindHaving()
        {
            Container
               .Bind<IWeaponHavingObserver>()
               .FromInstance(_information)
               .AsCached()
               .NonLazy();
        }
    }
}