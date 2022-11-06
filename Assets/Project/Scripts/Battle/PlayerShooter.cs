using System;
using Invaders.InputSystem;
using Invaders.Movement;
using UnityEngine;

namespace Invaders.Battle
{
    public class PlayerShooter : IPlayerShooter
    {
        private readonly IPlayerLookService _look;
        private readonly IClickedService _clicked;
        private readonly IWeapon _weapon;

        public PlayerShooter(IPlayerLookService look, IClickedService clicked, IWeapon weapon)
        {
            _look = look;
            _clicked = clicked;
            _weapon = weapon;
        }

        public void Enable() =>
            _clicked.OnClicked += Shoot;

        public void Disable() =>
            _clicked.OnClicked -= Shoot;
        
        private void Shoot()
        {   
            _weapon.Launch(_look.Direction);
        }
    }
}