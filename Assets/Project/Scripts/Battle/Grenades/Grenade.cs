using Cysharp.Threading.Tasks;
using Invaders.Additionals;
using System.Threading;
using UnityEngine;

namespace Assets.Project.Scripts.Battle.Grenades
{
    public abstract class Grenade : MonoBehaviour, IGrenade
    {
        [SerializeField][Range(01f, 3f)] private float _delayExplosion;
        [SerializeField][Range(01f, 3f)] private float _delayEffect;

        [field: SerializeField][field: Range(0f, 20f)] protected float Lenght { get; private set; }

        [field: SerializeField] public string Name { get; private set; }

        public Sprite Icon => throw new System.NotImplementedException();

        public string Description => throw new System.NotImplementedException();

        public bool CanTaken => throw new System.NotImplementedException();

        protected CancellationTokenSource _tokenSource;

        protected virtual void OnDisable() =>
            _tokenSource?.Cancel();

        public virtual void Throw(Vector3 direction)
        {
            _tokenSource = new CancellationTokenSource();
            DelayEffect(_tokenSource.Token).Forget();
        }

        protected async virtual UniTaskVoid DelayEffect(CancellationToken token)
        {
            int delay = _delayExplosion.DelayMillisecond();
            await UniTask.Delay(delay, cancellationToken: token);

            ActiveEffect();
        }

        public abstract void PickUp();

        public abstract void Drop();

        protected abstract void ActiveEffect();

        public abstract void Show();

        public abstract void Hide();
    }
}