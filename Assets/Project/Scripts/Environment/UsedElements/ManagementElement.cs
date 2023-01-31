using System;
using UnityEngine;

namespace Invaders.Environment.UsedElements
{
    [RequireComponent(typeof(Collider))]
    public abstract class ManagementElement : MonoBehaviour, IUsedElement
    {
        public event Action OnUsed = delegate { };

        public bool IsAllow { get; private set; } = true;

        public virtual void Use()
        {
            OnUsed.Invoke();
        }
    }
}