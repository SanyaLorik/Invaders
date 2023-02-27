using UnityEngine;

namespace Invaders.Ui
{
    public class InventorySlot : MonoBehaviour
    {
        [field: SerializeField] public ItemCell ItemCell { get; private set; }

        public RectTransform Draggable => ItemCell.Draggable;

        public bool IsEmpty => ItemCell.IsEmpty;

        public virtual void SetItem(ItemCell itemCell)
        {
            ItemCell = itemCell;
            
            Draggable.SetParent(transform);
            Draggable.localPosition = Vector3.zero;
        }

        public virtual ItemCell TakeItem()
        {
            ItemCell item = ItemCell;
            ItemCell = null;

            return item;
        }

        public void SwapPlace(InventorySlot inventorySlot)
        {
            ItemCell taken = inventorySlot.TakeItem();
            ItemCell given = TakeItem();

            SetItem(taken);
            inventorySlot.SetItem(given);
        }
    }
}