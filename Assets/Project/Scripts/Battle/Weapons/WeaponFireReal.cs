using Invaders.Additionals;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class WeaponFireReal : WeaponFire
    {
        [SerializeField][Min(0)] private float _dropppedLenght;

        private readonly Transform _world = null; // temporarily
        private Collider _collider;
        private Rigidbody _rigidbody;

        protected override void Awake()
        {
            base.Awake();

            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Take() =>
            ChangePhysics(true);

        public void Throw(Vector3 position)
        {
            ChangePhysics(false);
            Transfer(position);
            Throw();
        }

        private void Throw()
        {
            Vector3 direction = transform.forward + Vector3.up;
            float lenght = SpecificMath.CalculateForceIgnoreMass(_rigidbody.mass, _dropppedLenght);

            _rigidbody.AddForce(direction * lenght, ForceMode.Impulse);
        }

        private void Transfer(Vector3 position)
        {
            transform.SetParent(_world);
            transform.position = position;
        }

        private void ChangePhysics(bool isActive) =>
            _collider.isTrigger = _rigidbody.isKinematic = isActive;
    }
}