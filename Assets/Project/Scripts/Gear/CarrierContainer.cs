using UnityEngine;

namespace Invaders.Gear
{
    public struct CarrierContainer
    {
        public CarrierContainer(IItem potable, Transform position)
        {
            Portable = potable;
            Position = position;
        }

        public IItem Portable { get; }

        public Transform Position { get; }
    }
}