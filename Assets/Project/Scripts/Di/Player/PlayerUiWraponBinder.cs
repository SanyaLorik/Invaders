using Invaders.Battle;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerUiWraponBinder : MonoInstaller
    {
        [SerializeField] private PlayerWeaponUiObserver _information;

        public override void InstallBindings()
        {
            BindAmmoInformation();
            BindReloadingInformation();
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
    }
}