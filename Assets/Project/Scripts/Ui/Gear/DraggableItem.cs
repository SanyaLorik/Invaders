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
        private Transform _returnedToTakenPosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter == null || eventData.pointerEnter.TryGetComponent(out InventorySlot inventorySlot) == false)
                return;

            _returnedToTakenPosition = eventData.pointerEnter.transform;
            _inventorySlot = inventorySlot;
            _inventorySlot.Item.SetParent(_draggableArea);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_inventorySlot == null)
                return;

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
            _inventorySlot.Item.SetParent(_returnedToTakenPosition);
            _inventorySlot.Item.localPosition = Vector3.zero;
        }
    }
}