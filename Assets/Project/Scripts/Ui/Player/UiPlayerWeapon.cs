using Invaders.Battle;
using TMPro;
using UnityEngine;
using Zenject;

namespace Invaders.Ui
{
    public class UiPlayerWeapon : MonoBehaviour
    {
        [SerializeField] private TMP_Text _numberOfBullet;

        private IWeaponAmmoObserver _ammo;
        private IWeaponReloadingObserver _reloaded;

        [Inject]
        private void Construct(IWeaponAmmoObserver ammo, IWeaponReloadingObserver reloaded)
        {
            _ammo = ammo;
            _reloaded = reloaded;
        }

        private void OnEnable()
        {
            _ammo.OnNumberOfBulletChanged += OnShowChangingNumberOfBullet;
            _ammo.OnOutOfAmmo += OnShowOutOfAmmo;

            _reloaded.OnStartReloaded += OnStartAnimtionReloading;
            _reloaded.OnStopReloaded += OnStopAnimationReloading;
        }

        private void OnDisable()
        {
            _ammo.OnNumberOfBulletChanged -= OnShowChangingNumberOfBullet;
            _ammo.OnOutOfAmmo -= OnShowOutOfAmmo;

            _reloaded.OnStartReloaded -= OnStartAnimtionReloading;
            _reloaded.OnStopReloaded -= OnStopAnimationReloading;
        }

        private void OnShowChangingNumberOfBullet(int current, int magazin) =>
            _numberOfBullet.text = $"{current} / {magazin}";


        private void OnShowOutOfAmmo() =>
             _numberOfBullet.text = $"Патроны кончились";

        private void OnStartAnimtionReloading()
        {
            Debug.Log("Reloading is started.");
        }

        private void OnStopAnimationReloading()
        {
            Debug.Log("Reloading is stopped.");
        }

        private void ProgressAnimationReloading()
        {

        }
    }
}