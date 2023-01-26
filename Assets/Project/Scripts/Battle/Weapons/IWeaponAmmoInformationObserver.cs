using System;

namespace Invaders.Battle
{
    public interface IWeaponAmmoInformationObserver
    {
        event Action<int, int> OnNumberOfBulletChanged;
    }
}