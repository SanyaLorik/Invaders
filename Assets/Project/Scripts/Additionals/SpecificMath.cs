using UnityEngine;

namespace Invaders.Additionals
{
    public static class SpecificMath
    {
        public static float CalculateForceIgnoreMass(float mass, float lenght) =>
            Mathf.Sqrt(2 * lenght * -Physics2D.gravity.y * mass);

        public static float CalculateForce(float lenght) =>
           Mathf.Sqrt(2 * lenght * -Physics2D.gravity.y);
    }
}