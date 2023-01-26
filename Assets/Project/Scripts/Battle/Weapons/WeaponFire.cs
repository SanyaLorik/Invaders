using Cysharp.Threading.Tasks;
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
        [SerializeField] [Min(0)] private int _initialNumberOfBullet;
        [SerializeField] [Min(0)] private int _numberOfBulletInMagazin;
        [SerializeField] [Min(0)] private int _totalNumberOfBullet;
        [SerializeField] [Min(0)] private float _reloadedTime;

        private Action<int, int> _reducingBullets;
        private Action _startedReloading;
        private Action _stoppedReloading;

        private CancellationTokenSource _tokenSource;

        private int _currentBullet;
        private int _currentTotalBullet;
        private bool _isReloading = false;

        protected virtual void Awake()
        {
            _currentBullet = _initialNumberOfBullet;
            _currentTotalBullet = _totalNumberOfBullet;
        }

        private void OnDisable()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public float ReloaingTime => _reloadedTime;

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
            int currentAllBullet = _currentTotalBullet + bullet;
            _currentTotalBullet = Mathf.Clamp(currentAllBullet, 0, _totalNumberOfBullet);
        }

        public void OnReduceBullet(Action<int, int> callback) =>
           _reducingBullets = callback;

        public void OnReloadingStarted(Action callback) =>
            _startedReloading = callback;

        public void OnReloadingStopped(Action callback) =>
            _stoppedReloading = callback;

        protected void ReduceBullet()
        {
            if (HaveBulletInMagazin == false)
                return;

            _currentBullet--;
            _reducingBullets?.Invoke(_currentBullet, _currentTotalBullet);
        }

        private async UniTaskVoid DealyReload(CancellationToken token)
        {
            token.Register(() =>
            {
                _isReloading = false;
                _stoppedReloading?.Invoke();
            });

            int millisecond = (int)(_reloadedTime * 1000);
            await UniTask.Delay(millisecond, cancellationToken: token);

            _currentTotalBullet += _currentBullet;
            _currentBullet = 0;

            if (_currentTotalBullet < _currentBullet)
            {
                _currentBullet = _currentTotalBullet;
            }
            else
            {
                _currentBullet = _numberOfBulletInMagazin;
                _currentTotalBullet -= _numberOfBulletInMagazin;
            }

            _isReloading = false;
        }

        private bool HaveBulletInMagazin => _currentBullet > 0;

        protected abstract IMissile Spawn(Missile missile, Transform muzzle);

        protected abstract void LaunchMissile(IMissile missile, Vector3 direction, float speed);
    }
}