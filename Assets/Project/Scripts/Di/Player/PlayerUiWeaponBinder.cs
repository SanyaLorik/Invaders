﻿using Invaders.Battle;
using Invaders.Gear;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerUiWeaponBinder : MonoInstaller
    {
        [SerializeField] private PlayerSpawner _spawner;
        
        private PlayerWeaponUiObserver _information;

        public override void InstallBindings()
        {
            ICarrierObserver<IThingPortable<IWeapon>> weaponCarrier = _spawner.SpawnedPlayer.GetComponent<ICarrierObserver<IThingPortable<IWeapon>>>();
            _information = new PlayerWeaponUiObserver(weaponCarrier);

            BindAmmoInformationObserver();
            BindReloadingInformationObserver();
            BindHavingObserver();
        }

        private void BindAmmoInformationObserver()
        {
            Container
                .Bind<IWeaponAmmoObserver>()
                .FromInstance(_information)
                .AsCached()
                .NonLazy();
        }

        private void BindReloadingInformationObserver()
        {
            Container
                .Bind<IWeaponReloadingObserver>()
                .FromInstance(_information)
                .AsCached()
                .NonLazy();
        }

        private void BindHavingObserver()
        {
            Container
               .Bind<IWeaponHavingObserver>()
               .FromInstance(_information)
               .AsCached()
               .NonLazy();
        }
    }
}