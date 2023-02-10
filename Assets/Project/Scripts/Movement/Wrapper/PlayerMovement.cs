using Invaders.Additionals;
using Invaders.InputSystem;
using Invaders.Pysiol;
using UnityEngine;
using Zenject;

namespace Invaders.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private int _initialSpeed;
        [SerializeField] [Min(0)] private int _maximumSpeed;

        private IMovementService _movementService;
        private IMovement _movement;
        private ICurrentValueProvider<int> _speed;
        private Vector3 _direction = Vector3.zero;

        [Inject]
        private void Construct(IMovementService movementService) =>
            _movementService = movementService;

        private void Awake()
        {
            _speed = new Speed(_initialSpeed, _maximumSpeed);
            //_movement = new VelocityMovement(_rigidbody, _speed);
            _movement = new PositionMovement(_rigidbody, _speed, _surfaceSlider);
        }

        private void OnEnable()
        {
            _movementService.OnMove += OnSetDirection;
            _movementService.OnStopped += OnStop;
        }

        private void OnDisable()
        { 
            _movementService.OnMove -= OnSetDirection;
            _movementService.OnStopped -= OnStop;
        }
        
        private void FixedUpdate()
        {
            if (_direction == Vector3.zero)
                return;

            _movement.Move(_direction);
        }

        private void OnSetDirection(Vector3 direction) =>
            _direction = direction;

        private void OnStop()
        {
            _direction = Vector3.zero;
            _movement.Move(_direction);
        }
    }
}