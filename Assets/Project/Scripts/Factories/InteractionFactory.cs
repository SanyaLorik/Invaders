using Invaders.Battle;
using Invaders.Gear;
using Invaders.InputSystem;
using Invaders.Movement;
using Zenject;

namespace Invaders.Factories
{
    public class InteractionFactory : PlaceholderFactory<IItem, IPlayerInteractableHandler>, IFactory<IItem, IPlayerInteractableHandler>
    {
        private IPlayerLookService _look;
        private IClickedService _clicked;
        private IHolderService _holder;
        private IWeaponReloaderService _reloader;

        [Inject]
        public InteractionFactory(IPlayerLookService look, IHolderService holder, IClickedService clicked, IWeaponReloaderService reloader)
        {
            _look = look;
            _clicked = clicked;
            _holder = holder;
            _reloader = reloader;
        }

        public override IPlayerInteractableHandler Create(IItem item)
        {
            if (item is IWeaponFire weapon)
            {
                IPlayerInteractableHandler shooter = weapon as IWeaponRapidFire == null ?
                   new PlayerShooterTapping(_look, weapon as IWeaponTappingFire, _reloader, _clicked) :
                   new PlayerShooterHolding(_look, weapon as IWeaponRapidFire, _reloader, _holder);

                return shooter;
            }

            return null;
        }
    }
}
