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
            foreach (var damageable in Damageables)
                damageable.Damage(_damage);
        }

        private IEnumerable<IDamageable<int>> Damageables
        {
            get
            {
                Collider[] objects = Physics.OverlapSphere(transform.position, _radius);
                foreach (var o in objects)
                {
                    if (o.TryGetComponent(out IDamageable<int> damage) == false)
                        continue;

                    if (damage == (IDamageable<int>)this)
                        continue;

                    yield return damage;
                }
            }
        }
    }
}