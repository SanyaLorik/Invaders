using DG.Tweening;
using UnityEngine;

namespace Invaders.Environment.UsedElements
{
    public class Lever : ManagementElement, IUsedElement
    {
        [field: SerializeField] public bool IsAllow { get; private set; } = true;

        public void Use()
        {

        }
    }
}