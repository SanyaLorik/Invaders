using UnityEngine;

namespace Invaders.Battle
{
    public interface IMissile
    {
        Rigidbody Rigidbody { get; }
        
        int Damage { set; }
    }
}