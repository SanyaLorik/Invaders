using UnityEngine;

namespace Invaders.Battle
{
    public abstract class WeaponRapidFire : WeaponFireReal, IWeaponRapidFire
    {
        [field: SerializeField] [field: Min(0)] public float ShootedDelay { get; private set; }
    }
}