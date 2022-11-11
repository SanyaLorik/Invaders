using System;

namespace Invaders.InputSystem
{
    public interface IHolderService
    {
        event Action OnHeld;

        event Action OnUnheld;
    }
}