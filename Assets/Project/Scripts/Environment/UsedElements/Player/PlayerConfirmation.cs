using Invaders.InputSystem;
using Invaders.Ui;
using UnityEngine;
using Zenject;

namespace Invaders.Environment.UsedElements
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerConfirmation : MonoBehaviour
    {
        [SerializeField] private UiConfirmation _ui;

        private IConfirmable _confirmable;
        private IPlayerConfirmation _confirmation;

        [Inject]
        private void Construct(IPlayerConfirmation confirmation) =>
            _confirmation = confirmation;

        private void OnEnable() =>
            _confirmation.OnConfirmed += OnConfirm;

        private void OnDisable() =>
            _confirmation.OnConfirmed -= OnConfirm;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IConfirmable confirmable) == false)
                return;

            _confirmable = confirmable;
            _ui.Show();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<IConfirmable>() == null)
                return;

            _confirmable = null;
            _ui.Hide();
        }

        private void OnConfirm()
        {
            if (_confirmable == null)
                return;

            _confirmable.Confirm();
            _ui.Hide();
            _confirmable = null;
        }
    }
}