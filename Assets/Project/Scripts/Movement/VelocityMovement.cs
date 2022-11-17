using Invaders.Additional;
using UnityEngine;

namespace Invaders.Movement
{
    public class VelocityMovement : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private readonly ICurrentValueProvider<int> _speed;
        
        public VelocityMovement(Rigidbody rigidbody, ICurrentValueProvider<int> speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction) =>
            _rigidbody.velocity = direction * _speed.Current;

        public void Stop() =>
            _rigidbody.velocity = Vector2.zero;
    }
}