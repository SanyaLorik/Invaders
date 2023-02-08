using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Invaders.Task
{
    public class RadioDestroyer : Mission
    {
        [SerializeField] private GameObject _radio;

        private CancellationTokenSource _tokenSource;

        private void OnEnable()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            UniTask.Create(async () =>
            {
                await UniTask.WaitWhile(() => _radio.activeSelf == true, cancellationToken: token);
                base.Complate();
            });
        }

        private void OnDisable() =>
            _tokenSource?.Cancel();
    }
}