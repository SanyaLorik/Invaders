using System;
using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Battle
{
    public class PlayerWeaponRotator : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _around;
        [SerializeField] private Transform _weapon;
        [SerializeField] [Min(0)] private float _duration;

        private IPointPositionOnScreenService _pointPositionOnScreenService;
        private WeaponRotator _rotator;

        [Inject]
        private void Construct(IPointPositionOnScreenService pointPositionOnScreenService) =>
            _pointPositionOnScreenService = pointPositionOnScreenService;
        
        private void Awake() =>
            _rotator = new WeaponRotator(_around, _weapon, _duration);

        private void OnEnable() =>
            _pointPositionOnScreenService.OnLooked += Rotate;

        private void OnDisable() =>
            _pointPositionOnScreenService.OnLooked -= Rotate;

        private void Rotate(Vector2 vector)
        {
            
        }
    }
}