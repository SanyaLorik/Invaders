using DG.Tweening;
using UnityEngine;

namespace Invaders.Task
{
    public class MissionPointer : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField][Min(0)] private float _duration;
        [SerializeField][Min(0)] private float _strenght;

        private Tween _tween;

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide()
        {
            gameObject.SetActive(false);
            _tween?.Kill();
        }

        public void Point(Transform mission)
        {
            transform.position = mission.position;
            transform.localPosition += _offset;

            _tween?.Kill();
            Move();
        }

        private void Move() =>
            _tween = transform.DOShakePosition(_duration, _strenght);
    }
}