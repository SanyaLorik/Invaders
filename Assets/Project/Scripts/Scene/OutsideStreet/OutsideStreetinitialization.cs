using Invaders.Ui;
using UnityEngine;

namespace Invaders.Scenes
{
    public class OutsideStreetinitialization : MonoBehaviour
    {
        [SerializeField] private VisableScreen _visableScreen;

        private void Start ()
        {
            _visableScreen.Ascend();
        }
    }
}