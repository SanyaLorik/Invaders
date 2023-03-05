using System;

namespace Invaders.InputSystem
{
    public interface IPlayerReceiverService
    {
        event Action OnReceived;
    }
}