using UnityEngine;

namespace Invaders.Movement
{
    public class MovingRotator : IRotator
    {
        private readonly Rigidbody _rigidbody;

        public MovingRotator(Rigidbody rigidbody) =>
            _rigidbody = rigidbody;

        public void Rotate(float angle)
        {
            Quaternion quaternion = Quaternion.Euler(new Vector3(0, angle, 0));
            _rigidbody.MoveRotation(quaternion);
        }
    }
}