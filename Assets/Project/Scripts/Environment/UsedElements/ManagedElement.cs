using DG.Tweening;
using UnityEngine;

namespace Invaders.Environment.UsedElements
{
    public abstract class ManagedElement : MonoBehaviour 
    {
        [SerializeField] private ManagementElement _managementElement;

        [field: SerializeField][field: Range(0f, 60f)] protected float Duration { get; private set; }

        private Tween _tween;

        private bool _isOpened = false;

        private void OnEnable() =>
            _managementElement.OnUsed += OnOpenOrClose;

        private void OnDisable() =>
            _managementElement.OnUsed -= OnOpenOrClose;

        private void OnOpenOrClose()
        {
            _tween?.Kill();
            _tween = _isOpened == true ? Open() : Close();
            //_tween.Play();

            _isOpened = !_isOpened;
        }

        protected abstract Tween Open();

        protected abstract Tween Close();
    }
}