using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace Invaders.Environment.Global
{
    public class GlobalCoverageTimer : IGlobalCoverageGapObserver, IGlobalCoverageTimerObserver
    {
        public event Action OnDayCame = delegate { };
        public event Action OnNightCame = delegate { };
        public event Action<int, int> OnStepInterval = delegate { };

        private readonly int _dayMinute;
        private readonly int _nightMinute;

        private readonly TimeSpan _interval = TimeSpan.FromSeconds(1);
        private CancellationTokenSource _tokenSource;

        public GlobalCoverageTimer(int dayMinute, int nightMinute)
        {
            _dayMinute = dayMinute;
            _nightMinute = nightMinute;
        }

        ~GlobalCoverageTimer()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public async UniTaskVoid StartTimer()
        {
            int daySecond = _dayMinute * 60;
            int nightSecond = _nightMinute * 60;

            int totalSecond = daySecond + nightSecond;
            int counterSecond = 0;

            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            do
            {
                OnDayCame.Invoke();
                for (int i = 0; i < daySecond; i++)
                {
                    counterSecond++;
                    OnStepInterval.Invoke(counterSecond, totalSecond);

                    await UniTask.Delay(_interval, cancellationToken: token);
                }

                OnNightCame.Invoke();
                for (int i = 0; i < nightSecond; i++)
                {
                    counterSecond++;
                    OnStepInterval.Invoke(counterSecond, totalSecond);

                    await UniTask.Delay(_interval, cancellationToken: token);
                }

                counterSecond = 0;
            } 
            while (true);
        }

        public void StopTimer() =>
            _tokenSource?.Cancel();
    }
}