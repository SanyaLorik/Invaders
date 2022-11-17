using UnityEngine;

namespace Invaders.Additional
{
    public interface ITransfer
    {
        void Take();

        void Throw(Vector3 position);
    }
}