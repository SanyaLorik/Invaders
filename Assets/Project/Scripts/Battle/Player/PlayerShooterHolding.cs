using Cysharp.Threading.Tasks;
using Invaders.Additionals;
using Invaders.InputSystem;
using Invaders.Movement;
using System.Threading;

namespace Invaders.Battle
{
    public class PlayerShooterHolding : PlayerShooterFire<IWeaponRapidFire>
    {
        private readonly IHolderService _holder;

        private CancellationTokenSource _tokenSource;

        public PlayerShooterHolding(IPlayerLookService look, IWeaponRapidFire weapon, IWeaponReloaderService reloader, IHolderService holder) : base(look, weapon, reloader) =>
            _holder = holder;

        public override void Enable()
        {
            base.Enable();
            
            _holder.OnHeld += OnStartShooting;
            _holder.OnUnheld += OnStopShooting;
        }

        public override void Disable()
        {
            base.Disable();

            _holder.OnHeld -= OnStartShooting;
            _holder.OnUnheld -= OnStopShooting;

            _tokenSource?.Cancel();
        }
        
        private void OnStartShooting()
        {
            _tokenSource = new CancellationTokenSource();
            ShootProcess(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid ShootProcess(CancellationToken token)
        {
            int delay = Weapon.ShootedDelay.DelayMillisecond();
     
            do
            {
                Shoot();
                await UniTask.Delay(delay, cancellationToken: token);
            } 
            while (token.IsCancellationRequested == false);
        }
        
        private void OnStopShooting() =>
            _tokenSource?.Cancel();
    }
}