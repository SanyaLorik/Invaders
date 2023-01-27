using Invaders.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Invaders.Test
{
    public class SceneReloader : MonoBehaviour
    {
        private ISceneReloaderObserverService _reloader;

        [Inject]
        private void Construct(ISceneReloaderObserverService reloader) =>
            _reloader = reloader;

        private void OnEnable() =>
            _reloader.OnSceneReloaded += OnReload;

        private void OnDisable() =>
            _reloader.OnSceneReloaded -= OnReload;

        private void OnReload() =>
            SceneManager.LoadScene(0);
    }
}