using System;

namespace Invaders.Battle
{
    public interface IWeaponReloadingCallback
    {
        void OnStartReloading(Action callback);

        void OnStopReloading(Action callback);

        float ReloaingTime { get; }
    }
}