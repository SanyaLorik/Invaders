using Invaders.Battle;
using UnityEngine;

namespace Invaders.Gear
{
    public struct WeaponContainer
    {
        public WeaponContainer(IWeaponTransfer transfer, Transform position)
        {
            Transfer = transfer;
            Position = position;
        }

        public IWeaponTransfer Transfer { get; }

        public Transform Position { get; }
    }
}