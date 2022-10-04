using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Invaders.InputSystem
{
    public class PlayerInputSystem : MonoBehaviour, IPlayerInputSystem
    {
        public event Action<Vector3> OnMove = delegate { };
        public event Action OnStopped = delegate { };

        private InvadersInputSystem _inputSystem;

        private void Awake() =>
            _inputSystem = new InvadersInputSystem();

        private void OnEnable()
        {
            _inputSystem.Player.Move.performed += MoveStarted;
            _inputSystem.Player.Move.canceled += MoveEnded;
            
            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Player.Move.performed -= MoveStarted;
            _inputSystem.Player.Move.canceled -= MoveEnded;
            
            _inputSystem.Disable();
        }

        private void MoveStarted(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            var direction = new Vector3()
            {
                x = value.x,
                y = 0,
                z = value.y,
            };
            print(value + " " + direction);
            OnMove.Invoke(direction);
        }

        private void MoveEnded(InputAction.CallbackContext _) =>
            OnStopped.Invoke();
    }
}