using UnityEngine;

namespace Invaders.Battle
{
    public class WeaponRotator
    {
        private readonly Transform _around;
        private readonly Transform _weapon;
        private readonly float _duration;
        
        public WeaponRotator(Transform around, Transform weapon, float duration)
        {
            _around = around;
            _weapon = weapon;
            _duration = duration;
        }

        public void Rotate(float angle)
        {
            
        }
    }
}