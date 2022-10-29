using System;
using UnityEngine;

namespace Invaders.Battle
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class HandgunBullet : MonoBehaviour, IMissile
    {
        private void Awake() =>
            Rigidbody = GetComponent<Rigidbody>();

        public Rigidbody Rigidbody { get; private set; }
    }
}