using Invaders.Environment.Global;
using UnityEngine;
using Zenject;

namespace Invaders.Environment.Illumination
{
    [RequireComponent(typeof(Light))]
    public class LightingCoverage : MonoBehaviour
    {
        [SerializeField] private Color _day;
        [SerializeField] private Color _night;

        private Light _light;

        private IGlobalCoverageGapObserver _globalCoverage;
        private IGlobalCoverageTimerObserver _globalTimer;

        [Inject]
        private void Construct(IGlobalCoverageGapObserver globalCoverage, IGlobalCoverageTimerObserver globalTimer)
        {
            _globalCoverage = globalCoverage;
            _globalTimer = globalTimer;
        }

        private void Awake() =>
            _light = GetComponent<Light>();

        private void OnEnable()
        {
            _globalTimer.OnStepInterval += OnMoveSun;
        }

        private void OnMoveSun(int counter, int total)
        {

        }
    }
}
