using Invaders.Additional;
using UnityEngine;

namespace Invaders.Gear
{
    public struct CarrierContainer<T>
        where T : IPortable
    {
        public CarrierContainer(T potable, Transform position)
        {
            Portable = potable;
            Position = position;
        }

        public T Portable { get; }

        public Transform Position { get; }
    }
}