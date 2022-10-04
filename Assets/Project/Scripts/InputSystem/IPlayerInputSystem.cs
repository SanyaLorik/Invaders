using System;
using UnityEngine;

namespace Invaders.InputSystem
{
    public interface IPlayerInputSystem
    {
        event Action<Vector3> OnMove;
        
        event Action OnStopped;
    }
}