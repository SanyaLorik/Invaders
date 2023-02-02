using Invaders.Environment.Global;
using UnityEngine;
using Zenject;

namespace Invaders.Environment.Illumination
{
    [RequireComponent(typeof(Light))]
    public class Lighting : MonoBehaviour
    {
        private Light _light;

        private IGlobalCoverageGapObserver _globalCoverage;

        [Inject]
        private void Construct(IGlobalCoverageGapObserver globalCoverage) =>
            _globalCoverage = globalCoverage;

        private void Awake() =>
            _light = GetComponent<Light>();

        private void OnEnable()
        {
            _globalCoverage.OnDayCome += OnUnvisiableLight;
            _globalCoverage.OnNightCome += OnVisiableLight;
        }

        private void OnDisable()
        {
            _globalCoverage.OnDayCome -= OnUnvisiableLight;
            _globalCoverage.OnNightCome -= OnVisiableLight;
        }

        private void OnVisiableLight()
        {
            _light.enabled = true;
        }

        private void OnUnvisiableLight()
        {
            _light.enabled = false;
        }
    }
}