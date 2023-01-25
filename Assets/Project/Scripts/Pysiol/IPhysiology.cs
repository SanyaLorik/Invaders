using Invaders.Additionals;
using System;

namespace Invaders.Pysiol
{
    public interface IPhysiology<T>
    {
        event Action<T> OnChanged;
     
        ICurrentValueProvider<T> Provider { get; }
        
        void Add(T value);

        void TakeAway(T value);
    }
}