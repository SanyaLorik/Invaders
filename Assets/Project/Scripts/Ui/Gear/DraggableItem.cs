using UnityEngine;
using UnityEngine.EventSystems;

namespace Invaders.Ui
{
    public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [Header("Size")]
        [SerializeField] private Canvas _canvas;

        [Header("Items")]
        [SerializeField] private Transform _draggableArea;

        private InventorySlot _inventorySlot;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter == null || eventData.pointerEnter.TryGetComponent(out InventorySlot inventorySlot) == false)
                return;

            _inventorySlot = inventorySlot;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_inventorySlot != null)
                _inventorySlot.Item.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_inventorySlot == null)
                return;

            if (eventData.pointerEnter == null || eventData.pointerEnter.TryGetComponent(out InventorySlot inventorySlot) == false)
            {
                ReturnToTakenPosition();
                return;
            }

            _inventorySlot.SwapPlace(inventorySlot);
        }

        private void ReturnToTakenPosition()
        {

        }
    }
}