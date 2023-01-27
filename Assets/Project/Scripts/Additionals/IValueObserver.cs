using System;

namespace Invaders.Additionals
{
    public interface IValueObserver<T>
    {
        event Action<T> OnChanged;
    }
}