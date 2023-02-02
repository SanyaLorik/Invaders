using System;

namespace Invaders.Environment.Global
{
    public interface IGlobalCoverageGapObserver
    {
        event Action OnDayCome;
        event Action OnNightCome;
    }
}