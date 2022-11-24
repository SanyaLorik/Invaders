using Invaders.InputSystem;
using Invaders.Movement;

namespace Invaders.Battle
{ 
    public abstract class PlayerShooterFire<T> : PlayerShooter<T>
        where T : IWeaponFire
    {
        private readonly IReloaderObserverService _reloader;

        public PlayerShooterFire(IPlayerLookService look, T weapon, IReloaderObserverService reloader) : base(look, weapon) =>
            _reloader = reloader;

        public override void Disable() =>
             _reloader.OnReloaded += Weapon.Reload;

        public override void Enable() =>
             _reloader.OnReloaded += Weapon.Reload;
    }
}