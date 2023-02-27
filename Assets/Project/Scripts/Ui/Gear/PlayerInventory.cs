using Invaders.Gear;
using System.Linq;
using UnityEngine;

namespace Invaders.Ui
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Store")]
        [SerializeField] private InventorySlot[] _inventorySlots;

        [Header("Specially")]
        [SerializeField] private InventorySlot _used;
        [SerializeField] private InventorySlot _grenade;
        [SerializeField] private InventorySlot _thrown;
        [SerializeField] private InventorySlot _deleted;

        public void Add(IInventoryItem item)
        {
            ItemCell cell = _inventorySlots.FirstOrDefault(i => i.IsEmpty == true).ItemCell;
            if (cell == null)
                return;

            item.Hide();
            cell.Occopy(item);
        }
        
        public void Remove(IInventoryItem item)
        {
            ItemCell cell = _inventorySlots.Where(i => i.IsEmpty == false).FirstOrDefault(i => i.ItemCell.Item == item).ItemCell;
            if (cell == null)
                return;

            IInventoryItem free = cell.Free();
            if (item is MonoBehaviour monoBehaviour)
                Destroy(monoBehaviour.gameObject);
        }    
    }
}