using UnityEngine;

namespace Invaders.Additionals
{
    public static class SpecificPhysics
    {
        public static bool TryRaycast<T>(out T t, Vector3 origin, Vector3 direction, float distance)
            where T : class
        {
            t = default;

            if (Physics.Raycast(origin, direction, out RaycastHit hit, distance) == false)
                return false;

            if (hit.transform.TryGetComponent(out T result) == false)
                return false;

            t = result;
            return true;
        }
    }
}