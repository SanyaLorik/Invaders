using Invaders.Gear;

namespace Invaders.Ui
{
    public class UsedInventorySlot : SpeciallyInventorySlot<IItem>
    {
        public override bool CanSetItem(IItem item) =>
            IsEmpty == true && item != null;

        public override void SetItem(ItemCell itemCell)
        {
            base.SetItem(itemCell);
            itemCell.Item?.Show();
        }

        public override ItemCell TakeItem()
        {
            ItemCell.Item?.Hide();
            return base.TakeItem();
        }
    }
}