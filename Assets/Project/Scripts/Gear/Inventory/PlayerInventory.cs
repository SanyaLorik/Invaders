using Invaders.InputSystem;
using Invaders.Ui;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Ui")]
        [SerializeField] private GameObject _panel;

        [Header("Store")]
        [SerializeField] private InventorySlot[] _inventorySlots;
        [SerializeField] private UsedInventorySlot _usedSlot;
        [SerializeField] private ThrownInventorySlot _thrownSlot;

        [Header("Receiver Point")]
        [SerializeField] private ItemReceiver _receiver;

        private IInventoryService _inventoryService;

        [Inject]
        private void Construct(IInventoryService inventoryService) =>
            _inventoryService = inventoryService;

        private void OnEnable()
        {
            _thrownSlot.OnTaken += OnDrop;
            _inventoryService.OnInventoryOpenedOrClosed += OnShowOrClose;
        }

        private void OnDisable()
        {
            _thrownSlot.OnTaken -= OnDrop;
            _inventoryService.OnInventoryOpenedOrClosed -= OnShowOrClose;
        }

        public void Add(IItem item)
        {
            if (_usedSlot.IsEmpty == true)
            {
                item?.PickUp();
                _usedSlot.ItemCell.Occopy(item);
                _usedSlot.SetItem(_usedSlot.ItemCell);
                _receiver.Fix(item);
                return;
            }

            ItemCell cell = _inventorySlots.FirstOrDefault(i => i.IsEmpty == true)?.ItemCell;
            if (cell == null)
                return;

            item?.Hide();
            item?.PickUp();
            cell.Occopy(item);

            _receiver.Fix(item);
        }

        /*
        public void Deprive(IItem item)
        {
            ItemCell cell = _inventorySlots.FirstOrDefault(i => i.IsEmpty == true)?.ItemCell;
            if (cell == null)
                return;

            cell.Free();
            item.Show();
            item.Drop();
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
        */

        private void OnDrop(IItem item)
        {
            _receiver.Unfix(item);
            item.Drop();
        }

        private void OnShowOrClose() =>
            _panel.SetActive(!_panel.activeSelf);
    }
}