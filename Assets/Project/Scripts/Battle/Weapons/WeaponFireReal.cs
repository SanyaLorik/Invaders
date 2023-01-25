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
        private Rigidbody _rigidbody;
        private Collider _collider;

        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public IWeapon Thing => this;

        public void Take()
        {
            _rigidbody.isKinematic = true;
            _collider.isTrigger = true;
        }

        public void Throw(Vector3 position)
        {
            _rigidbody.isKinematic = false;
            _collider.isTrigger = false;

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
    }
}