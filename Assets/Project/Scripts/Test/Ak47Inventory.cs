using Invaders.Battle;
using Invaders.Gear;
using UnityEngine;

namespace Invaders.Test
{
    public class Ak47Inventory : Ak47, IInventoryItem, IUsedItem
    {
        [field: SerializeField] public Sprite Icon {get; set;}

        public uint Count => 1;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}