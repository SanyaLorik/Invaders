using Invaders.Movement;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerMovementBinder : MonoInstaller
    {
        [SerializeField] private PlayerSpawner _spawner;
        
        public override void InstallBindings() =>
            BindLook();

        private void BindLook()
        {
            Container
                .Bind<IPlayerLookService>()
                .FromInstance(_spawner.SpawnedPlayer)
                .AsCached()
                .NonLazy();
        }
    }
}