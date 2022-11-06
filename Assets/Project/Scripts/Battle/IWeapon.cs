using UnityEngine;

namespace Invaders.Battle
{
    public interface IWeapon
    {
        void Launch(Vector3 direction);
    }
}