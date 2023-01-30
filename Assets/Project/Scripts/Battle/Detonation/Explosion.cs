using Invaders.Additionals;
using Invaders.Pysiol;
using System.Collections.Generic;
using UnityEngine;

namespace Invaders.Battle
{
    public struct Explosion
    {
        private IDamageable<int> _ignore;
        private Transform _source;
        private int _damage;
        private float _radius;
        private float _lenght;

        public Explosion(IDamageable<int> ignore, Transform source, int damage, float radius, float lenght)
        {
            _ignore = ignore;
            _source = source;
            _damage = damage;
            _radius = radius;
            _lenght = lenght;
        }

        public void Explode()
        {
            Collider[] objects = Physics.OverlapSphere(_source.position, _radius);

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

                if (damage == _ignore)
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
            Vector3 direction = target - _source.position;
            direction.Normalize();
            direction.y = 0;

            return direction;
        }
    }
}