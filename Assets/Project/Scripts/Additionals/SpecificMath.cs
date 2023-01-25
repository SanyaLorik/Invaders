﻿using UnityEngine;

namespace Invaders.Additionals
{
    public static class SpecificMath
    {
        public static float CalculateLenght(float mass, float lenght) =>
            Mathf.Sqrt(2 * lenght * -Physics2D.gravity.y * mass);
    }
}