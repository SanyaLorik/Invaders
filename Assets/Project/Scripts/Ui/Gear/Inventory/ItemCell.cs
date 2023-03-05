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

        [field: SerializeField] public RectTransform Draggable { get; private set; }

        public IItem Item { get; private set; }

        public bool IsEmpty => Item == null/*false*/;

        public void Occopy(IItem item)
        {
            Item = item;

            _icon.sprite = item.Icon;
            _name.text = item.Name;
        }

        public void Free() 
        {
            Item = null;

            _icon.sprite = null;
            _name.text = string.Empty;
        }
    }
}