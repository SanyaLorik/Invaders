using Invaders.Additionals;
using UnityEngine;

namespace Invaders.Movement
{
    public class PositionMovement : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private readonly ICurrentValueProvider<int> _speed;
        private readonly SurfaceSlider _surfaceSlider;

        public PositionMovement(Rigidbody rigidbody, ICurrentValueProvider<int> speed, SurfaceSlider surfaceSlider)
        {
            _rigidbody = rigidbody;
            _speed = speed;
            _surfaceSlider = surfaceSlider;
        }

        public void Move(Vector3 direction)
        {
            Vector3 directionAlongSurface = _surfaceSlider.Project(direction);
            Vector3 offset = directionAlongSurface * _speed.Current * Time.fixedDeltaTime;

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}