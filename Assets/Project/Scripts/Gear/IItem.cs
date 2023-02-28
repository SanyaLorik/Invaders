using UnityEngine;

namespace Invaders.Gear
{
    public interface IItem
    {
        Sprite Icon { get; }

        string Name { get; }

        string Description { get; }

        void PickUp();

        void Drop();

        void Use();

        void Show();

        void Hide();
    }
}