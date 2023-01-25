using Cysharp.Threading.Tasks;
using Invaders.Battle;
using System;
using System.Threading;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Environment.Building
{
    public class AmmoBag : MonoBehaviour
    {
        [SerializeField] private Collider _detector;
        [SerializeField][Range(0, 1)] private float _ratioOfTotalAmmo;
        [SerializeField][Min(0)] private float _delay;

        private CancellationTokenSource _tokenSource;
        private CompositeDisposable _disposable;

        private void OnEnable()
        {
            _disposable = new CompositeDisposable();

            _detector
                .OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.TryGetComponent(out IAmmoReplenishable replenishable) == false)
                        return;

                    _tokenSource = new CancellationTokenSource();
                    Replenish(replenishable, _tokenSource.Token).Forget();
                })
                .AddTo(_disposable);

            _detector
                .OnTriggerExitAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.TryGetComponent(out IAmmoReplenishable replenishable) == false)
                        return;

                    _tokenSource.Cancel();
                })
                .AddTo(_disposable);
        }

        private void OnDisable()
        {
            _disposable?.Dispose();
            _tokenSource?.Dispose();
        }

        private async UniTaskVoid Replenish(IAmmoReplenishable replenishable, CancellationToken token)
        {
            int millisecond = (int)(_delay * 1000);

            do
            {
                await UniTask.Delay(millisecond);
                replenishable.Replenish(_ratioOfTotalAmmo);
            }
            while (token.IsCancellationRequested == false);
        }
    }
}