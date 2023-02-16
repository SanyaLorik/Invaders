using Cinemachine;
using Invaders.Environment.UsedElements;
using Invaders.Ui;
using UnityEngine;

namespace Invaders.Locations
{
    public class EffectPortal : Portal, IConfirmable
    {
        [Header("Transition")]
        [SerializeField] private VisableScreen _visableScreen;

        [Header("Camera")]
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private Vector3 _rotation;
        [SerializeField][Range(1f, 10f)] private float _distance;

        public void Confirm()
        {
            ActiveEffect();
            Telepot();
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
