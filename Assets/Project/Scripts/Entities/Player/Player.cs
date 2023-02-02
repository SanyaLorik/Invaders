using Invaders.Pysiol;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour, IPlayer
    {
        private IPhysiology<int> _health;

        [Inject]
        private void Construct(IPhysiology<int> heath) =>
            _health = heath;

        public Health Value => _health as Health;

        public Vector3 Direction => transform.forward;

        public bool IsAllowReplenished => true;

        public void Damage(int damage) =>
            _health.TakeAway(damage);
    }
}