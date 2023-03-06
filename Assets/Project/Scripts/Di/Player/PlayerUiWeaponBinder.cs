using Invaders.Battle;
using Zenject;
using UnityEngine;

namespace Invaders.Di
{
    public class PlayerUiWeaponBinder : MonoInstaller
    {
        [SerializeField] private PlayerWeaponUiObserver _information;

        public override void InstallBindings()
        {
            BindAmmoInformationObserver();
            BindReloadingInformationObserver();
            BindHavingObserver();
        }

        private void BindAmmoInformationObserver()
        {
            Container
                .Bind<IWeaponAmmoObserver>()
                .FromInstance(_information)
                .AsCached()
                .NonLazy();
        }

        private void BindReloadingInformationObserver()
        {
            Container
                .Bind<IWeaponReloadingObserver>()
                .FromInstance(_information)
                .AsCached()
                .NonLazy();
        }

        private void BindHavingObserver()
        {
            Container
               .Bind<IWeaponHavingObserver>()
               .FromInstance(_information)
               .AsCached()
               .NonLazy();
        }
    }
}