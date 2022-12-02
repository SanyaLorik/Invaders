using System;

namespace Invaders.InputSystem
{
    public interface IWeaponReloaderObserverService
    {
        event Action OnWeaponReloaded;
    }
}