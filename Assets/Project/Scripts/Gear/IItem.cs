using UnityEngine;

namespace Invaders.Gear
{
    public interface IItem
    {
        Sprite Icon { get; }

        string Name { get; }

        string Description { get; }

        bool CanTaken { get; }

        void PickUp();

        void Drop();

        void Show();

        void Hide();
    }
}