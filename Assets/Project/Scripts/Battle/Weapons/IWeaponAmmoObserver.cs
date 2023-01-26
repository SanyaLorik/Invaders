using System;

namespace Invaders.Battle
{
    public interface IWeaponAmmoObserver
    {
        event Action<int, int> OnNumberOfBulletChanged;
    }
}