using UnityEngine;

namespace Invaders.Battle
{
    public abstract class WeaponTappingFire : WeaponFireReal, IWeaponTappingFire
    {
        [field: SerializeField] public float TappedDelay { get; private set; }
    }
}