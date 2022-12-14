using Cysharp.Threading.Tasks;
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
        [SerializeField] [Min(0)] private int _allNumberOfBullet;
        [SerializeField] [Min(0)] private float _reloadedTime;

        private CancellationTokenSource _tokenSource;

        private int _currentBullet;
        private int _currentAllBullet;
        private bool _isReloading = false;

        protected virtual void Awake()
        {
            _currentBullet = _initialNumberOfBullet;
            _currentAllBullet = _allNumberOfBullet;
        }

        private void OnDisable()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public override void Shoot(Vector3 direction)
        {
            if (_isReloading == true)
                return;

            if (_currentBullet <= 0)
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

            if (_currentAllBullet <= 0)
                return;

            _isReloading = true;

            _tokenSource = new CancellationTokenSource();
            DealyReload(_tokenSource.Token).Forget();
        }

        public void BreakReload() =>
            _tokenSource?.Cancel();

        public void Replenish(float ratioOfTotalAmmo)
        {
            int bullet = (int)(_allNumberOfBullet * ratioOfTotalAmmo);
            int currentAllBullet = _currentAllBullet + bullet;
            _currentAllBullet = Mathf.Clamp(currentAllBullet, 0, _allNumberOfBullet);
        }

        protected void ReduceBullet()
        {
            if (_currentBullet <= 0)
                return;

            _currentBullet--;
        }

        private async UniTaskVoid DealyReload(CancellationToken token)
        {
            token.Register(() => _isReloading = false);

            int millisecond = (int)(_reloadedTime * 1000);
            await UniTask.Delay(millisecond, cancellationToken: token);

            _currentAllBullet += _currentBullet;
            _currentBullet = 0;

            if (_currentAllBullet < _currentBullet)
            {
                _currentBullet = _currentAllBullet;
            }
            else
            {
                _currentBullet = _numberOfBulletInMagazin;
                _currentAllBullet -= _numberOfBulletInMagazin;
            }

            _isReloading = false;
        }

        protected abstract IMissile Spawn(Missile missile, Transform muzzle);

        protected abstract void LaunchMissile(IMissile missile, Vector3 direction, float speed);
    }
}