using Invaders.Entities;
using Invaders.Movement;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerMovementBinder : MonoInstaller
    {
        [SerializeField] private Player _player;
        
        public override void InstallBindings() =>
            BindLook();

        private void BindLook()
        {
            Container
                .Bind<IPlayerLookService>()
                .To<Player>()
                .FromInstance(_player)
                .AsCached()
                .NonLazy();
        }
    }
}