using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [field: SerializeField] public string Name { get; private set; }

        public Sprite Icon => throw new System.NotImplementedException();

        public string Description => throw new System.NotImplementedException();

        public abstract void PickUp();

        public abstract void Drop();

        public abstract void Shoot(Vector3 direction);

        public void Use()
        {
            throw new System.NotImplementedException();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Hide()
        {
            throw new System.NotImplementedException();
        }
    }
}