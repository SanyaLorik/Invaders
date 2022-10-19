using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Movement
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField][Min(0)] private float _speed;

        private IPlayerInputSystem _inputSystem;
        private Vector3 _direction = Vector3.zero;
        private IRotator _rotator;

        [Inject]
        private void Construct(IPlayerInputSystem inputSystem) =>
            _inputSystem = inputSystem;

        private void Awake() =>
            _rotator = new MovingRotator(_rigidbody, _speed);

        private void OnEnable() =>
            _inputSystem.OnMove += SetDirection;

        private void OnDisable() =>
            _inputSystem.OnMove -= SetDirection;

        private void FixedUpdate() =>
            _rotator.Rotate(_direction);

        private void SetDirection(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;
            
            _direction = direction;
        }
    }
}