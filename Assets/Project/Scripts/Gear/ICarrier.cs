using Invaders.Additionals;
using UnityEngine;

namespace Invaders.Gear
{
    public interface ICarrier
    {
        object Take();

        public bool IsNearbyPortable { get; }

        public bool HasPortable { get; }

        public void Drop(Vector3 direction);
    }

    public interface ICarrier<T>
        where T : IPortable
    {
        T Take();

        public bool IsNearbyPortable { get; }

        public bool HasPortable { get; }

        public void Drop(Vector3 direction);
    }
}