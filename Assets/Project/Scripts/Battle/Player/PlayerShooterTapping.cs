using Cysharp.Threading.Tasks;
using Invaders.InputSystem;
using Invaders.Movement;

namespace Invaders.Battle
{
    public class PlayerShooterTapping : IPlayerShooter
    {
        private readonly IPlayerLookService _look;
        private readonly IClickedService _clicked;
        private readonly IWeaponTappingFire _weapon;

        private bool _canShooting = true;

        public PlayerShooterTapping(IPlayerLookService look, IClickedService clicked, IWeaponTappingFire weapon)
        {
            _look = look;
            _clicked = clicked;
            _weapon = weapon;
        }

        public void Enable() =>
            _clicked.OnClicked += Shoot;

        public void Disable() =>
            _clicked.OnClicked -= Shoot;

        private void Shoot()
        {
            if (_canShooting == false)
                return;

            _weapon.Shoot(_look.Direction);
            DelayShoot().Forget();

            _canShooting = false;
        }

        private async UniTaskVoid DelayShoot()
        {
            int millisecond = (int)(_weapon.TappedDelay * 1000);
            await UniTask.Delay(millisecond);
            _canShooting = true;
        }
    }
}