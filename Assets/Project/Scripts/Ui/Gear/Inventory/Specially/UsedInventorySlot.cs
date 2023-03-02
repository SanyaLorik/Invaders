using Invaders.Gear;

namespace Invaders.Ui
{
    public class UsedInventorySlot : SpeciallyInventorySlot<IItem>
    {
        public override bool CanSetItem(IItem item) =>
            IsEmpty == true && item != null;
    }
}