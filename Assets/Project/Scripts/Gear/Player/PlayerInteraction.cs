using Invaders.Ui;
using UnityEngine;

namespace Invaders.Gear
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private SpeciallyInventorySlot<IItem> _usedSlot;

        private IPlayerInteractableHandler _interactableHandler;

        private void OnEnable()
        {
            _usedSlot.OnTaken += OnTake;
            _usedSlot.OnDeprived += OnDeprive;
        }

        private void OnDisable()
        {
            _usedSlot.OnTaken -= OnTake;
            _usedSlot.OnDeprived -= OnDeprive;

            _interactableHandler?.Disable();
        }

        private void OnTake(IItem item)
        {
            //_interactableHandler = 
            _interactableHandler.Enable();
        }

        private void OnDeprive()
        {
            _interactableHandler.Disable();
        }
    }
}
