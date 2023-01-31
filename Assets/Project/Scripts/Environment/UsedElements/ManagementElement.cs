using System;
using UnityEngine;

namespace Invaders.Environment.UsedElements
{
    public abstract class ManagementElement : MonoBehaviour
    {
        public event Action OnActived = delegate { };   
        public event Action OnDisactived = delegate { };   
    }
}