using Cysharp.Threading.Tasks;
using Invaders.Environment.UsedElements;
using System.Threading;
using UnityEngine;

namespace Invaders.Task
{
    public class RadioActivator : Mission
    {
        [SerializeField] private Radio _radio;
        [SerializeField] private GameObject _wholeRadio;

        private CancellationTokenSource _tokenSource;

        private void OnEnable()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            UniTask player = UniTask.Create(async () =>
            {
                await UniTask.WaitWhile(() => _radio.IsPlayed == false, cancellationToken: token);
                await UniTask.Delay(2000, cancellationToken: token); // 2000 - delay for listing music
            });

            UniTask destroyed = UniTask.Create(async () =>
                await UniTask.WaitWhile(() => _wholeRadio.activeSelf == true, cancellationToken: token));

            UniTask.Create(async () =>
            {
                await UniTask.WhenAny(player, destroyed);
                base.Complate();
            });
        }

        private void OnDisable() =>
            _tokenSource?.Cancel();
    }
}