using Invaders.Gear;

namespace Invaders.Ui
{
    public class ThrownInventorySlot : SpeciallyInventorySlot<IItem>
    {
        public override bool CanSetItem(IItem item) =>
            IsEmpty == true && item != null;

        public override void SetItem(ItemCell itemCell)
        {
            base.SetItem(itemCell);

            itemCell.Free();
        }
    }
}