using Invaders.Additionals;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerUiHealthBinder: MonoInstaller
    {
        [SerializeField] private PlayerSpawner _spawner;

        public override void InstallBindings() =>
            BindHealthObserver();

        private void BindHealthObserver()
        {
            Container
               .Bind<IValueObserver<int, int>>()
               .FromInstance(_spawner.SpawnedPlayer.Value)
               .AsCached()
               .NonLazy();
        }
    }
}