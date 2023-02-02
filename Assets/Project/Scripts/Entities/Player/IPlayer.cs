using Invaders.Additionals;
using Invaders.Environment.Buildings;
using Invaders.Movement;
using Invaders.Pysiol;

namespace Invaders.Entities
{
    public interface IPlayer : IDamageable<int>, IValueProvider<Health>, IPlayerLookService, IReplenishment
    {

    }
}