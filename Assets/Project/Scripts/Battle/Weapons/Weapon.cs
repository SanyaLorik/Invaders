using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public abstract void PickUp();

        public abstract void Drop();

        public abstract void Shoot(Vector3 direction);
    }
}