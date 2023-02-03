using Invaders.Ui;
using UnityEngine;

namespace Invaders.Task
{
    public class Quest : MonoBehaviour
    {
        [SerializeField] private Mission[] _missions;
        [SerializeField] private UiQuest _ui;
        [SerializeField] private MissionPointer _pointer;

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
            _pointer.Hide();

            foreach(var mission in _missions)
            {
                if (mission.IsDone == true && mission.IsFinally == true)
                {
                    _isComplated = true;
                    break;
                }

                if (mission.IsDone == true)
                    continue;

                if (mission.IsActivated == true)
                    break;

                _pointer.Show();
                _pointer.Point(mission.Point);
                _ui.UpdateTask(mission.Text);
                mission.Active();

                break;
            }

            if (_isComplated == true)
                _ui.ComplateTask();
        }
    }
}