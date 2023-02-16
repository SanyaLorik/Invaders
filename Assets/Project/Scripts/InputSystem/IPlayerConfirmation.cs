using System;

namespace Invaders.InputSystem
{
    public interface IPlayerConfirmation
    {
        event Action OnConfirmed;
    }
}