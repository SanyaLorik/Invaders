using Invaders.InputSystem;
using Invaders.Pysiol;
using UnityEngine;
using Zenject;

namespace Invaders.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private int _initialSpeed;
        [SerializeField] [Min(0)] private int _maximumSpeed;

        private IPlayerInputSystem _inputSystem;
        private IMovement _movement;
        private ICurrentValueProvider<int> _speed;
        private Vector3 _direction = Vector3.zero;

        [Inject]
        private void Construct(IPlayerInputSystem inputSystem) =>
            _inputSystem = inputSystem;

        private void Awake()
        {
            _speed = new Speed(_initialSpeed, _maximumSpeed);
            _movement = new VelocityMovement(_rigidbody, _speed);
        }

        private void OnEnable()
        {
            _inputSystem.OnMove += SetDirection;
            _inputSystem.OnStopped += Stop;
        }

        private void OnDisable()
        { 
            _inputSystem.OnMove -= SetDirection;
            _inputSystem.OnStopped -= Stop;
        }
        
        private void FixedUpdate()
        {
            if (_direction == Vector3.zero)
                return;
            
            _movement.Move(_direction);
        }

        private void SetDirection(Vector3 direction) =>
            _direction = direction;
        
        private void Stop()
        {
            _direction = Vector3.zero;
            _movement.Stop();
        }
    }
}