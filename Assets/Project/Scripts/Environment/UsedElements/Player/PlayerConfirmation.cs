using Invaders.InputSystem;
using System;
using UnityEngine;
using Zenject;

namespace Invaders.Environment.UsedElements
{
    public class PlayerConfirmation : MonoBehaviour
    {
        private IPlayerConfirmation _confirmation;

        [Inject]
        private void Construct(IPlayerConfirmation confirmation) =>
            _confirmation = confirmation;

        private void OnEnable() =>
            _confirmation.OnConfirmed += OnConfirm;

        private void OnDisable() =>
            _confirmation.OnConfirmed -= OnConfirm;

        private void OnConfirm()
        {
            throw new NotImplementedException();
        }
    }
}