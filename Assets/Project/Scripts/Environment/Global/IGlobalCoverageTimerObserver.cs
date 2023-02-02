using System;

namespace Invaders.Environment.Global
{
    public interface IGlobalCoverageTimerObserver
    {
        event Action<int, int> OnStepInterval;
    }
}