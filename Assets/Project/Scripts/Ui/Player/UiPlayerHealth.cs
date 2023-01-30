using Invaders.Additionals;
using TMPro;
using UnityEngine;
using Zenject;

namespace Invaders.Ui
{
    public class UiPlayerHealth : MonoBehaviour
    {
        [SerializeField] private TMP_Text _health;

        private IValueObserver<int, int> _healthObserver;

        [Inject]
        private void Construct(IValueObserver<int, int> healthObserver) =>
            _healthObserver = healthObserver;

        private void OnEnable() =>
            _healthObserver.OnChanged += OnShowChangeHealth;

        private void OnDisable() =>
            _healthObserver.OnChanged -= OnShowChangeHealth;

        private void OnShowChangeHealth(int remaining, int total) =>
            _health.text = $"HP {remaining}/{total}";
    }
}