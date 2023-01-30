using Invaders.Additionals;
using UnityEngine;

namespace Invaders.Movement
{
    public class ForceMovement : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private readonly ICurrentValueProvider<int> _speed;

        public ForceMovement(Rigidbody rigidbody, ICurrentValueProvider<int> speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction) =>
            _rigidbody.AddForce(direction * _speed.Current);
    }
}