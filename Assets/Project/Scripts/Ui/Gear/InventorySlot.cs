using UnityEngine;

namespace Invaders.Ui
{

    public class InventorySlot : MonoBehaviour
    {
        [field: SerializeField] public RectTransform Draggable { get; set; }

        public bool IsEmpty => Draggable == null;

        public void SetItem(RectTransform rect)
        {
            Draggable = rect;

            Draggable.SetParent(transform);
            Draggable.localPosition = Vector3.zero;
        }

        public RectTransform TakeItem()
        {
            RectTransform item = Draggable;
            Draggable = null;

            return item;
        }

        public void SwapPlace(InventorySlot inventorySlot)
        {
            RectTransform taken = inventorySlot.TakeItem();
            RectTransform given = TakeItem();

            SetItem(taken);
            inventorySlot.SetItem(given);
        }
    }
}