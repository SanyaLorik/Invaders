using Cysharp.Threading.Tasks;
using Invaders.InputSystem;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Invaders.Task
{
    public class MovementPlayerGuide : Mission
    {
        [SerializeField][Range(1f, 5f)] private float _timeMovement;

        private IMovementService _movement;
        private CancellationTokenSource _tokenSource;

        [SerializeField] private float _timeLocating = 0;

        [Inject]
        private void Construct(IMovementService movement) =>
            _movement = movement;

        private void OnEnable()
        {
            _movement.OnMove += OnStartLocateMovement;
            _movement.OnStopped += OnStopLocateMovement;
        }

        private void OnDisable()
        {
            _movement.OnMove -= OnStartLocateMovement;
            _movement.OnStopped -= OnStopLocateMovement;

            _tokenSource?.Cancel();
        }

        private void OnStartLocateMovement(Vector3 _)
        {
            if (IsDone == true)
                return;

            _tokenSource?.Cancel();
            _tokenSource = new CancellationTokenSource();
            ProssecLocateMovement(_tokenSource.Token).Forget();
        }

        private void OnStopLocateMovement() =>
            _tokenSource?.Cancel();

        private async UniTaskVoid ProssecLocateMovement(CancellationToken token)
        {
            do
            {
                float deltaTime = Time.deltaTime;
                _timeLocating += deltaTime;

                int delay = (int)(deltaTime * 1000);
                await UniTask.Delay(delay, cancellationToken: token);
            }
            while (_timeLocating <= _timeMovement);

            base.Complate();
        }
    }
}