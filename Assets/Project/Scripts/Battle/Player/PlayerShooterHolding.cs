using System.Threading;
using Cysharp.Threading.Tasks;
using Invaders.InputSystem;
using Invaders.Movement;

namespace Invaders.Battle
{
    public class PlayerShooterHolding : IPlayerShooter
    {
        private readonly IPlayerLookService _look;
        private readonly IHolderService _holder;
        private readonly IWeaponRapidFire _weaponRapidFire;

        private CancellationTokenSource _tokenSource;

        public PlayerShooterHolding(IPlayerLookService look, IHolderService holder, IWeaponRapidFire weaponRapidFire)
        {
            _look = look;
            _holder = holder;
            _weaponRapidFire = weaponRapidFire;
        }

        public void Enable()
        {
            _holder.OnHeld += StartShooting;
            _holder.OnUnheld += StopShooting;
        }

        public void Disable()
        {
            _holder.OnHeld -= StartShooting;
            _holder.OnUnheld -= StopShooting;
        }
        
        private void StartShooting()
        {
            _tokenSource = new CancellationTokenSource();
            Shoot(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid Shoot(CancellationToken token)
        {
            int delay = (int)(_weaponRapidFire.ShootedDelay * 1000);
            
            do
            {
                _weaponRapidFire.Shoot(_look.Direction);
                await UniTask.Delay(delay, cancellationToken: token);
            } 
            while (token.IsCancellationRequested == false);
        }
        
        private void StopShooting() =>
            _tokenSource?.Cancel();
    }
}