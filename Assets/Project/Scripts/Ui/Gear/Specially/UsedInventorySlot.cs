using Invaders.Gear;

namespace Invaders.Ui
{
    public class UsedInventorySlot : SpeciallyInventorySlot<IUsedItem>
    {
        public override bool CanSetItem(IInventoryItem item) =>
            IsEmpty == true && item as IUsedItem != null;
    }
}