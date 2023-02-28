﻿using Invaders.Ui;
using System.Linq;
using UnityEngine;

namespace Invaders.Gear
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Store")]
        [SerializeField] private InventorySlot[] _inventorySlots;

        [Header("Specially")]
        [SerializeField] private SpeciallyInventorySlot<IUsedItem> _used;
        [SerializeField] private InventorySlot _grenade;
        [SerializeField] private InventorySlot _thrown;
        [SerializeField] private InventorySlot _deleted;

        private void OnEnable()
        {
            
        }

        public void Add(IInventoryItem item)
        {
            ItemCell cell = _inventorySlots.FirstOrDefault(i => i.IsEmpty == true)?.ItemCell;
            if (cell == null)
                return;

            item.Hide();
            cell.Occopy(item);
        }
        
        public void Remove(IInventoryItem item)
        {
            ItemCell cell = _inventorySlots.Where(i => i.IsEmpty == false)?.FirstOrDefault(i => i.ItemCell.Item == item)?.ItemCell;
            if (cell == null)
                return;

            IInventoryItem free = cell.Item;
            cell.Free();
            if (item is MonoBehaviour monoBehaviour)
                Destroy(monoBehaviour.gameObject);
        }    
    }
}