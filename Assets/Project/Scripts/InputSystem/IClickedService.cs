using System;

namespace Invaders.InputSystem
{
    public interface IClickedService
    {
        event Action OnClicked;
    }
}