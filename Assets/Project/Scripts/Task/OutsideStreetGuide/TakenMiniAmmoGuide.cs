using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Invaders.Task
{
    public class TakenMiniAmmoGuide : Mission
    {
        [SerializeField] private GameObject _miniAmmomBag;

        private CancellationTokenSource _tokenSource;

        private void OnEnable()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            UniTask.Create(async () =>
            {
                await UniTask.WaitWhile(() => _miniAmmomBag != null, cancellationToken: token);
                base.Complate();
            });
        }

        private void OnDisable()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}