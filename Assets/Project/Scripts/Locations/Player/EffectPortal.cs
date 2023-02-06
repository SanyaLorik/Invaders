using Cysharp.Threading.Tasks;
using Invaders.Ui;
using System.Threading;
using UnityEngine;

namespace Invaders.Locations
{
    public class EffectPortal : Portal
    {
        [SerializeField] private VisableScreen _visableScreen;

        protected override async UniTask DelayTeleport(CancellationToken token, Transform entity)
        {
            _visableScreen.Flash();
            await base.DelayTeleport(token, entity);
        }
    }
}
