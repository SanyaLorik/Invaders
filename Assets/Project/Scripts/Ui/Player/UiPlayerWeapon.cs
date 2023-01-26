using Invaders.Battle;
using TMPro;
using UnityEngine;
using Zenject;

namespace Invaders.Ui
{
    public class UiPlayerWeapon : MonoBehaviour
    {
        [SerializeField] private TMP_Text _numberOfBullet;

        private IWeaponAmmoInformationObserver _ammo;
        private IWeaponReloadingInformationObserver _reloaded;

        /*
        [Inject]
        private void Construct(IWeaponAmmoInformationProvider ammo, IWeaponReloadedInformationProvider reloaded)
        {
            _ammo = ammo;
            _reloaded = reloaded;
        }

        private void OnEnable()
        {
            _ammo.OnNumberOfBulletChanged += ChangeNumberOfBullet;

            _reloaded.OnStartReloaded += StartAnimtionReloading;
            _reloaded.OnStopReloaded += StopAnimationReloading;
        }

        private void OnDisable()
        {
            _ammo.OnNumberOfBulletChanged -= ChangeNumberOfBullet;

            _reloaded.OnStartReloaded -= StartAnimtionReloading;
            _reloaded.OnStopReloaded -= StopAnimationReloading;
        }
        */

        private void ChangeNumberOfBullet(int current, int magazin) =>
            _numberOfBullet.text = $"{current} / {magazin}";

        private void StartAnimtionReloading()
        {

        }

        private void ProgressAnimationReloading()
        {

        }

        private void StopAnimationReloading()
        {

        }
    }
}