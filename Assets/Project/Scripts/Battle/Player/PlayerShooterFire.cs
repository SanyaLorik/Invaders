using Invaders.InputSystem;
using Invaders.Movement;

namespace Invaders.Battle
{
    public abstract class PlayerShooterFire<T> : PlayerShooter<T>
        where T : IWeaponFire
    {
        private readonly IWeaponReloaderService _reloader;

        public PlayerShooterFire(IPlayerLookService look, T weapon, IWeaponReloaderService reloader) : base(look, weapon) =>
            _reloader = reloader;

        public override void Enable() =>
             _reloader.OnWeaponReloaded += Weapon.Reload;

        public override void Disable()
        {
            _reloader.OnWeaponReloaded -= Weapon.Reload;
            Weapon.BreakReload();
        }
    }
}