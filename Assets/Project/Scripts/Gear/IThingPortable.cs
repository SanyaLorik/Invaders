using Invaders.Additionals;

namespace Invaders.Gear
{
    public interface IThingPortable<T> : IPortable
    {
        T Thing { get; }
    }
}