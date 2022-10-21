using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Environment
{
    public class Bonfire : MonoBehaviour
    {
        [SerializeField] private Collider _warming;
        [SerializeField] private Collider _damaging;

        private CompositeDisposable _disposable;
        
        private void OnEnable()
        {
            _disposable = new CompositeDisposable();
            
            _warming
                .OnCollisionEnterAsObservable()
                .Subscribe(collision =>
                {
                    
                })
                .AddTo(_disposable);
        }

        private void OnDisable()
        {
            _disposable?.Dispose();
        }
    }
}