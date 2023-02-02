using Invaders.Environment.Buildings;

namespace Invaders.Battle
{
    public interface IAmmoReplenishable : IReplenishment
    {
        void Replenish(float ratioOfTotalAmmo);
    }
}