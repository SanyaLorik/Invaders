using System;
using UnityEngine;

namespace Invaders.Task
{
    public abstract class Mission : MonoBehaviour
    {
        [field: SerializeField] public bool IsFinally { get; protected set; }

        [field: SerializeField] public bool IsDone { get; protected set; }
    }
}