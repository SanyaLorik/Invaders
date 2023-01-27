using Invaders.Additionals;
using Invaders.Entities;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerUiHealthBinder: MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings() =>
            BindHealthObserver();

        private void BindHealthObserver()
        {
            Container
               .Bind<IValueObserver<int, int>>()
               .FromInstance(_player.Value)
               .AsCached()
               .NonLazy();
        }
    }
}