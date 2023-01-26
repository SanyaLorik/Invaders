using Invaders.Additionals;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Gear
{
    public abstract class Carrier<T> : MonoBehaviour, ICarrier<T>, ICarrierObserver<T>
        where T: IPortable
    {
        [SerializeField] private Collider _detector;
        [SerializeField] private Transform _carrier;

        public event Action<T> OnTaken = delegate { };
        public event Action OnDropped = delegate { };

        private readonly IList<CarrierContainer<T>> _portables = new List<CarrierContainer<T>>();
        private CarrierContainer<T>? _portable;

        private CompositeDisposable _disposable;


        private void OnEnable()
        {
            _disposable = new CompositeDisposable();

            _detector
               .OnTriggerEnterAsObservable()
               .Subscribe(collision =>
               {
                   if (collision.TryGetComponent(out T portable) == false)
                       return;

                   _portables.Add(new CarrierContainer<T>(portable, collision.transform));
               })
               .AddTo(_disposable);

            _detector
               .OnTriggerExitAsObservable()
               .Subscribe(collision =>
               {
                   if (collision.TryGetComponent(out T portable) == false)
                       return;

                   CarrierContainer<T> container = _portables.FirstOrDefault(i => i.Portable.Equals(portable));
                   _portables.Remove(container);
               })
               .AddTo(_disposable);
        }

        private void OnDisable() =>
            _disposable?.Dispose();

        public bool IsNearbyPortable => _portables.Count != 0;

        public bool HasPortable => _portable != null;

        public T Take()
        {
            _portable = _portables[0];
            _portable?.Portable.Take();

            Fix(_portable?.Position);

            OnTaken.Invoke(_portable.Value.Portable);

            return _portable.Value.Portable;
        }

        public void Drop(Vector3 direction)
        {
            OnDropped.Invoke();

            _portable?.Portable.Throw(direction);
            _portables.Remove(_portable.Value);
            _portable = null;
        }

        private void Fix(Transform portable)
        {
            portable.SetParent(_carrier);
            portable.transform.localPosition = Vector3.zero;
            portable.transform.localRotation = Quaternion.identity;
        }
    }
}