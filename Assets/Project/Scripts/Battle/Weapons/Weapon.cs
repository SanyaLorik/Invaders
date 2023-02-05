using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [field: SerializeField] public string Name { get; private set; }

        public abstract void PickUp();

        public abstract void Drop();

        public abstract void Shoot(Vector3 direction);
    }
}