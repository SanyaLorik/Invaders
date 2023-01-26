using Invaders.Additionals;
using System;

namespace Invaders.Gear
{
    public interface ICarrierObserver<T>
        where T : IPortable
    {
        event Action<T> OnTaken;
        event Action OnDropped;
    }
}