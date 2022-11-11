using Invaders.InputSystem;
using Invaders.Movement;

namespace Invaders.Battle
{
    public class PlayerShooterTapping : IPlayerShooter
    {
        private readonly IPlayerLookService _look;
        private readonly IClickedService _clicked;
        private readonly IWeapon _weapon;

        public PlayerShooterTapping(IPlayerLookService look, IClickedService clicked, IWeapon weapon)
        {
            _look = look;
            _clicked = clicked;
            _weapon = weapon;
        }

        public void Enable() =>
            _clicked.OnClicked += Shoot;

        public void Disable() =>
            _clicked.OnClicked -= Shoot;
        
        private void Shoot() =>
            _weapon.Shoot(_look.Direction);
    }
}