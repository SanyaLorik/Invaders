using Cysharp.Threading.Tasks;
using Invaders.Additionals;
using Invaders.Entities;
using System;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IPlayer>() != null)
                _player = other.transform;
        }

        protected void Telepot()
        {
            if (_player != null)
                DelayTeleport(_player).Forget();
        }

        private async UniTask DelayTeleport(Transform entity)
        {
            int delay = _duration.DelayMillisecond();

            await UniTask.Delay(delay);
            entity.position = _point.position;
        }
    }
}