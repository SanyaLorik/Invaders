using TMPro;
using UnityEngine;

namespace Invaders.Ui
{
    public class ItemCell
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private TextMeshProUGUI _name; 
        [SerializeField] private TextMeshProUGUI _count; 
    }
}