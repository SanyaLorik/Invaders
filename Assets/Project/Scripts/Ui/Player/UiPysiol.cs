using Invaders.Pysiol;
using UnityEngine.UI;

namespace Invaders.Ui
{
    public class UiPysiol : UiСalculator
    {
        private readonly IPhysiology<int> _physiology;
        private readonly Scrollbar _scrollbar;

        public UiPysiol(IPhysiology<int> physiology, Scrollbar scrollbar)
        {
            _physiology = physiology;
            _scrollbar = scrollbar;
        }
        
        public void Enable() => 
            _physiology.OnChanged += Change;

        public void Disable() =>
            _physiology.OnChanged -= Change;
        
        private void Change(int current)
        {
            
        }
    }
}