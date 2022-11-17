using Invaders.Battle;
using Invaders.InputSystem;
using Invaders.Movement;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    [RequireComponent(typeof(IPlayerLookService))]
    public class PlayerWeaponBearer : WeaponBearer
    {
        private IPlayerLookService _look;
        private IPlayerShooter _shooter;
        private IClickedService _clicked;
        private IHolderService _holder;

        [Inject]
        private void Construct(IHolderService holderService, IClickedService clicked)
        {
            _clicked = clicked;
            _holder = holderService;
        }

        private void Awake() =>
            _look = GetComponent<IPlayerLookService>();

        private void OnDisable() =>
            _shooter?.Disable();

        protected override void Take(IWeapon weapon)
        {
            base.Take(weapon);

            _shooter = weapon as IWeaponRapidFire == null ?
                new PlayerShooterTapping(_look, _clicked, weapon) : 
                new PlayerShooterHolding(_look, _holder, weapon as IWeaponRapidFire);

            _shooter.Enable();
        }
    }
}