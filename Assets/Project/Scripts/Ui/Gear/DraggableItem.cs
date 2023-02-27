using DG.Tweening;
using System;
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
        [SerializeField][Range(0f, 1f)] private float _returnedDuration;

        private InventorySlot _inventorySlot;
        private Transform _returnedToTakenPosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter == null || eventData.pointerEnter.TryGetComponent(out InventorySlot inventorySlot) == false)
                return;

            if (inventorySlot.IsEmpty == true)
                return;

            _returnedToTakenPosition = eventData.pointerEnter.transform;
            _inventorySlot = inventorySlot;
            _inventorySlot.Draggable.SetParent(_draggableArea);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_inventorySlot == null)
                return;

            _inventorySlot.Draggable.anchoredPosition += eventData.delta / _canvas.scaleFactor;
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

            if (inventorySlot is SpeciallyInventorySlot specially)
            {
                if (specially.CanSetItem(_inventorySlot.ItemCell.Item) == true)
                    specially.SetItem(_inventorySlot.TakeItem());
                else
                    ReturnToTakenPosition();
            }
            else
            {
                if (inventorySlot.IsEmpty == true)
                    inventorySlot.SetItem(_inventorySlot.TakeItem());
                else
                    _inventorySlot.SwapPlace(inventorySlot);
            }

            Clear();
        }

        private void ReturnToTakenPosition()
        {
            _inventorySlot.Draggable
                .DOMove(_returnedToTakenPosition.transform.position, _returnedDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => 
                { 
                    _inventorySlot.Draggable.SetParent(_returnedToTakenPosition);
                    Clear();
                });
        }

        private void Clear() =>
            _inventorySlot = null;
    }
}