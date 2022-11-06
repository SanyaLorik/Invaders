using System;
using UnityEngine;

namespace Invaders.InputSystem
{
    public interface IPointPositionOnScreenService
    {
        event Action<Vector2> OnLooked;
    }
}