using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Environment.Buildings
{
    public abstract class SingleStationaryReplenishment<T> : MonoBehaviour
        where T : IReplenishment
    {
        [SerializeField] private Collider _detector;

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
                    Replenish(replenishment, _tokenSource.Token).Forget();
                })
                .AddTo(_disposable);
        }

        private void OnDisable()
        {
            _disposable?.Dispose();

            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        protected async UniTaskVoid Replenish(T replenishable, CancellationToken token)
        {
            await UniTask.WaitWhile(() => replenishable.IsAllowReplenished == false, cancellationToken: token);

            ChangeValue(replenishable);
            Destroy(gameObject);
        }

        protected abstract void ChangeValue(T replenishable);
    }
}