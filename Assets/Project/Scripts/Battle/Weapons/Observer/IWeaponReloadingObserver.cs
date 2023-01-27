using System;

namespace Invaders.Battle
{
    public interface IWeaponReloadingObserver
    {
        event Action OnReloadingStarted;

        event Action OnReloadingStopped;

        float ReloadedTime { get; }
    }
}