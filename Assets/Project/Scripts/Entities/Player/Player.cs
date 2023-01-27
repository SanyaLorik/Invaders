using Invaders.Additionals;
using Invaders.Movement;
using Invaders.Pysiol;
using UnityEngine;

namespace Invaders.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour, IPlayer
    {
        [Header("Health")]
        [SerializeField] [Min(0)] private int _initialHealth;
        [SerializeField] [Min(0)] private int _maximumHealth;
       
        private IPhysiology<int> _health;

        private void Awake() =>
            _health = new Health(_initialHealth, _maximumHealth);

        public Health Value => _health as Health;

        public Vector3 Direction => transform.forward;
        
        public void Damage(int damage) =>
            _health.TakeAway(damage);
    }
}