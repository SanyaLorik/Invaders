using UnityEngine;

namespace Invaders.Battle
{
    public abstract class WeaponRapidFire : Weapon, IWeaponRapidFire
    {
        [SerializeField] private Missile _missile;
        [SerializeField] private Transform _muzzle;
        [SerializeField] [Min(0)] private float _speed;
        [SerializeField] [Min(0)] protected int damage;

        [field: SerializeField] public float ShootedDelay { get; private set; }
        
        public override void Shoot(Vector3 direction)
        {
            IMissile missile = Spawn(_missile, _muzzle);
            missile.Damage = damage;
            
            LaunchMissile(missile, direction, _speed);
        }
        
        protected abstract IMissile Spawn(Missile missile, Transform muzzle);

        protected abstract void LaunchMissile(IMissile missile, Vector3 direction, float speed);
    }
}