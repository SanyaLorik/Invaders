using Invaders.InputSystem;
using Invaders.Ui;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        [Header("Store")]
        [SerializeField] private InventorySlot[] _inventorySlots;

        [Header("Specially")]
        [SerializeField] private SpeciallyInventorySlot<IItem> _used;
        [SerializeField] private InventorySlot _grenade;
        [SerializeField] private InventorySlot _thrown;
        [SerializeField] private InventorySlot _deleted;

        private IInventoryService _inventoryService;

        [Inject]
        private void Construct(IInventoryService inventoryService) =>
            _inventoryService = inventoryService;

        private void OnEnable() =>
            _inventoryService.OnInventoryOpenedOrClosed += OnShowOrClose;

        private void OnDisable() =>
            _inventoryService.OnInventoryOpenedOrClosed -= OnShowOrClose;

        public void Add(IItem item)
        {
            ItemCell cell = _inventorySlots.FirstOrDefault(i => i.IsEmpty == true)?.ItemCell;
            if (cell == null)
                return;

            item.Hide();
            cell.Occopy(item);
        }
        
        public void Remove(IItem item)
        {
            ItemCell cell = _inventorySlots.Where(i => i.IsEmpty == false)?.FirstOrDefault(i => i.ItemCell.Item == item)?.ItemCell;
            if (cell == null)
                return;

            IItem free = cell.Item;
            cell.Free();
            if (item is MonoBehaviour monoBehaviour)
                Destroy(monoBehaviour.gameObject);
        }

        private void OnShowOrClose() =>
            _panel.SetActive(!_panel.activeSelf);
    }
}