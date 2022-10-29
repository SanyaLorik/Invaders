using System;
using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Weapon : IWeapon
    {
        private const int _minimum = 0;

        protected readonly Transform muzzle;
        protected readonly IMissile missile;
        protected readonly int damage;

        public Weapon(Transform muzzle, IMissile missile, int damage)
        {
            if (_minimum > damage)
                throw new Exception($"Minimum {_minimum} is greater than current {damage}.");

            this.muzzle = muzzle;
            this.missile = missile;
            this.damage = damage;
        }

        public abstract void Shoot(Vector3 direction);
    }
}