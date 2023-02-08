using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Invaders.Task
{
    public class OpeningDoorGuide : Mission
    {
        [SerializeField] private Transform _door;
        [SerializeField] private float _angeY;

        private CancellationTokenSource _tokenSource;

        private void OnEnable()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            UniTask.Create(async () =>
            {
                await UniTask.WaitWhile(() => _door.eulerAngles.y <= _angeY, cancellationToken: token);
                base.Complate();
            });
        }

        private void OnDisable() =>
            _tokenSource?.Cancel();
    }
}