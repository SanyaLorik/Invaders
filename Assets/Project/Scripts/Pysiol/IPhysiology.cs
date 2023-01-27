using Invaders.Additionals;

namespace Invaders.Pysiol
{
    public interface IPhysiology<T> : ICurrentValueProvider<int>, IValueObserver<int, int>
    {
        void Add(T value);

        void TakeAway(T value);
    }
}