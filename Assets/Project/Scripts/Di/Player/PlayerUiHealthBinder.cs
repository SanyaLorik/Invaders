using Invaders.Additionals;
using Invaders.Pysiol;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerUiHealthBinder: MonoInstaller
    {
        [Header("Health")]
        [SerializeField][Min(0)] private int _initialHealth;
        [SerializeField][Min(0)] private int _maximumHealth;

        private IPhysiology<int> _health;

        public override void InstallBindings()
        {
            _health = new Health(_initialHealth, _maximumHealth);

            BindHealth();
            BindHealthObserver();
        }

        private void BindHealth()
        {
            Container
               .Bind<IPhysiology<int>>()
               .FromInstance(_health)
               .AsCached()
               .NonLazy();
        }

        private void BindHealthObserver()
        {
            Container
               .Bind<IValueObserver<int, int>>()
               .FromInstance(_health)
               .AsCached()
               .NonLazy();
        }
    }
}