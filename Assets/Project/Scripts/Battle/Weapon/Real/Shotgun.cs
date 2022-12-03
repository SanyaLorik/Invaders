using UnityEngine;

namespace Invaders.Battle
{
    public class Shotgun : WeaponTappingFire
    {
        [SerializeField] [Min(0)] private int _numberOfBullet;
        [SerializeField] [Min(0)] private int _angleBetweenBullet;

        public override void Shoot(Vector3 direction)
        {
            int from = -(_numberOfBullet / 2);
            int to = _numberOfBullet + from;

            for (int i = from; i < to; i++)
            {
                Vector3 newDirection = RotateDirectionUsedAngle(direction, i);
                base.Shoot(newDirection);
            }

            ReduceBullet();
        }

        protected override IMissile Spawn(Missile missile, Transform muzzle) =>
           Instantiate(missile, muzzle.transform.position, muzzle.rotation);

        protected override void LaunchMissile(IMissile missile, Vector3 direction, float speed) =>
            missile.Rigidbody.velocity = direction * speed;

        private Vector3 RotateDirectionUsedAngle(Vector3 direction, int ratioAngle) => 
            Quaternion.Euler(0, _angleBetweenBullet * ratioAngle, 0) * direction;
    }
}