using System;
using UnityEngine;

namespace Invaders.Gear
{
    [Serializable]
    public struct ItemReceiver
    {
        [SerializeField] private Transform _parent;

        public void Fix(IItem item)
        {
            if (item is MonoBehaviour behaviour == false)
                return;

            behaviour.transform.SetParent(_parent);
            behaviour.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        public void Unfix(IItem item)
        {
            if (item is MonoBehaviour behaviour == false)
                return;

            behaviour.transform.SetParent(null); // drop in world 
        }
}
}