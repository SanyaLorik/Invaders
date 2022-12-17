using Invaders.Additional;

namespace Invaders.Battle
{
    public interface IThingPortable<T> : IPortable
    {
        T Thing { get; }
    }
}