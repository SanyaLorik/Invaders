using Invaders.Additional;

namespace Invaders.Battle
{
    public interface IThingPortable : IPortable
    {
        object Thing { get; }
    }

    public interface IThingPortable<T> : IPortable
    {
        T Thing { get; }
    }
}