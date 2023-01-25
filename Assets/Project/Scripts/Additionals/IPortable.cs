using UnityEngine;

namespace Invaders.Additionals
{
    public interface IPortable
    {
        void Take();

        void Throw(Vector3 direction);
    }
}