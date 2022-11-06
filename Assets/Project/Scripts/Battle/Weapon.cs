using System;
using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Missile _missile;
        [SerializeField] private Transform _muzzle;
        [SerializeField] [Min(0)] private int _damage;
        [SerializeField] [Min(0)] private float _speed;

        public void Launch(Vector3 direction)
        {
            IMissile missile = Spawn(_missile, _muzzle);
            missile.Damage = _damage;
            
            Shoot(missile, direction, _speed);
        }
        
        protected abstract IMissile Spawn(Missile missile, Transform muzzle);

        protected abstract void Shoot(IMissile missile, Vector3 direction, float speed);
    }
}