using System;
using UnityEngine;

namespace Invaders.InputSystem
{
    public interface IClickedService
    {
        event Action OnClicked;
    }
}