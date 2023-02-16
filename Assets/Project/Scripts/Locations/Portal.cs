using Cysharp.Threading.Tasks;
using Invaders.Additionals;
using Invaders.Entities;
using System;
using System.Threading;
using UnityEngine;

namespace Invaders.Locations
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField][Range(0f, 2f)] private float _duration;

        private Transform _player;
        private CancellationTokenSource _tokenSource;

        private void OnDisable() =>
             _tokenSource?.Cancel();

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>() == null)
                return;

            _player = other.transform;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IPlayer>() == null)
                return;

            _player = null; 
            _tokenSource?.Cancel();
        }

        protected void Telepot()
        {
            if (_player == null)
                return;

            _tokenSource = new CancellationTokenSource();
            DelayTeleport(_tokenSource.Token, _player.transform).Forget();
        }

        private async UniTask DelayTeleport(CancellationToken token, Transform entity)
        {
            int delay = _duration.DelayMillisecond();

            await UniTask.Delay(delay, cancellationToken: token);
            entity.position = _point.position;
        }
    }
}