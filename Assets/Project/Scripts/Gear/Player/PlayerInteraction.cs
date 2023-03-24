using Invaders.Factories;
using Invaders.Ui;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private SpeciallyInventorySlot<IItem> _usedSlot;

        private IFactory<IItem, IPlayerInteractableHandler> _factory;
        private IPlayerInteractableHandler _interactableHandler;

        [Inject]
        private void Construct(InteractionFactory factory) => _factory = factory;

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
            _interactableHandler = _factory.Create(item);
            _interactableHandler?.Enable();
        }

        private void OnDeprive() => _interactableHandler?.Disable();
    }
}
