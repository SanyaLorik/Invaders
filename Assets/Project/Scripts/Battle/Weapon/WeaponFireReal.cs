using Invaders.Additional;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class WeaponFireReal : WeaponFire, IWeaponTransfer
    {
        private readonly Transform _world = null;
        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        public IWeapon Weapon => this;

        public void Take() =>
            _rigidbody.isKinematic = true;

        public void Throw(Vector3 position)
        {
            _rigidbody.isKinematic = false;

            transform.SetParent(_world);
            transform.position = position;
        }
    }
}