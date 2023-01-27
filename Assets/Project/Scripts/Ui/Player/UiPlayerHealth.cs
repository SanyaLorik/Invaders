using Invaders.Additionals;
using UnityEngine;
using Zenject;

namespace Invaders.Ui
{
    public class UiPlayerHealth : MonoBehaviour
    {
        private IValueObserver<int, int> _healthObserver;

        [Inject]
        private void Construct(IValueObserver<int, int> healthObserver) =>
            _healthObserver = healthObserver;

        private void OnEnable() =>
            _healthObserver.OnChanged += OnShowChangeHealth;

        private void OnDisable() =>
            _healthObserver.OnChanged -= OnShowChangeHealth;

        private void OnShowChangeHealth(int remaining, int total)
        {
            Debug.Log(remaining + " " + total);
        }
    }
}