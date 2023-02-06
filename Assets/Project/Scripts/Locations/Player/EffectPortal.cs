using Cinemachine;
using Cysharp.Threading.Tasks;
using Invaders.Ui;
using System.Threading;
using UnityEngine;

namespace Invaders.Locations
{
    public class EffectPortal : Portal
    {
        [Header("Transition")]
        [SerializeField] private VisableScreen _visableScreen;

        [Header("Camera")]
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private Vector3 _rotation;
        [SerializeField][Range(1f, 10f)] private float _distance;

        protected override async UniTask DelayTeleport(CancellationToken token, Transform entity)
        {
            ActiveEffect();
            await base.DelayTeleport(token, entity);
        }

        private void ActiveEffect()
        {
            _visableScreen.Flash();

            CinemachineComponentBase componentBase = _virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            if (componentBase is CinemachineFramingTransposer transposer)
                transposer.m_CameraDistance = _distance;

            _virtualCamera.transform.rotation = Quaternion.Euler(_rotation);
        }
    }
}
