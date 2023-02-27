using Invaders.Gear;
using System;

namespace Invaders.Ui
{
    public abstract class SpeciallyInventorySlot : InventorySlot
    {
        public abstract bool CanSetItem(IInventoryItem item);
    }

    public abstract class SpeciallyInventorySlot<T> : InventorySlot
        where T : IItem
    {
        public event Action<T> OnTaken;

        public override void SetItem(ItemCell itemCell)
        {
            base.SetItem(itemCell);

            itemCell.Item.Show();
            OnTaken.Invoke((T)itemCell.Item);
        }

        public override ItemCell TakeItem()
        {
            ItemCell.Item.Hide();
            return base.TakeItem();
        }

        public abstract bool CanSetItem(IInventoryItem item);
    }
}