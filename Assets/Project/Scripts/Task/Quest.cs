using Invaders.Ui;
using UnityEngine;

namespace Invaders.Task
{
    public class Quest : MonoBehaviour
    {
        [SerializeField] private Mission[] _missions;
        [SerializeField] private UiQuest _ui;

        private bool _isComplated = false;

        private void Start() =>
             OnFindNextMission();

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

                _ui.UpdateTask(mission.Text);
                mission.Active();

                break;
            }
        }
    }
}