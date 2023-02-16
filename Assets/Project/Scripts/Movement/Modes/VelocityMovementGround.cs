using Invaders.Additionals;
using UnityEngine;

namespace Invaders.Movement
{
    public class VelocityMovementGround : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private readonly ICurrentValueProvider<int> _speed;
        private readonly GroundLocator _groundLocator;

        public VelocityMovementGround(Rigidbody rigidbody, ICurrentValueProvider<int> speed, GroundLocator groundLocator)
        {
            _rigidbody = rigidbody;
            _speed = speed;
            _groundLocator = groundLocator;
        }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            Vector3 velocity = direction * _speed.Current;
            _rigidbody.velocity = new Vector3()
            {
                x = velocity.x,
                y = _groundLocator.IsGround == true ? 0 : Physics.gravity.y,
                z = velocity.z
            };
        }
    }
}