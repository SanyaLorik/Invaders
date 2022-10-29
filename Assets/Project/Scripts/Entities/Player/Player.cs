using System;
using Invaders.Battle;
using Invaders.Gear;
using Invaders.Pysiol;
using UnityEngine;

namespace Invaders.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : 
        MonoBehaviour, 
        IDamageable<int>, 
        IValueProvider<Temperature>
    {
        [Header("Health")]
        [SerializeField] [Min(0)] private int _initialHealth;
        [SerializeField] [Min(0)] private int _maximumHealth;
        
        [Header("Temperature")]
        [SerializeField] [Min(0)] private int _initialTemperature;
        [SerializeField] [Min(0)] private int _maximumTemperature;

        [Header("Weapon")] 
        [SerializeField] private Transform _handgunMuzzle;
        [SerializeField] private HandgunBullet _handgunBullet;
        [SerializeField] [Min(0)] private int _HandgunminimumDamage; 
        [SerializeField] [Min(0)] private float _handgunSpeed; 

        private IPhysiology<int> _health;
        private IPhysiology<int> _temperature;
        private IWeapon _weapon;

        private void Awake()
        {
            _health = new Health(_initialHealth, _maximumHealth);
            _temperature = new Temperature(_initialTemperature, _maximumTemperature);
            _weapon = new Handgun(_handgunMuzzle, _handgunBullet, _HandgunminimumDamage, _handgunSpeed);
        }
        
        public Temperature Value => _temperature as Temperature;

        public void Damage(int damage) =>
            _health.TakeAway(damage);
    }
}