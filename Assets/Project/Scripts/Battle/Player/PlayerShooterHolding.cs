using Cysharp.Threading.Tasks;
using Invaders.InputSystem;
using Invaders.Movement;
using System.Threading;

namespace Invaders.Battle
{
    public class PlayerShooterHolding : PlayerShooterFire<IWeaponRapidFire>
    {
        private readonly IHolderService _holder;

        private CancellationTokenSource _tokenSource;

        public PlayerShooterHolding(IPlayerLookService look, IWeaponRapidFire weapon, IWeaponReloaderObserverService reloader, IHolderService holder) : base(look, weapon, reloader) =>
            _holder = holder;

        public override void Enable()
        {
            base.Enable();
            
            _holder.OnHeld += StartShooting;
            _holder.OnUnheld += StopShooting;
        }

        public override void Disable()
        {
            base.Disable();

            _holder.OnHeld -= StartShooting;
            _holder.OnUnheld -= StopShooting;

            _tokenSource?.Cancel();
        }
        
        private void StartShooting()
        {
            _tokenSource = new CancellationTokenSource();
            ShootProcess(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid ShootProcess(CancellationToken token)
        {
            int delay = (int)(Weapon.ShootedDelay * 1000);
     
            do
            {
                Shoot();
                await UniTask.Delay(delay, cancellationToken: token);
            } 
            while (token.IsCancellationRequested == false);
        }
        
        private void StopShooting() =>
            _tokenSource?.Cancel();
    }
}