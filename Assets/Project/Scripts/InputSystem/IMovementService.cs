using System;
using UnityEngine;

namespace Invaders.InputSystem
{
    public interface IMovementService
    {
        event Action<Vector3> OnMove;
        
        event Action OnStopped;
    }
}