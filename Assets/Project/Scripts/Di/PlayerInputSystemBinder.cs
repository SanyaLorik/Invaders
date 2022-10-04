using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerInputSystemBinder : MonoInstaller
    {
        [SerializeField] private PlayerInputSystem _inputSystem;
        
        public override void InstallBindings() =>
            Bind();

        private void Bind()
        {
            Container
                .Bind<IPlayerInputSystem>()
                .To<PlayerInputSystem>()
                .FromInstance(_inputSystem)
                .AsSingle()
                .NonLazy();
        }
    }
}