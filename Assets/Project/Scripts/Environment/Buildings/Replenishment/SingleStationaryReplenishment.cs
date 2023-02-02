using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Environment.Buildings
{
    public abstract class SingleStationaryReplenishment<T> : MonoBehaviour
    {
        [SerializeField] private Collider _detector;

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

                    Replenish(replenishment);
                })
                .AddTo(_disposable);
        }

        private void OnDisable() =>
            _disposable?.Dispose();

        protected void Replenish(T replenishable)
        {
            ChangeValue(replenishable);
            Destroy(gameObject);
        }

        protected abstract void ChangeValue(T replenishable);
    }
}