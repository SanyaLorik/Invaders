using Invaders.Additional;
using System;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class WeaponFireReal : WeaponFire, IWeaponPortable
    {
        [SerializeField][Min(0)] private float _dropppedLenght;

        private readonly Transform _world = null; // temporarily
        private Rigidbody _rigidbody;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public IWeapon Weapon => this;

        public void Take() =>
            _rigidbody.isKinematic = true;

        public void Throw(Vector3 position)
        {
            _rigidbody.isKinematic = false;

            Transfer(position);

            Vector3 direction = transform.forward + Vector3.up;
            float lenght = SpecificMath.CalculateLenght(_rigidbody.mass, _dropppedLenght);

            _rigidbody.AddForce(direction * lenght, ForceMode.Impulse);
        }

        private void Transfer(Vector3 position)
        {
            transform.SetParent(_world);
            transform.position = position;
        }
    }
}