using UnityEngine;

namespace Invaders.Gear
{
    public interface IInventoryItem
    {
        Sprite Icon { get; }

        string Name { get; }

        uint Count { get; }

        void Show();

        void Hide();
    }
}