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
            if (itemCell.Item is T t)
                OnTaken?.Invoke(t);
        }

        public override ItemCell TakeItem()
        {
            ItemCell.Item?.Hide();
            OnDeprived?.Invoke();

            return base.TakeItem();
        }
    }
}