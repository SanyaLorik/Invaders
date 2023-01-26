using Invaders.Additionals;
using Invaders.Gear;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class WeaponFireReal : WeaponFire, IThingPortable<IWeapon>
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

        public IWeapon Thing => this;

        public void Take() =>
            ChangePhysics(true);

        public void Throw(Vector3 position)
        {
            ChangePhysics(false);
            Transfer(position);
            Drop();
        }

        private void Drop()
        {
            Vector3 direction = transform.forward + Vector3.up;
            float lenght = SpecificMath.CalculateLenght(_rigidbody.mass, _dropppedLenght);

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