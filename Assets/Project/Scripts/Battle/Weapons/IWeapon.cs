using Invaders.Gear;
using UnityEngine;

namespace Invaders.Battle
{
    public interface IWeapon : IItem
    {
        void Shoot(Vector3 direction);
    }
}