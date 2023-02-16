using Invaders.InputSystem;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerInputSystemBinder : MonoInstaller
    {
        [SerializeField] private PlayerInputSystem _inputSystem;
        
        public override void InstallBindings()
        { 
            BindMovement();
            BindLook();
            BindClick();
            BindHold();
            BindUse();
            BindDropWeapon();
            BindReloadWeapon();
            BindReloadScene();
            BindConfirm();
            BindSneaking();
        }

        private void BindMovement()
        {
            Container
                .Bind<IMovementService>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindLook()
        {
            Container
                .Bind<IPointPositionOnScreenService>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindClick()
        {
            Container
                .Bind<IClickedService>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }
        
        private void BindHold()
        {
            Container
                .Bind<IHolderService>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindUse()
        {
            Container
               .Bind<IUsedService>()
               .FromInstance(_inputSystem)
               .AsCached()
               .NonLazy();
        }

        private void BindDropWeapon()
        {
            Container
                .Bind<IPlayerThingCarier>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindReloadWeapon()
        {
            Container
                .Bind<IWeaponReloaderObserverService>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindReloadScene()
        {
            Container
                .Bind<ISceneReloaderObserverService>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindConfirm()
        {
            Container
                .Bind<IPlayerConfirmation>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindSneaking()
        {
            Container
               .Bind<ISneakingService>()
               .FromInstance(_inputSystem)
               .AsCached()
               .NonLazy();
        }
    }
}