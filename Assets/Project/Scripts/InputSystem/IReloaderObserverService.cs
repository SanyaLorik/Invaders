using System;

namespace Invaders.InputSystem
{
    public interface IReloaderObserverService
    {
        event Action OnReloaded;
    }
}