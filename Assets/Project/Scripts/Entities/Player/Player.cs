using Invaders.Additional;
using Invaders.Movement;
using Invaders.Pysiol;
using UnityEngine;

namespace Invaders.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : 
        MonoBehaviour, 
        IDamageable<int>, 
        IValueProvider<Temperature>,
        IPlayerLookService
    {
        [Header("Health")]
        [SerializeField] [Min(0)] private int _initialHealth;
        [SerializeField] [Min(0)] private int _maximumHealth;
        
        [Header("Temperature")]
        [SerializeField] [Min(0)] private int _initialTemperature;
        [SerializeField] [Min(0)] private int _maximumTemperature;
        
        private IPhysiology<int> _health;
        private IPhysiology<int> _temperature;
        private IPhysiology<int> _hunger;
        private IPhysiology<int> _thirst;

        private void Awake()
        {
            _health = new Health(_initialHealth, _maximumHealth);
            _temperature = new Temperature(_initialTemperature, _maximumTemperature);
        }

        public Temperature Value => _temperature as Temperature;

        public Vector3 Direction => transform.forward;
        
        public void Damage(int damage) =>
            _health.TakeAway(damage);
    }
}