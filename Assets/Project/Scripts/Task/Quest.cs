using UnityEngine;

namespace Invaders.Task
{
    public class Quest : MonoBehaviour
    {
        [SerializeField] private Mission[] _missions;

        private bool _isComplated = false;
    }
}