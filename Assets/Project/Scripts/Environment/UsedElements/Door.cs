using DG.Tweening;
using UnityEngine;

namespace Invaders.Environment.UsedElements
{
    public class Door : ManagedElement
    {
        [SerializeField] private Transform _target;
        [SerializeField][Range(0, 90)] private float _angle;

        protected override Tween Open()
        {
            Vector3 opened = new Vector3(0, _angle, 0);
            return _target.DORotate(opened, Duration);
        }

        protected override Tween Close()
        {
            Vector3 closed = Vector3.zero;
            return _target.DORotate(closed, Duration);
        }
    }
}