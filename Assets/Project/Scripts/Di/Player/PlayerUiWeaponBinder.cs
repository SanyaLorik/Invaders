using Invaders.Battle;
using Zenject;

namespace Invaders.Di
{
    public class PlayerUiWeaponBinder : MonoInstaller
    {
        private PlayerWeaponUiObserver _information;

        public override void InstallBindings()
        {
            _information = new PlayerWeaponUiObserver();

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