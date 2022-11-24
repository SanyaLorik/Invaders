using Cysharp.Threading.Tasks;
using Invaders.InputSystem;
using Invaders.Movement;

namespace Invaders.Battle
{
    public class PlayerShooterTapping : PlayerShooterFire<IWeaponTappingFire>
    {
        private readonly IClickedService _clicked;

        private bool _canShooting = true;

        public PlayerShooterTapping(IPlayerLookService look, IWeaponTappingFire weapon, IReloaderObserverService reloader, IClickedService clicked) : base(look, weapon, reloader) =>
            _clicked = clicked;

        public override void Enable()
        {
            base.Enable();
            _clicked.OnClicked += ShootingWithDelay;
        }

        public override void Disable()
        {
            base.Disable();
            _clicked.OnClicked -= ShootingWithDelay;
        }

        protected void ShootingWithDelay()
        {
            if (_canShooting == false)
                return;

            Shoot();
            DelayShoot().Forget();

            _canShooting = false;
        }

        private async UniTaskVoid DelayShoot()
        {
            int millisecond = (int)(Weapon.TappedDelay * 1000);
            await UniTask.Delay(millisecond);
            _canShooting = true;
        }
    }
}