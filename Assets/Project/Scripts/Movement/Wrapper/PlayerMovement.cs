﻿using Invaders.Additionals;
using Invaders.InputSystem;
using Invaders.Pysiol;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GroundLocator _groundLocator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private int _initialSpeed;
        [SerializeField] [Min(0)] private int _maximumSpeed;

        private IMovementService _movementService;
        private ISneakingService _sneakingService;

        private IMovement _movement;
        private ISpeed _speed;
        private Vector3 _direction = Vector3.zero;

        [Inject]
        private void Construct(IMovementService movementService, ISneakingService sneakingService)
        {
            _movementService = movementService;
            _sneakingService = sneakingService;
        }

        private void Awake()
        {
            _speed = new Speed(_initialSpeed, _maximumSpeed);
            _movement = new VelocityMovementGround(_rigidbody, _speed as ICurrentValueProvider<int>, _groundLocator);
        }

        private void OnEnable()
        {
            _movementService.OnMove += OnSetDirection;
            _movementService.OnStopped += OnStop;

            _sneakingService.OnSneakingStarted += _speed.TurnOnSneaking;
            _sneakingService.OnSneakingStopped += _speed.TurnOffSneaking;
        }

        private void OnDisable()
        { 
            _movementService.OnMove -= OnSetDirection;
            _movementService.OnStopped -= OnStop;

            _sneakingService.OnSneakingStarted -= _speed.TurnOnSneaking;
            _sneakingService.OnSneakingStopped -= _speed.TurnOffSneaking;
        }
        
        private void FixedUpdate() =>
            _movement.Move(_direction);

        private void OnSetDirection(Vector3 direction) =>
            _direction = direction;

        private void OnStop() =>
            _direction = Vector3.zero;
    }
}