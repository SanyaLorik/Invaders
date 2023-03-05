using Cysharp.Threading.Tasks;
using Invaders.Additionals;
using System;
using System.Threading;
using UnityEngine;

namespace Invaders.Battle
{
    public abstract class WeaponFire : Weapon, IWeaponFire
    {
        [Header("Gameobjects")]
        [SerializeField] private Missile _missile;
        [SerializeField] private Transform _muzzle;

        [Header("Physiols")]
        [SerializeField] [Min(0)] private float _speed;
        [SerializeField] [Min(0)] private int _damage;

        [Header("Bullets")]
        [SerializeField] [Min(0)] private int _initialNumberOfBulletInMagazin;
        [SerializeField] [Min(0)] private int _initialTotalNumberOfBullet;
        [SerializeField] [Min(0)] private int _numberOfBulletInMagazin;
        [SerializeField] [Min(0)] private int _totalNumberOfBullet;
        [SerializeField] [Min(0)] private float _reloadedTime;

        private Action<int, int> _changingNumberOfBullets;
        private Action _outingOfAmmo;
        private Action _startedReloading;
        private Action _stoppedReloading;

        private CancellationTokenSource _tokenSource;

        private int _currentBullet;
        private int _currentTotalBullet;
        private bool _isReloading = false;

        protected virtual void Awake()
        {
            _currentBullet = _initialNumberOfBulletInMagazin;
            _currentTotalBullet = _initialTotalNumberOfBullet;
        }

        private void OnDisable()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public override string Description => $"Я есть {Name} с {_currentTotalBullet} внутри";

        public bool IsAllowReplenished { get; private set; }

        public float ReloaingTime => _reloadedTime;

        public override void PickUp() =>
            IsAllowReplenished = true;

        public override void Drop() =>
           IsAllowReplenished = false;

        public override void Use()
        {
            /*
             * decide to do with the method
             */
            Debug.LogWarning("Use method is empty!");
        }

        public override void Shoot(Vector3 direction)
        {
            if (HaveBulletInMagazin == false)
                return;

            if (_isReloading == true)
                return;

            IMissile missile = Spawn(_missile, _muzzle);
            missile.Damage = _damage;
            
            LaunchMissile(missile, direction, _speed);
        }

        public void Reload()
        {
            if (_currentBullet == _numberOfBulletInMagazin)
                return;

            if (_isReloading == true)
                return;

            if (_currentTotalBullet <= 0)
                return;

            _isReloading = true;
            _startedReloading?.Invoke();

            _tokenSource = new CancellationTokenSource();
            DealyReload(_tokenSource.Token).Forget();
        }

        public void BreakReload()
        {
            if (_tokenSource == null)
                return;

            if (_tokenSource.IsCancellationRequested == true)
                return;

            _tokenSource.Cancel();
        }

        public void Replenish(float ratioOfTotalAmmo)
        {
            int bullet = (int)(_totalNumberOfBullet * ratioOfTotalAmmo);
            int currentTotalBullet = _currentTotalBullet + bullet;
            _currentTotalBullet = Mathf.Clamp(currentTotalBullet, 0, _totalNumberOfBullet);
           
            _changingNumberOfBullets?.Invoke(_currentBullet, _currentTotalBullet);
        }

        public void OnChangeNubmerOfBullet(Action<int, int> callback)
        {
            _changingNumberOfBullets = callback; 
            _changingNumberOfBullets?.Invoke(_currentBullet, _currentTotalBullet);
        }

        public void OnOutOfAmmo(Action callaback) =>
            _outingOfAmmo = callaback;

        public void OnStartReloading(Action callback) =>
            _startedReloading = callback;

        public void OnStopReloading(Action callback) =>
            _stoppedReloading = callback;

        protected void ReduceBullet()
        {
            if (_isReloading == true)
                return;

            if (HaveBulletInMagazin == false)
                return;

            _currentBullet--;

            if (HaveBulletInMagazin == false && _currentTotalBullet == 0)
                _outingOfAmmo.Invoke();
            else
                _changingNumberOfBullets?.Invoke(_currentBullet, _currentTotalBullet);
        }

        private async UniTaskVoid DealyReload(CancellationToken token)
        {
            token.Register(() =>
            {
                _isReloading = false;
                _stoppedReloading?.Invoke();
            });

            int delay = _reloadedTime.DelayMillisecond();
            await UniTask.Delay(delay, cancellationToken: token);

            _currentTotalBullet += _currentBullet;

            if (_currentTotalBullet <= _numberOfBulletInMagazin)
            {
                _currentBullet = _currentTotalBullet;
                _currentTotalBullet = 0;
            }
            else
            {
                _currentBullet = _numberOfBulletInMagazin;
                _currentTotalBullet -= _numberOfBulletInMagazin;
            }

            _isReloading = false;
            _changingNumberOfBullets?.Invoke(_currentBullet, _currentTotalBullet);
        }

        private bool HaveBulletInMagazin => _currentBullet > 0;

        protected abstract IMissile Spawn(Missile missile, Transform muzzle);

        protected abstract void LaunchMissile(IMissile missile, Vector3 direction, float speed);
    }
}