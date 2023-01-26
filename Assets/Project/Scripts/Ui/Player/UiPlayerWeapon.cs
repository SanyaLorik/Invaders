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

        private void ChangeNumberOfBullet(int current, int magazin) =>
            _numberOfBullet.text = $"{current} / {magazin}";

        private void StartAnimtionReloading()
        {
            Debug.Log("Reloading is started.");
        }

        private void ProgressAnimationReloading()
        {

        }

        private void StopAnimationReloading()
        {
            Debug.Log("Reloading is stopped.");
        }
    }
}