using UnityEngine;

namespace Invaders.Battle
{
    public class Handgun : Weapon
    {
        private readonly float _handgunSpeed;

        public Handgun(Transform muzzle, IMissile missile, int damage, float handgunSpeed) : base(muzzle, missile, damage) =>
            _handgunSpeed = handgunSpeed;

        public override void Shoot(Vector3 direction)
        {
            
        }
    }
}