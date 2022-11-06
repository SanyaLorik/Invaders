using Invaders.Effect;
using Invaders.Pysiol;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Invaders.Environment
{
    public class Bonfire : MonoBehaviour
    {
        [Header("Warming")]
        [SerializeField] private Collider _warming;
        [SerializeField] [Min(0)] private int _warmingAmount;
        [SerializeField] [Min(0)] private int _delayMillisecondWarming;
        
        [Header("Burning")]
        [SerializeField] private Collider _damaging;
        [SerializeField] [Min(0)] private int _damage;
        [SerializeField] [Min(0)] private int _delayMillisecondBurning;

        private IEffect _arson;
        private IEffect _warmed;
        
        private CompositeDisposable _disposable;
        
        private void OnEnable()
        {
            _disposable = new CompositeDisposable();
            
            _warming
                .OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.transform.TryGetComponent(out IValueProvider<Temperature> temperature) == false)
                        return;
                    
                    Warmup(temperature.Value);
                })
                .AddTo(_disposable);
            
            _warming
                .OnTriggerExitAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.transform.TryGetComponent(out IValueProvider<Temperature> temperature) == false)
                        return;
                    
                    _warmed?.Stop();
                })
                .AddTo(_disposable);
            
            _damaging
                .OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.transform.TryGetComponent(out IDamageable<int> arsonable) == false)
                        return;
                    
                    Burn(arsonable);
                })
                .AddTo(_disposable);
            
            _damaging
                .OnTriggerExitAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.transform.TryGetComponent(out IDamageable<int> arsonable) == false)
                        return;
                    
                    _arson?.Stop();
                })
                .AddTo(_disposable);
        }

        private void OnDisable()
        { 
            _disposable?.Dispose();
            _arson?.Stop();
            _warmed?.Stop();
        }

        private void Burn(IDamageable<int> damageable)
        {
            _arson = new Arson(damageable, _damage, _delayMillisecondBurning);
            _arson.Start();
        }

        private void Warmup(Physiology temperature)
        {
            _warmed = new Heater(temperature, _warmingAmount, _delayMillisecondWarming);
            _warmed.Start();
        }
    }
}