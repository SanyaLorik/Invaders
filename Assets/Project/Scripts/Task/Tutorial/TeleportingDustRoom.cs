using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Invaders.Task
{
    public class TeleportingDustRoom : Mission
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _teleportPoint;

        private CancellationTokenSource _tokenSource;

        private void OnEnable()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            UniTask.Create(async () =>
            {
                await UniTask.WaitWhile(() => _teleportPoint.position != _player.position, cancellationToken: token);
                base.Complate();
            });
        }

        private void OnDisable() =>
            _tokenSource?.Cancel();
    }
}