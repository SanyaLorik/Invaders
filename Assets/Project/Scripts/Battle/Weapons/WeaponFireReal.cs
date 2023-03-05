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

        public override void PickUp()
        {
            base.PickUp();

            CanTaken = false;

            ChangePhysics(true);
        }

        public override void Drop()
        {
            base.Drop();

            CanTaken = true;

            ChangePhysics(false);
            Transfer();
            Throw();
        }

        public override void Show() =>
            gameObject.SetActive(true);

        public override void Hide() =>
            gameObject.SetActive(false);

        private void Throw()
        {
            Vector3 direction = transform.forward + Vector3.up;
            float lenght = SpecificMath.CalculateForceIgnoreMass(_rigidbody.mass, _dropppedLenght);

            _rigidbody.AddForce(direction * lenght, ForceMode.Impulse);
        }

        private void Transfer() =>
            transform.SetParent(_world);

        private void ChangePhysics(bool isActive) =>
            _collider.isTrigger = _rigidbody.isKinematic = isActive;
    }
}