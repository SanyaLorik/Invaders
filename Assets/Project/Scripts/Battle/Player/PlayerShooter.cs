using Invaders.Movement;

namespace Invaders.Battle
{
    public abstract class PlayerShooter<T> : IPlayerShooter
        where T : IWeapon
    {
        private readonly IPlayerLookService _look;

        public PlayerShooter(IPlayerLookService look, T weapon)
        {
            _look = look;
            Weapon = weapon;
        }

        protected T Weapon { get; private set; }

        protected void Shoot() =>
            Weapon.Shoot(_look.Direction);

        public abstract void Disable();

        public abstract void Enable();
    }
}