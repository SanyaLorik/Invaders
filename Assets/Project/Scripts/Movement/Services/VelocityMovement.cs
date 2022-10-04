using UnityEngine;

namespace Invaders.Movement
{
    public class VelocityMovement : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;
        
        public VelocityMovement(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction) =>
            _rigidbody.velocity = direction * _speed;

        public void Stop() =>
            _rigidbody.velocity = Vector2.zero;
    }
}