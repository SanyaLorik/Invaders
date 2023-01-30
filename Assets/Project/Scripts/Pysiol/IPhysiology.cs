using Invaders.Additionals;

namespace Invaders.Pysiol
{
    public interface IPhysiology<T> : IAdding<int>, IReducing<int>, ICurrentValueProvider<int>, IValueObserver<int, int>
    {

    }
}