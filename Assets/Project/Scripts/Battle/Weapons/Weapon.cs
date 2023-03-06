using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [field: SerializeField] public string Name { get; private set; }

        [field: SerializeField] public Sprite Icon { get; private set; }

        public abstract string Description { get; }

        public bool CanTaken { get; protected set; } = true;

        public abstract void PickUp();

        public abstract void Drop();

        public abstract void Shoot(Vector3 direction);

        public abstract void Show();

        public abstract void Hide();
    }
}