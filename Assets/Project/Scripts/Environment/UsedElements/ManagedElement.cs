using DG.Tweening;
using UnityEngine;

namespace Invaders.Environment.UsedElements
{
    public abstract class ManagedElement : MonoBehaviour 
    {
        [SerializeField] private ManagementElement _managementElement;

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
            _isOpened = !_isOpened;
        }

        protected abstract Tween Open();

        protected abstract Tween Close();
    }
}