using System;

namespace Invaders.InputSystem
{
    public interface IWeaponReloaderService
    {
        event Action OnWeaponReloaded;
    }
}