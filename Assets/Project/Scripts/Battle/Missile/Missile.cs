using UnityEngine;

namespace Invaders.Battle
{
    public abstract class Missile : MonoBehaviour, IMissile
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        
        public int Damage { private get; set; }
    }
}