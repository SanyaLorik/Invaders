using System;

namespace Invaders.InputSystem
{
    public interface ISneakingService
    {
        event Action OnSneakingStarted;
        event Action OnSneakingStopped;
    }
}