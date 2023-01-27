using System;

namespace Invaders.Battle
{
    public interface IWeaponReloadingObserver
    {
        event Action OnStartReloaded;

        event Action OnStopReloaded;

        float ReloadedTime { get; }
    }
}