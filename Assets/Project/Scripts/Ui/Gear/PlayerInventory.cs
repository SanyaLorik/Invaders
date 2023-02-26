using Invaders.Gear;
using System.Linq;
using UnityEngine;

namespace Invaders.Ui
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _inventorySlots;

        public void Add(IInventoryItem item)
        {
            ItemCell cell = _inventorySlots.FirstOrDefault(i => i.IsEmpty == true).ItemCell;
            if (cell == null)
                return;

            item.Hide();
            cell.Occopy(item);
        }
        /*
        public IInventoryItem Take()
        {

        }
        */
        public void Remove(int hashCode)
        {
            ItemCell cell = _inventorySlots.Where(i => i.IsEmpty == false).FirstOrDefault(i => i.ItemCell.GetHashCode() == hashCode).ItemCell;
            if (cell == null)
                return;

            IInventoryItem item = cell.Free();
            if (item is MonoBehaviour monoBehaviour)
                Destroy(monoBehaviour.gameObject);
        }    
    }
}