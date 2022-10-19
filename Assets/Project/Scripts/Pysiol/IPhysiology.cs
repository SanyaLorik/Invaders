using System;

namespace Invaders.Pysiol
{
    public interface IPhysiology<T>
    {
        event Action<T> OnChanged;
        
        void Add(T value);

        void TakeAway(T value);
    }
}