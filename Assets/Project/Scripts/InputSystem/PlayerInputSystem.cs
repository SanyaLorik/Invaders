using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Invaders.InputSystem
{
    public class PlayerInputSystem : MonoBehaviour, IMovementService, IPointPositionOnScreenService, IClickedService
    {
        public event Action<Vector3> OnMove = delegate { };
        public event Action OnStopped = delegate { };
        public event Action<Vector2> OnLooked = delegate { };
        public event Action OnClicked = delegate { };

        private InvadersInputSystem _inputSystem;

        private void Awake() =>
            _inputSystem = new InvadersInputSystem();

        private void OnEnable()
        {
            _inputSystem.Player.Move.performed += MoveStarted;
            _inputSystem.Player.Move.canceled += MoveEnded;
            _inputSystem.Player.Look.performed += LookAt;
            _inputSystem.Player.Click.performed += Click;
            
            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Player.Move.performed -= MoveStarted;
            _inputSystem.Player.Move.canceled -= MoveEnded;
            _inputSystem.Player.Look.performed -= LookAt;
            _inputSystem.Player.Click.performed -= Click;
            
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

            OnMove.Invoke(direction);
        }

        private void MoveEnded(InputAction.CallbackContext _) =>
            OnStopped.Invoke();

        private void LookAt(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            OnLooked.Invoke(value);
        }

        private void Click(InputAction.CallbackContext _) =>
            OnClicked.Invoke();
    }
}