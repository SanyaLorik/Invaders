using DG.Tweening;
using Invaders.Additionals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Invaders.Ui
{
    public class UiPlayerHealth : MonoBehaviour
    {
        [SerializeField] private TMP_Text _health;
        [SerializeField] private Image _progresColorBar;
        [SerializeField] private Color _initial;
        [SerializeField] private Color _final;

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
            _health.text = remaining.ToString();
            ChangeColor(remaining, total);
        }

        private void ChangeColor(int remaining, int total)
        {
            Color color = Color.Lerp(_initial, _final, 1 / remaining / total);
            const float duration = 1f;

            _progresColorBar.DOColor(color, duration);
        }
    }
}