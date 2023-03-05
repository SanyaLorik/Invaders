using Invaders.Additionals;
using UnityEngine;

namespace Assets.Project.Scripts.Battle.Grenades
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class GrenadeReal : Grenade
    {
        //private Collider _collider;
        private Rigidbody _rigidbody;

        private void Awake()
        {
           // _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Throw(Vector3 direction)
        {
            Show();
           // ChangePhysics(true);

            float force = SpecificMath.CalculateForceIgnoreMass(_rigidbody.mass, Lenght);
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }

        public override void PickUp()
        {
            Hide();
            // ChangePhysics(false);
        }

        public override void Drop()
        {
            Hide();
            //ChangePhysics(false);
        }
        /*
        private void ChangePhysics(bool isActive) =>
            _collider.isTrigger = _rigidbody.isKinematic = isActive;*/

        public override void Show() =>
            gameObject.SetActive(true);

        public override void Hide() =>
            gameObject.SetActive(false);
    }
}