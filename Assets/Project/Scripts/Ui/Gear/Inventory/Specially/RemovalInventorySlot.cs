using Invaders.Gear;

namespace Invaders.Ui
{
    public class RemovalInventorySlot : SpeciallyInventorySlot<IItem>
    {
        public override bool CanSetItem(IItem item) =>
             IsEmpty == true;
    }
}