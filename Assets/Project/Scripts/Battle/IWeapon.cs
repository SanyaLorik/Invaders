using UnityEngine;

namespace Invaders.Battle
{
    public interface IWeapon
    {
        void Shoot(Vector3 direction);
    }
}