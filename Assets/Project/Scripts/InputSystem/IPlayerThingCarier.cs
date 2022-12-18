using System;

namespace Invaders.InputSystem
{
    public interface IPlayerThingCarier
    {
        event Action OnTakenOrDropped;
    }
}