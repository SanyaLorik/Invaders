using UnityEngine;

namespace Invaders.Battle
{
    public class Handgun : Weapon
    {
        protected override IMissile Spawn(Missile missile, Transform muzzle) =>
            Instantiate(missile, muzzle.transform.position, muzzle.rotation);

        protected override void Shoot(IMissile missile, Vector3 direction, float speed) =>
            missile.Rigidbody.velocity = direction * speed;
    }
}