using Invaders.Pysiol;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Missile : MonoBehaviour, IMissile
    {
        public Rigidbody Rigidbody { get; private set; }

        public int Damage { private get; set; }

        private void Awake() =>
            Rigidbody = GetComponent<Rigidbody>();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IDamageable<int> damageable) == true)
                DealDamage(damageable, Damage);

            Destroy(gameObject);
        }

        protected abstract void DealDamage(IDamageable<int> damageable, int damage);
    }
}