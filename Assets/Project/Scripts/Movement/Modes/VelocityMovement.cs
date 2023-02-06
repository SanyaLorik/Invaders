using Invaders.Additionals;
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

        public void Move(Vector3 direction)
        {
            Vector3 velocity = direction * _speed.Current;
            _rigidbody.velocity = new Vector3()
            {
                x = velocity.x,
                y = _rigidbody.velocity.y,
                z = velocity.z
            };
        }
    }
}