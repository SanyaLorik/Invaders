using System.Threading;
using Cysharp.Threading.Tasks;
using Invaders.Pysiol;

namespace Invaders.Effect
{
    public class Heater : IEffect
    {
        private readonly PhysiologyBase _temperature;
        private readonly int _warmingAmount;
        private readonly int _delay;

        private CancellationTokenSource _tokenSource;
        
        public Heater(PhysiologyBase temperature, int warmingAmount, int delayMillisecond)
        {
            _temperature = temperature;
            _warmingAmount = warmingAmount;
            _delay = delayMillisecond;
        }

        public void Start()
        {
            _tokenSource = new CancellationTokenSource();
            Warmup(_tokenSource.Token).Forget();
        }

        public void Stop() =>
            _tokenSource?.Cancel();

        private async UniTaskVoid Warmup(CancellationToken tokenSourceToken)
        {
            do
            {
                _temperature.Add(_warmingAmount);
                await UniTask.Delay(_delay, cancellationToken: tokenSourceToken);
            } while (tokenSourceToken.IsCancellationRequested == false);
        }
    }
}