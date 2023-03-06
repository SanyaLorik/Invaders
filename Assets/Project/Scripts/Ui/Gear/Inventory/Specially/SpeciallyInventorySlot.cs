using Invaders.Gear;
using System;

namespace Invaders.Ui
{
    public abstract class SpeciallyInventorySlot : InventorySlot
    {
        public abstract bool CanSetItem(IItem item);
    }

    public abstract class SpeciallyInventorySlot<T> : SpeciallyInventorySlot
        where T : IItem
    {
        public event Action<T> OnTaken;
        public event Action OnDeprived;

        public override void SetItem(ItemCell itemCell)
        {
            base.SetItem(itemCell);

            ItemCell.Item?.Show();
            if (itemCell.Item != null)
                OnTaken?.Invoke((T)itemCell.Item);
        }

        public override ItemCell TakeItem()
        {
            if (ItemCell.Item != null)
            {
                ItemCell.Item.Hide();
                OnDeprived?.Invoke();
            }

            return base.TakeItem(); 
        }
    }
}