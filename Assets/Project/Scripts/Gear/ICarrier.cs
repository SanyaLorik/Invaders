using Invaders.Additional;
using UnityEngine;

namespace Invaders.Gear
{
    public interface ICarrier<T>
        where T : IPortable
    {
        T Take();

        public bool IsNearbyPortable { get; }

        public bool HasPortable { get; }

        public void Drop(Vector3 direction);
    }
}