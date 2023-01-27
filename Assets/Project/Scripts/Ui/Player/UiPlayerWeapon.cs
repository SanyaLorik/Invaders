using Cysharp.Threading.Tasks;
using Invaders.Battle;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Invaders.Ui
{
    public class UiPlayerWeapon : MonoBehaviour
    {
        [SerializeField] private TMP_Text _numberOfBullet;
        [SerializeField] private Image _reloadingStatus;

        private IWeaponAmmoObserver _ammoObserver;
        private IWeaponReloadingObserver _reloadedObserver;

        private CancellationTokenSource _cancellationToken;

        [Inject]
        private void Construct(IWeaponAmmoObserver ammo, IWeaponReloadingObserver reloaded)
        {
            _ammoObserver = ammo;
            _reloadedObserver = reloaded;
        }

        private void OnEnable()
        {
            _ammoObserver.OnNumberOfBulletChanged += OnShowChangingNumberOfBullet;
            _ammoObserver.OnOutOfAmmo += OnShowOutOfAmmo;

            _reloadedObserver.OnReloadingStarted += OnStartAnimtionReloading;
            _reloadedObserver.OnReloadingStopped += OnStopAnimationReloading;
        }

        private void OnDisable()
        {
            _ammoObserver.OnNumberOfBulletChanged -= OnShowChangingNumberOfBullet;
            _ammoObserver.OnOutOfAmmo -= OnShowOutOfAmmo;

            _reloadedObserver.OnReloadingStarted -= OnStartAnimtionReloading;
            _reloadedObserver.OnReloadingStopped -= OnStopAnimationReloading;

            _cancellationToken?.Cancel();
            _cancellationToken?.Dispose();
        }

        private void OnShowChangingNumberOfBullet(int current, int magazin) =>
            _numberOfBullet.text = $"{current} / {magazin}";


        private void OnShowOutOfAmmo() =>
             _numberOfBullet.text = $"Патроны кончились";

        private void OnStartAnimtionReloading()
        {
            Debug.Log("Reloading is started.");

            _reloadingStatus.fillAmount = 0;
            _cancellationToken = new CancellationTokenSource();
            ProgressAnimationReloading(_cancellationToken.Token).Forget();
        }

        private void OnStopAnimationReloading()
        {
            Debug.Log("Reloading is stopped.");

            _reloadingStatus.fillAmount = 0;
            _cancellationToken?.Cancel();
        }

        private async UniTaskVoid ProgressAnimationReloading(CancellationToken token)
        {
            float expandedTime = 0f;
            float reloadedTime = _reloadedObserver.ReloadedTime;

            do
            {
                float ratio = expandedTime / reloadedTime;
                _reloadingStatus.fillAmount = ratio;

                expandedTime += Time.deltaTime;
                await UniTask.DelayFrame(1, cancellationToken: token);
            } 
            while (expandedTime < reloadedTime);
        }
    }
}