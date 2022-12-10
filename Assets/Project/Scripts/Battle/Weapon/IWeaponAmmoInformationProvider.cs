using System;

namespace Invaders.Battle
{
    public interface IWeaponAmmoInformationProvider
    {
        event Action<int, int> OnNumberOfBulletChanged;
    }
}