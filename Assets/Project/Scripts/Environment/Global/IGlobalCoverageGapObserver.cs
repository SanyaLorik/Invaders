using System;

namespace Invaders.Environment.Global
{
    public interface IGlobalCoverageGapObserver
    {
        event Action OnDayCame;
        event Action OnNightCame;
    }
}