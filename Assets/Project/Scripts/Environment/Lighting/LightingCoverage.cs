using DG.Tweening;
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
        [SerializeField][Range(0f, 5f)] private float _switchedDurataion;

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
            _light.DOColor(_day, _switchedDurataion);

        private void OnComeNight() =>
            _light.DOColor(_night, _switchedDurataion);

        private void OnMoveSun(float counter, float total)
        {
            float angleY = 360 * counter / total;
            Rotate(angleY);
        }

        private void Rotate(float angleY)
        {
            Vector3 euler = transform.localRotation.eulerAngles;
            euler.y = angleY;

            transform.DORotate(euler, GlobalCoverageTimer.Interval.Seconds).SetEase(Ease.Linear);
        }
    }
}
