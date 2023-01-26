using System;

namespace Invaders.Battle
{
    public interface IWeaponAmmoCallback
    {
        void OnChangeNubmerOfBullet(Action<int, int> callback);
    }
}