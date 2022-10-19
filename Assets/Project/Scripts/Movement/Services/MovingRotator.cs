using UnityEngine;

namespace Invaders.Movement
{
    public class MovingRotator : IRotator
    {
        private readonly Rigidbody _rigidbody;
        private float _speed;

        public MovingRotator(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Rotate(Vector3 direction)
        {
            Vector2 newDirection = new Vector2()
            {
                x = direction.x,
                y = direction.z
            };

            var angle = Vector2.SignedAngle(newDirection, Vector2.up);
            Debug.Log(angle);

            var initial = _rigidbody.rotation;
            var final = Quaternion.Euler(new Vector3(0, angle, 0));
            var lerp = Quaternion.Lerp(initial, final, Time.fixedDeltaTime);

            _rigidbody.MoveRotation(lerp);
        }
    }
}