using Invaders.Additionals;

namespace Invaders.Pysiol
{
    public interface IPhysiology<T> : ICurrentValueProvider<int>, IValueObserver<T>
    {
        void Add(T value);

        void TakeAway(T value);
    }
}