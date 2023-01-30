using Invaders.Battle;
using Invaders.Pysiol;
using UnityEngine;

namespace Invaders.Environment.Buildings
{
    [RequireComponent(typeof(Collider))]
    public class Barrel : MonoBehaviour, IDamageable<int>
    {
        [SerializeField][Min(0)] private int _health;

        [Header("Explosion")]
        [SerializeField] private Transform _source;
        [SerializeField][Min(0)] private int _damage;
        [SerializeField][Min(0)] private float _radius;
        [SerializeField][Min(0)] private float _lenght;

        public void Damage(int damage)
        {
            _health -= damage;
            if (_health > 0)
                return;

            Explosion explosion = new(this, _source, _damage, _radius, _lenght);

            explosion.Explode();
            Destroy(gameObject);
        }
    }
}