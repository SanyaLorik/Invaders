using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Invaders.Ui
{
    public class UiQuest : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private TMP_Text _task;

        public void UpdateTask(string text) =>
            _task.text = text;

        public async UniTaskVoid ComplateTask()
        {
            _task.text = "Начало пройдено!";
            await UniTask.Delay(3000);
            HidePanel();
        }

        private void HidePanel() =>
            _panel.SetActive(false);
    }
}