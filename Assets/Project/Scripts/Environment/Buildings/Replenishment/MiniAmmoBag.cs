using Invaders.Battle;
using UnityEngine;

namespace Invaders.Environment.Buildings
{
    public class MiniAmmoBag : SingleStationaryReplenishment<IAmmoReplenishable>
    {
        [SerializeField][Range(0, 1)] private float _ratioOfReplenishment;

        protected override void ChangeValue(IAmmoReplenishable replenishable) =>
            replenishable.Replenish(_ratioOfReplenishment);
    }
}