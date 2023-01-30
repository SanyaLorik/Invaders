using Invaders.Additionals;
using UnityEngine;

namespace Invaders.Movement
{
    public class CharacterMovement : IMovement
    {
        private readonly CharacterController _character;
        private readonly ICurrentValueProvider<int> _speed;

        public CharacterMovement(CharacterController character, ICurrentValueProvider<int> speed)
        {
            _character = character;
            _speed = speed;
        }

        public void Move(Vector3 direction) =>
            _character.Move(direction * _speed.Current * Time.deltaTime);
    }
}