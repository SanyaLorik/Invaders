using Invaders.Pysiol;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

namespace Invaders.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour, IDamageable<int>
    {
        [SerializeField] private Collider _playerDetector;
        [SerializeField][Min(0)] private int _initialHealth;
        [SerializeField][Min(0)] private int _maximumHealth;
        [SerializeField][Min(0)] private int _damage;

        private NavMeshAgent _agent;
        private CompositeDisposable _disposable;
        private Transform _player;

        private IPhysiology<int> _health;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _health = new Health(_initialHealth, _maximumHealth);
        }

        private void OnEnable()
        {
            _disposable = new CompositeDisposable();

            _playerDetector
                .OnTriggerEnterAsObservable()
                .Subscribe(collision =>
                {
                    if (collision.transform.TryGetComponent(out IPlayer player) == false)
                        return;

                    StartMove(collision.transform);
                })
                .AddTo(_disposable);

            _playerDetector
               .OnTriggerExitAsObservable()
               .Subscribe(collision =>
               {
                   if (collision.transform.TryGetComponent(out IPlayer player) == false)
                       return;

                   StopMove();
               })
               .AddTo(_disposable);

            _health.OnChanged += Kill;
        }

        private void OnDisable()
        {
            _disposable?.Dispose();
            _health.OnChanged -= Kill;
        }

        private void FixedUpdate()
        {
            if (_player == null)
                return;

            _agent.SetDestination(_player.position);
        }

        public void Damage(int damage) =>
            _health.TakeAway(damage);

        private void StartMove(Transform target) =>
            _player =  target;

        private void StopMove() =>
            _player = null;

        private void Kill(int health)
        {
            if (health > 0)
                return;

            Destroy(gameObject);
        }
    }
}