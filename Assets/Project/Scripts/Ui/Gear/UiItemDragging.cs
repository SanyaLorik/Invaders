using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Invaders.Ui
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class UiItemDragging : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private RectTransform _rect;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            _rect.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

        }
    }
}