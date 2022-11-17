using UnityEngine;

namespace Invaders.Battle
{
    public class Handgun : WeaponTappingFire
    {
        protected override IMissile Spawn(Missile missile, Transform muzzle) =>
            Instantiate(missile, muzzle.transform.position, muzzle.rotation);

        protected override void LaunchMissile(IMissile missile, Vector3 direction, float speed) =>
            missile.Rigidbody.velocity = direction * speed;
    }
}