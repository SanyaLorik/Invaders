using Invaders.InputSystem;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    public class PlayerReceiver : MonoBehaviour
    {
        [SerializeField] private ItemLocator _locator;
        [SerializeField] private PlayerInventory _inventory;

        private IPlayerReceiverService _receiver;

        [Inject]
        private void Construct(IPlayerReceiverService receiver) =>
            _receiver = receiver;

        private void OnEnable() =>
            _receiver.OnReceived += OnReceive;

        private void OnDisable() =>
            _receiver.OnReceived -= OnReceive;

        private void OnReceive()
        {
            if (_locator.HaveItemInArea == true)
                _inventory.Add(_locator.Receive());
        }
    }
}