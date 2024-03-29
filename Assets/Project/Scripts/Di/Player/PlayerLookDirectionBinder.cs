﻿using Invaders.Entities;
using Invaders.Movement;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerLookDirectionBinder : MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            BindLook();
        }

        private void BindLook()
        {
            Container
               .Bind<IPlayerLookService>()
               .FromInstance(_player)
               .AsCached()
               .NonLazy();
        }
    }
}