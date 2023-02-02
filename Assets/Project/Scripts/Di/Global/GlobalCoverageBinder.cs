using Invaders.Environment.Global;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class GlobalCoverageBinder : MonoInstaller
    {
        [SerializeField][Range(0, 5)] private int _dayMinute;
        [SerializeField][Range(0, 5)] private int _nightMinute;

        private GlobalCoverageTimer _globalCoverageTimer;

        public override void InstallBindings()
        {
            _globalCoverageTimer = new GlobalCoverageTimer(_dayMinute, _nightMinute);
            _globalCoverageTimer.StartTimer().Forget();

            BindGlobalCoverageObserver();
            BindGlobalCoverageTimerObserver();
        }

        private void BindGlobalCoverageObserver()
        {
            Container
               .Bind<IGlobalCoverageGapObserver>()
               .FromInstance(_globalCoverageTimer)
               .AsCached()
               .NonLazy();
        }

        private void BindGlobalCoverageTimerObserver()
        {
            Container
               .Bind<IGlobalCoverageTimerObserver>()
               .FromInstance(_globalCoverageTimer)
               .AsCached()
               .NonLazy();
        }
    }
}
