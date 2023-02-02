using Cysharp.Threading.Tasks;
using Invaders.Battle;
using System.Threading;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Environment.Buildings
{
    public abstract class StationaryReplenishment<T> : MonoBehaviour
        where T : IReplenishment
    {
        [SerializeField] private Collider _detector;
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
                    if (collision.TryGetComponent(out T replenishment) == false)
                        return;

                    _tokenSource = new CancellationTokenSource();
                    Replenish(replenishment, _delay, _tokenSource.Token).Forget();
                })
                .AddTo(_disposable);

            _detector
                .OnTriggerExitAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.TryGetComponent(out IAmmoReplenishable replenishment) == false)
                        return;

                    _tokenSource.Cancel();
                })
                .AddTo(_disposable);
        }

        private void OnDisable()
        {
            _disposable?.Dispose();

            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        protected async UniTaskVoid Replenish(T replenishable, float delay, CancellationToken token)
        {
            int millisecond = (int)(delay * 1000);

            do
            {
                await UniTask.WaitWhile(() => replenishable.IsAllowReplenished == false, cancellationToken: token);
                await UniTask.Delay(millisecond, cancellationToken: token);

                ChangeValue(replenishable);
            }
            while (token.IsCancellationRequested == false);
        }

        protected abstract void ChangeValue(T replenishable);
    }
}