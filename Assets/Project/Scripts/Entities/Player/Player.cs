using Invaders.Battle;
using Invaders.InputSystem;
using Invaders.Movement;
using Invaders.Pysiol;
using UnityEngine;
using Zenject;

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

        [Header("Weapon")] 
        [SerializeField] private Weapon _handgun;
        
        private IPhysiology<int> _health;
        private IPhysiology<int> _temperature;
        private IWeapon _weapon;
        private IPlayerShooter _playerShooter;
        private IClickedService _clickedService;

        [Inject]
        private void Construct(IClickedService clickedService) =>
            _clickedService = clickedService;
        
        private void Awake()
        {
            _health = new Health(_initialHealth, _maximumHealth);
            _temperature = new Temperature(_initialTemperature, _maximumTemperature);
            _weapon = _handgun;
            _playerShooter = new PlayerShooter(this, _clickedService, _weapon);
        }

        private void OnEnable() =>
            _playerShooter.Enable();

        private void OnDisable() =>
            _playerShooter.Disable();

        public Temperature Value => _temperature as Temperature;

        public Vector3 Direction => transform.forward;
        
        public void Damage(int damage) =>
            _health.TakeAway(damage);
    }
}