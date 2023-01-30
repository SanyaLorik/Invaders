using UnityEngine;

namespace Invaders.Movement
{
    public interface IPlayerLookService
    {
        Vector3 Direction { get; }
    }
}