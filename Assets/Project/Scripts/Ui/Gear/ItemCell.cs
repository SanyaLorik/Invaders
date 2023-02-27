using Invaders.Gear;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Invaders.Ui
{
    [Serializable]
    public class ItemCell
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name; 
        [SerializeField] private TextMeshProUGUI _count;

        [field: SerializeField] public RectTransform Draggable { get; private set; }

        public IInventoryItem Item { get; private set; }

        public bool IsEmpty => /*Item == null*/false;

        public void Occopy(IInventoryItem item)
        {
            Item = item;

            _icon.sprite = item.Icon;
            _name.text = item.Name;
            _count.text = item.Count.ToString();
        }

        public IInventoryItem Free() 
        {
            _icon.sprite = null;
            _name.text = string.Empty;
            _count.text = string.Empty;

            return Item;
        }
    }
}