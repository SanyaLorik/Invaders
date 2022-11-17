using UnityEngine;

namespace Invaders.Battle
{
    public abstract class WeaponRapidFire : WeaponFireReal, IWeaponRapidFire
    {
        [field: SerializeField] public float ShootedDelay { get; private set; }
    }
}