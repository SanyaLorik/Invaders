using TMPro;
using UnityEngine;

namespace Invaders.Ui
{
    public class UiQuest : MonoBehaviour
    {
        [SerializeField] private TMP_Text _task;

        public void UpdateTask(string text) =>
            _task.text = text;
        public void ComplateTask() =>
            _task.text = "Начало пройдено!";
    }
}