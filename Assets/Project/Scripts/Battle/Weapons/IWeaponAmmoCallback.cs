using System;

namespace Invaders.Battle
{
    public interface IWeaponAmmoCallback
    {
        void OnReduceBullet(Action<int, int> callback);
    }
}