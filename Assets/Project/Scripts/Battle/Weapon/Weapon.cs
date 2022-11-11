using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public abstract void Shoot(Vector3 direction);
    }
}