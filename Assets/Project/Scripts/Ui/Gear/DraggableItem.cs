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

        private RectTransform _item;

        private Transform _returned;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter == null)
                return;

            if (eventData.pointerEnter.TryGetComponent(out InventorySlot inventorySlot) == false)
                return;

            _returned = inventorySlot.transform;
            _item = inventorySlot.Item;
            _item.SetParent(_draggableArea);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_item != null)
                _item.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_item == null)
                return;

            if (eventData.pointerEnter == null)
                return;

            if (eventData.pointerEnter.TryGetComponent(out InventorySlot inventorySlot) == false)
            {
                _item.SetParent(_returned);
                _item.localPosition = Vector3.zero;
                return;
            }

            _item.SetParent(inventorySlot.transform);
            _item.transform.localPosition = Vector3.zero;

            inventorySlot.Item.SetParent(_returned);
            inventorySlot.Item.localPosition = Vector3.zero;
            _item = null;
        }
    }
}