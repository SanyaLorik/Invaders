using System;

namespace Invaders.InputSystem
{
    public interface ISceneReloaderObserverService
    {
        event Action OnSceneReloaded;
    }
}