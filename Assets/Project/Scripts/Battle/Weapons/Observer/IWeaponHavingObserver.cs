using System;

namespace Invaders.Battle
{
    public interface IWeaponHavingObserver
    {
        event Action OnDropped;
    }
}