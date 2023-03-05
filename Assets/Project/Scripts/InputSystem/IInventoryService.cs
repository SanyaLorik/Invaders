using System;

namespace Invaders.InputSystem
{
    public interface IInventoryService
    {
        event Action OnInventoryOpenedOrClosed;
    }
}