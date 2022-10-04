﻿using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private float _speed;

        private IPlayerInputSystem _inputSystem;
        private Vector3 _direction = Vector3.zero;
        private IMovement _movement;

        [Inject]
        private void Construct(IPlayerInputSystem inputSystem) =>
            _inputSystem = inputSystem;

        private void OnEnable()
        {
            _movement = new VelocityMovement(_rigidbody, _speed);
            
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