using UnityEngine;

namespace Invaders.Ui
{
    public class InventorySlot : MonoBehaviour
    {
        [field: SerializeField] public RectTransform Item { get; set; }

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