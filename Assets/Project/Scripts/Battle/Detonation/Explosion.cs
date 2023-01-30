using Invaders.Additionals;
using Invaders.Pysiol;
using System.Collections.Generic;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(Collider))]
    public class Explosion : MonoBehaviour, IDamageable<int>
    {
        [SerializeField][Min(0)] private int _health;
        [SerializeField][Min(0)] private int _damage;
        [SerializeField][Min(0)] private float _radius;
        [SerializeField][Min(0)] private float _lenght;

        public void Damage(int damage)
        {
            _health -= damage;
            if (_health > 0)
                return;

            Explode();
            Destroy(gameObject);
        }

        private void Explode()
        {
            Collider[] objects = Physics.OverlapSphere(transform.position, _radius);

            foreach (var rigidbody in GetRigidbodies(objects))
                Discard(rigidbody);

            foreach (var damageable in FindDamageables(objects))
                damageable.Damage(_damage);
        }

        private IEnumerable<Rigidbody> GetRigidbodies(IEnumerable<Collider> objects)
        {
            foreach (var o in objects)
            {
                if (o.TryGetComponent(out Rigidbody rigidbody) == true)
                    yield return rigidbody;
            }
        }

        private IEnumerable<IDamageable<int>> FindDamageables(IEnumerable<Collider> objects)
        {
            foreach (var o in objects)
            {
                if (o.TryGetComponent(out IDamageable<int> damage) == false)
                    continue;

                if (damage == (IDamageable<int>) this)
                    continue;

                yield return damage;
            }
        }

        private void Discard(Rigidbody rigidbody)
        {
            Vector3 direction = CalculateDirection(rigidbody.transform.position);
            rigidbody.AddForce(direction * SpecificMath.CalculateForce(_lenght), ForceMode.Impulse);
        }
        
        private Vector3 CalculateDirection(Vector3 target)
        {
            Vector3 direction = target - transform.position;
            direction.Normalize();
            direction.y = 0;

            return direction;
        }
    }
}