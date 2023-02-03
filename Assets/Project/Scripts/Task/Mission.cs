using System;
using UnityEngine;

namespace Invaders.Task
{
    public abstract class Mission : MonoBehaviour
    {
        public event Action OnDone = delegate { };

        [field: SerializeField] public bool IsFinally { get; protected set; }

        [field: SerializeField] public bool IsDone { get; protected set; }

        [field: SerializeField] public bool IsActivated { get; protected set; }

        public abstract void Active();
    }
}