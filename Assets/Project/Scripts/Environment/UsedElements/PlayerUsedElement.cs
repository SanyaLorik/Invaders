using Invaders.Additionals;
using Invaders.InputSystem;
using Invaders.Movement;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Environment.UsedElements
{
    [RequireComponent(typeof(IPlayerLookService))]
    public class PlayerUsedElement : MonoBehaviour
    {
        [SerializeField][Range(0f, 5f)] private float _distance;

        private IPlayerLookService _lookService;
        private IUsedService _usedService;

        [Inject]
        private void Construct(IUsedService usedService) =>
            _usedService = usedService;

        private void Awake() =>
            _lookService = GetComponent<IPlayerLookService>();

        private void OnEnable() =>
            _usedService.OnUsed += OnUse;

        private void OnDisable() =>
            _usedService.OnUsed -= OnUse;

        private void OnUse()
        {
            if (SpecificPhysics.TryRaycast(out IUsedElement used, transform.position, _lookService.Direction, _distance) == false)
                return;

            if (used.IsAllow == false)
                return;

            used.Use();
        }
    }
}