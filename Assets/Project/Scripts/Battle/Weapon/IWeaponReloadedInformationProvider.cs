using System;

namespace Invaders.Battle
{
    public interface IWeaponReloadedInformationProvider
    {
        event Action OnStartReloaded;

        event Action OnStopReloaded;

        float ReloadedTime { get; }
    }
}