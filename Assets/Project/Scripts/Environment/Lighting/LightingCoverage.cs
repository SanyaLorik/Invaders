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
            _globalCoverage.OnDayCame += OnComeDay;
            _globalCoverage.OnNightCame += OnComeNight;
            _globalTimer.OnStepInterval += OnMoveSun;
        }

        private void OnDisable()
        {
            _globalCoverage.OnDayCame -= OnComeDay;
            _globalCoverage.OnNightCame -= OnComeNight;
            _globalTimer.OnStepInterval -= OnMoveSun;
        }

        private void OnComeDay() =>
            _light.color = _day;

        private void OnComeNight() =>
            _light.color = _night;

        private void OnMoveSun(int counter, int total)
        {
            float angleY = 360 * counter / total;
            Rotate(angleY);
        }

        private void Rotate(float angleY)
        {
            Vector3 euler = transform.localRotation.eulerAngles;
            euler.y = angleY;

            transform.rotation = Quaternion.Euler(euler);
        }
    }
}
