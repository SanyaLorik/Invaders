using System;

namespace Invaders.Environment.Global
{
    public interface IGlobalCoverageTimerObserver
    {
        event Action<float, float> OnStepInterval;
    }
}