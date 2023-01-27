using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Movement
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] [Min(0)] private float _angleOffset;
        
        private IPointPositionOnScreenService _pointPositionOnScreenService;
        private IRotator _rotator;

        [Inject]
        private void Construct(IPointPositionOnScreenService pointPositionOnScreenService) =>
            _pointPositionOnScreenService = pointPositionOnScreenService;

        private void Awake() =>
            _rotator = new MovingRotator(_rigidbody);

        private void OnEnable() =>
            _pointPositionOnScreenService.OnLooked += PointPositionOnScreen;

        private void OnDisable() =>
            _pointPositionOnScreenService.OnLooked -= PointPositionOnScreen;
        
        private void PointPositionOnScreen(Vector2 mouse)
        {
            var player = (Vector2)_camera.WorldToScreenPoint(_rigidbody.transform.position);
            float atan2 = Mathf.Atan2(mouse.y - player.y, mouse.x - player.x) * Mathf.Rad2Deg;
            float angle = -atan2 + _angleOffset;
            
            _rotator.Rotate(angle);
        }
    }
}