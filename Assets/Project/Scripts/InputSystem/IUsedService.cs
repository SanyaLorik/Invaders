using System;

namespace Invaders.InputSystem
{
    public interface IUsedService
    {
        event Action OnUsed;
    }
}