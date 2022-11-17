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
            BindDropWeapon();
        }


        private void BindMovement()
        {
            Container
                .Bind<IMovementService>()
                .To<PlayerInputSystem>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindLook()
        {
            Container
                .Bind<IPointPositionOnScreenService>()
                .To<PlayerInputSystem>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindClick()
        {
            Container
                .Bind<IClickedService>()
                .To<PlayerInputSystem>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }
        
        private void BindHold()
        {
            Container
                .Bind<IHolderService>()
                .To<PlayerInputSystem>()
                .FromInstance(_inputSystem)
                .AsCached()
                .NonLazy();
        }

        private void BindDropWeapon()
        {
            Container
               .Bind<IPlayerWeaponBearer>()
               .To<PlayerInputSystem>()
               .FromInstance(_inputSystem)
               .AsCached()
               .NonLazy();
        }
    }
}