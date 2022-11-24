using Cysharp.Threading.Tasks;
using System;
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

        private int _currentBullet; 
        private int _currentAllBullet; 

        protected virtual void Awake()
        {
            _currentBullet = _initialNumberOfBullet;
            _currentAllBullet = _allNumberOfBullet;
        }

        public override void Shoot(Vector3 direction)
        {
            /*
            if (_currentBullet < 0)
                return;
            */
            IMissile missile = Spawn(_missile, _muzzle);
            missile.Damage = _damage;
            
            LaunchMissile(missile, direction, _speed);
            /*
            _currentBullet--;*/
        }

        public void Reload()
        {
            if (_currentAllBullet <= 0)
                return;

            DealyReload().Forget();

            if (_currentAllBullet < _currentBullet)
            {
                _currentBullet = _currentAllBullet;
            }
            else
            {
                _currentBullet = _numberOfBulletInMagazin;
                _currentAllBullet -= _numberOfBulletInMagazin;
            }
        }

        private async UniTaskVoid DealyReload()
        {
            int millisecond = (int)(_reloadedTime * 1000);
            await UniTask.Delay(millisecond);
        }

        protected abstract IMissile Spawn(Missile missile, Transform muzzle);

        protected abstract void LaunchMissile(IMissile missile, Vector3 direction, float speed);
    }
}