using System;

namespace Invaders.Additionals
{
    public interface IValueObserver<T1, T2>
    {
        event Action<T1, T2> OnChanged;
    }
}