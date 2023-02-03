using System;
using UnityEngine;

namespace Invaders.Task
{
    public abstract class Mission : MonoBehaviour
    {
        public event Action OnDone = delegate { };

        [field: SerializeField] public bool IsFinally { get; private set; }

        [field: SerializeField] public bool IsDone { get; private set; }

        [field: SerializeField] public bool IsActivated { get; private set; }

        [field: SerializeField] public string Text { get; private set; }

        public virtual void Complate()
        {
            IsDone = true;
            IsActivated = false;
            OnDone.Invoke();
        }

        public virtual void Active() =>
            IsActivated = true;
    }
}