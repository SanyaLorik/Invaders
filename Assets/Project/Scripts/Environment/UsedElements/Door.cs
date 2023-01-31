using DG.Tweening;

namespace Invaders.Environment.UsedElements
{
    public class Door : ManagedElement
    {
        protected override Tween Open()
        {
            print("Open");
            return null;
        }

        protected override Tween Close()
        {
            print("Close");
            return null;
        }
    }
}