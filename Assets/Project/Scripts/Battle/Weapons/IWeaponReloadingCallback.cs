using System;

namespace Invaders.Battle
{
    public interface IWeaponReloadingCallback
    {
        void OnReloadingStarted(Action callback);

        void OnReloadingStopped(Action callback);

        float ReloaingTime { get; }
    }
}