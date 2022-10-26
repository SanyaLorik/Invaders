using System.Threading;
using Cysharp.Threading.Tasks;
using Invaders.Pysiol;

namespace Invaders.Effect
{
    public class Arson : IEffect
    {
        private readonly IDamageable<int> _damageable;
        private readonly int _damage;
        private readonly int _delay;

        private CancellationTokenSource _tokenSource;
        
        public Arson(IDamageable<int> damageable, int damage, int delayMillisecond)
        {
            _damage = damage;
            _damageable = damageable;
            _delay = delayMillisecond;
        }

        public void Start()
        {
            _tokenSource = new CancellationTokenSource();
            Burn(_tokenSource.Token).Forget();
        }

        public void Stop() =>
            _tokenSource?.Cancel();

        private async UniTaskVoid Burn(CancellationToken tokenSourceToken)
        {
            do
            {
                _damageable.Damage(_damage);
                await UniTask.Delay(_delay, cancellationToken: tokenSourceToken);
            } while (tokenSourceToken.IsCancellationRequested == false);
        }
    }
}