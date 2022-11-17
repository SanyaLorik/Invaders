using UnityEngine;

namespace Invaders.Battle
{
    public abstract class WeaponRapidFire : WeaponFire, IWeaponRapidFire
    {
        [field: SerializeField] public float ShootedDelay { get; private set; }
    }
}