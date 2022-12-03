using System;

namespace Invaders.InputSystem
{
    public interface IPlayerWeaponBearer
    {
        event Action OnTakenOrDroppedWeapon;
    }
}