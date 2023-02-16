using System;
using UnityEngine;

namespace Invaders.Ui
{
    [Serializable]
    public struct UiConfirmation
    {
        [SerializeField] private GameObject _panel;

        public void Show() =>
            _panel.SetActive(true);

        public void Hide() =>
            _panel.SetActive(false);
    }
}