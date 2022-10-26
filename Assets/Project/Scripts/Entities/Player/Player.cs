using System;
using Invaders.Pysiol;
using UnityEngine;

namespace Invaders.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : 
        MonoBehaviour, 
        IDamageable<int>, 
        IValueProvider<Temperature>, IValueProvider<IDamageable<int>>
    {
        [Header("Health")]
        [SerializeField] [Min(0)] private int _initialHealth;
        [SerializeField] [Min(0)] private int _maximumHealth;
        
        [Header("Temperature")]
        [SerializeField] [Min(0)] private int _initialTemperature;
        [SerializeField] [Min(0)] private int _maximumTemperature;
        
        private Health _health;
        private Temperature _temperature;

        private void Awake()
        {
            _health = new Health(_initialHealth, _maximumHealth);
            _temperature = new Temperature(_initialTemperature, _maximumTemperature);
        }
        
        Temperature IValueProvider<Temperature>.Value => _temperature;
        
        IDamageable<int> IValueProvider<IDamageable<int>>.Value => this;

        public void Damage(int damage) =>
            _health.TakeAway(damage);
    }
}