using UnityEngine;

namespace Invaders.Ui
{
    public class InventorySlot : MonoBehaviour
    {
        [field: SerializeField] public RectTransform Item { get; set; }

        public bool IsEmpty => Item == null;

        public void SetItem(RectTransform rect)
        {
            Item = rect;

            Item.SetParent(transform);
            Item.localPosition = Vector3.zero;
        }

        public RectTransform TakeItem()
        {
            RectTransform item = Item;
            Item = null;

            return item;
        }

        public void SwapPlace(InventorySlot inventorySlot)
        {
            Item.SetParent(inventorySlot.transform);
            Item.localPosition = Vector3.zero;

            inventorySlot.Item.SetParent(transform);
            inventorySlot.Item.localPosition = Vector3.zero;

            (Item, inventorySlot.Item) = (inventorySlot.Item, Item);
        }
    }
}