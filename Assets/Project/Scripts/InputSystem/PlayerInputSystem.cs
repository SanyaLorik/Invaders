using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Invaders.InputSystem
{
    public class PlayerInputSystem : 
        MonoBehaviour, 
        IMovementService, IPointPositionOnScreenService, IClickedService, IHolderService, IUsedService, IPlayerThingCarier, IWeaponReloaderObserverService, IPlayerConfirmation, ISneakingService,
        ISceneReloaderObserverService
    {
        public event Action<Vector3> OnMove = delegate { };
        public event Action OnStopped = delegate { };
        public event Action<Vector2> OnLooked = delegate { };
        public event Action OnClicked = delegate { };
        public event Action OnHeld = delegate { };
        public event Action OnUnheld = delegate { };
        public event Action OnUsed = delegate { };
        public event Action OnTakenOrDropped = delegate { };
        public event Action OnWeaponReloaded = delegate { };
        public event Action OnSceneReloaded = delegate { };
        public event Action OnConfirmed = delegate { };
        public event Action OnSneakingStarted = delegate { };
        public event Action OnSneakingStopped = delegate { };

        private InvadersInputSystem _inputSystem;

        private void Awake() =>
            _inputSystem = new InvadersInputSystem();

        private void OnEnable()
        {
            _inputSystem.Player.Move.performed += MoveStarted;
            _inputSystem.Player.Move.canceled += MoveEnded;
            
            _inputSystem.Player.Look.performed += LookAt;
            
            _inputSystem.Player.Click.performed += Click;

            _inputSystem.Player.Click.started += Hold;
            _inputSystem.Player.Click.canceled += Unhold;

            _inputSystem.Player.Use.performed += Use;

            _inputSystem.Player.DroppedWeapon.performed += TakeOrDrop;

            _inputSystem.Player.ReloadWeapon.performed += ReloadWeapon;

            _inputSystem.Player.ReloadScene.performed += ReloadScene;

            _inputSystem.Player.Confirm.performed += Confirm;

            _inputSystem.Player.Sneaking.performed += OnStartSneaking;
            _inputSystem.Player.Sneaking.canceled += OnStopSneaking;

            _inputSystem.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.Player.Move.performed -= MoveStarted;
            _inputSystem.Player.Move.canceled -= MoveEnded;
            
            _inputSystem.Player.Look.performed -= LookAt;
            
            _inputSystem.Player.Click.performed -= Click;
            
            _inputSystem.Player.Click.started -= Hold;
            _inputSystem.Player.Click.canceled -= Unhold;

            _inputSystem.Player.Use.performed -= Use;

            _inputSystem.Player.DroppedWeapon.performed -= TakeOrDrop;

            _inputSystem.Player.ReloadWeapon.performed -= ReloadWeapon;

            _inputSystem.Player.ReloadScene.performed -= ReloadScene;

            _inputSystem.Player.Confirm.performed -= Confirm;

            _inputSystem.Player.Sneaking.performed -= OnStartSneaking;
            _inputSystem.Player.Sneaking.canceled -= OnStopSneaking;

            _inputSystem.Disable();
        }

        private void MoveStarted(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            var direction = new Vector3()
            {
                x = value.x,
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
        
        private void Hold(InputAction.CallbackContext _) =>
            OnHeld.Invoke();
        
        private void Unhold(InputAction.CallbackContext _) =>
            OnUnheld.Invoke();

        private void Use(InputAction.CallbackContext _) =>
            OnUsed.Invoke();

        private void TakeOrDrop(InputAction.CallbackContext _) =>
            OnTakenOrDropped.Invoke();

        private void ReloadWeapon(InputAction.CallbackContext _) =>
            OnWeaponReloaded.Invoke();

        private void ReloadScene(InputAction.CallbackContext _) =>
            OnSceneReloaded.Invoke();

        private void Confirm(InputAction.CallbackContext _) =>
            OnConfirmed.Invoke();

        private void OnStartSneaking(InputAction.CallbackContext _) =>
            OnSneakingStarted.Invoke();

        private void OnStopSneaking(InputAction.CallbackContext _) =>
            OnSneakingStopped.Invoke();
    }
}