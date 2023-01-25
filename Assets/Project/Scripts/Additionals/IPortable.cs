using UnityEngine;

namespace Invaders.Additional
{
    public interface IPortable
    {
        void Take();

        void Throw(Vector3 direction);
    }
}