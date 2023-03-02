using System;

namespace Invaders.InputSystem
{
    public interface IPlayerCarierService
    {
        event Action OnTakenOrDropped;
    }
}