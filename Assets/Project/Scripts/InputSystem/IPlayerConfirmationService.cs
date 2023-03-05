using System;

namespace Invaders.InputSystem
{
    public interface IPlayerConfirmationService
    {
        event Action OnConfirmed;
    }
}