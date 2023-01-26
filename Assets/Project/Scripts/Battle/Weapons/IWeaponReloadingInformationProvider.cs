using System;

namespace Invaders.Battle
{
    public interface IWeaponReloadingInformationProvider
    {
        event Action OnStartReloaded;

        event Action OnStopReloaded;

        float ReloadedTime { get; }
    }
}