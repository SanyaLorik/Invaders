using UnityEngine;

namespace Invaders.Gear
{
    public interface IInventoryItem : IItem
    {
        Sprite Icon { get; }

        uint Count { get; }

        void Show();

        void Hide();
    }
}