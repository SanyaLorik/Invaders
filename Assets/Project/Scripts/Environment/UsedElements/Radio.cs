using Invaders.Pysiol;
using System;
using UnityEngine;

namespace Invaders.Environment.UsedElements
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(AudioSource))]
    public class Radio : MonoBehaviour, IUsedElement, IDamageable<int>
    {
        [SerializeField] private GameObject _model;
        [SerializeField] private Rigidbody _part1;
        [SerializeField] private Rigidbody _part2;
        [SerializeField][Range(0f, 10f)] private float _force;

        private AudioSource _audioSource;

        private bool _isPlayed = false;

        private void Awake() =>
            _audioSource = GetComponent<AudioSource>();

        public bool IsAllow { get; private set; } = true;

        public void Use()
        {
            if (IsAllow == false)
                return;

            if (_isPlayed == true)
                Stop();
            else
                Play();

            _isPlayed = !_isPlayed;
        }

        private void Play() =>
            _audioSource.Play();

        private void Stop() =>
            _audioSource.Stop();

        public void Damage(int damage)
        {
            IsAllow = false;
            Stop();
            Break();
        }

        private void Break()
        {
            _model.SetActive(false);

            _part1.gameObject.SetActive(true);
            _part2.gameObject.SetActive(true);
            /*
            _part1.AddForce((Vector3.up + Vector3.left) * _force, ForceMode.Impulse);
            _part2.AddForce((Vector3.up + Vector3.right) * _force, ForceMode.Impulse);*/
        }
    }
}