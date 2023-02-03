using Invaders.Battle;
using Invaders.Gear;
using System;
using UnityEngine;

namespace Invaders.Task
{
    public class TakenWeaponGuide : Mission
    {
        [SerializeField] private WeaponCarrier _carrier;

        private void OnEnable() =>
            _carrier.OnTaken += OnComplate;

        private void OnDisable() =>
            _carrier.OnTaken += OnComplate;

        private void OnComplate(IThingPortable<IWeapon> _)
        {
            if (IsActivated == false)
                return;

            base.Complate();
        }
    }
}