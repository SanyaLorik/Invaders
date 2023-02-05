﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Invaders.Ui
{
    public class VisableScreen : MonoBehaviour 
    {
        [SerializeField] private Image _screen;
        [SerializeField] private Color _ascended;
        [SerializeField] private Color _faded;
        [SerializeField][Range(0f, 3f)] private float _duration;

        public void Ascend() =>
            _screen.DOColor(_ascended, _duration).OnComplete(() => _screen.gameObject.SetActive(true));

        public void Fade() =>
            _screen.DOColor(_faded, _duration).OnComplete(() => _screen.gameObject.SetActive(true));
    }
}