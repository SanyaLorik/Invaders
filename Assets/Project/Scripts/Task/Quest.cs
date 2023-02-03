using UnityEngine;

namespace Invaders.Task
{
    public class Quest : MonoBehaviour
    {
        [SerializeField] private Mission[] _missions;

        private bool _isComplated = false;

        private void OnEnable()
        {
            foreach (var mission in _missions)
                mission.OnDone += OnFindNextMission;
        }

        private void OnDisable()
        {
            foreach (var mission in _missions)
                mission.OnDone -= OnFindNextMission;
        }

        private void OnFindNextMission()
        {
            if (_isComplated == true)
                return;

            foreach(var mission in _missions)
            {
                if (mission.IsFinally == true)
                {
                    _isComplated = true;
                    break;
                }

                if (mission.IsDone == true)
                    continue;

                if (mission.IsActivated == true)
                    break;

                mission.Active();
                break;
            }
        }
    }
}