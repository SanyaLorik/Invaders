using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Gear
{
    public class Carrier : MonoBehaviour
    {
        [SerializeField] private Collider _detector;
        [SerializeField] private Transform _carrier;

        private readonly IList<CarrierContainer> _portables = new List<CarrierContainer>();
        private CarrierContainer? _portable;

        private CompositeDisposable _disposable;

        private void OnEnable()
        {
            _disposable = new CompositeDisposable();

            _detector
               .OnTriggerEnterAsObservable()
               .Subscribe(collision =>
               {
                   if (collision.TryGetComponent(out IItem item) == false)
                       return;

                   _portables.Add(new CarrierContainer(item, collision.transform));
               })
               .AddTo(_disposable);

            _detector
               .OnTriggerExitAsObservable()
               .Subscribe(collision =>
               {
                   if (collision.TryGetComponent(out IItem portable) == false)
                       return;

                   CarrierContainer container = _portables.FirstOrDefault(i => i.Portable.Equals(portable));
                   _portables.Remove(container);
               })
               .AddTo(_disposable);
        }

        private void OnDisable() =>
            _disposable?.Dispose();

        public T Take()
        {
            _portable = _portables[0];

            Fix(_portable?.Position);

            return _portable.Value.Portable;
        }

        private void Fix(Transform portable)
        {
            portable.SetParent(_carrier);
            portable.transform.localPosition = Vector3.zero;
            portable.transform.localRotation = Quaternion.identity;
        }
    }
}