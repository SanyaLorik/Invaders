using System;

namespace Invaders.Battle
{
    public interface IWeaponHavingObserver
    {
        event Action<string> OnHad;
        event Action OnNoHad;
    }
}