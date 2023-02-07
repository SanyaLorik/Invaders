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

        private AudioSource _audioSource;

        private void Awake() =>
            _audioSource = GetComponent<AudioSource>();

        public bool IsPlayed { get; private set; } = false;

        public bool IsAllow { get; private set; } = true;

        public void Use()
        {
            if (IsAllow == false)
                return;

            if (IsPlayed == true)
                Stop();
            else
                Play();

            IsPlayed = !IsPlayed;
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
        }
    }
}