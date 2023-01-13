using Cysharp.Threading.Tasks;
using Invaders.InputSystem;
using Invaders.Movement;

namespace Invaders.Battle
{
    public class PlayerShooterTapping : PlayerShooterFire<IWeaponTappingFire>
    {
        private readonly IClickedService _clicked;

        private bool _canShooting = true;

        public PlayerShooterTapping(IPlayerLookService look, IWeaponTappingFire weapon, IWeaponReloaderObserverService reloader, IClickedService clicked) : base(look, weapon, reloader) =>
            _clicked = clicked;

        public override void Enable()
        {
            base.Enable();
            _clicked.OnClicked += OnShootingWithDelay;
        }

        public override void Disable()
        {
            base.Disable();
            _clicked.OnClicked -= OnShootingWithDelay;
        }

        protected void OnShootingWithDelay()
        {
            if (_canShooting == false)
                return;

            Shoot();
            DelayForShooting().Forget();

            _canShooting = false;
        }

        private async UniTaskVoid DelayForShooting()
        {
            int millisecond = (int)(Weapon.TappedDelay * 1000);
            await UniTask.Delay(millisecond);
            _canShooting = true;
        }
    }
}