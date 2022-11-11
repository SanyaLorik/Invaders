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
        [SerializeField] private WeaponRapidFire _handgun;
        
        private IPhysiology<int> _health;
        private IPhysiology<int> _temperature;
        private IWeaponRapidFire _weaponRapidFire;
        private IPlayerShooter _playerShooter;
        private IClickedService _clickedService;
        private IHolderService _holderService;

        [Inject]
        private void Construct(IClickedService clickedService, IHolderService holderService)
        {
            _clickedService = clickedService;
            _holderService = holderService;
        }
        
        private void Awake()
        {
            _health = new Health(_initialHealth, _maximumHealth);
            _temperature = new Temperature(_initialTemperature, _maximumTemperature);
            _weaponRapidFire = _handgun;
            _playerShooter = new PlayerShooterHolding(this, _holderService, _weaponRapidFire);
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