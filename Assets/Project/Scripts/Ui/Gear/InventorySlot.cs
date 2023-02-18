using UnityEngine;

namespace Invaders.Ui
{
    public class InventorySlot : MonoBehaviour
    {
        [field: SerializeField] public RectTransform Item { get; set; }
    }
}