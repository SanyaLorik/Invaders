using Invaders.Gear;

namespace Invaders.Ui
{
    public class ThrownInventorySlot : SpeciallyInventorySlot<IItem>
    {
        public override bool CanSetItem(IItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}