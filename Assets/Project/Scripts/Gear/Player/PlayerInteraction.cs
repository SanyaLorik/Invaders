using Invaders.Factories;
using Invaders.Ui;
using UnityEngine;
using Zenject;

namespace Invaders.Gear
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform _receiver;
        [SerializeField] private SpeciallyInventorySlot<IItem> _usedSlot;

        private InteractionFactory _factory;
        private IPlayerInteractableHandler _interactableHandler;

        private IItem _item;

        [Inject]
        private void Construct(InteractionFactory factory) =>
            _factory = factory;

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
            _item = item;

            item.PickUp();

            _interactableHandler = _factory.Create(item);
            _interactableHandler?.Enable();

            if (item is MonoBehaviour behaviour)
                Fix(behaviour.transform);
        }

        private void OnDeprive()
        {
            _item.Drop();
            _interactableHandler?.Disable();

            if (_item is MonoBehaviour behaviour)
                Unfix(behaviour.transform);
        }

        private void Fix(Transform source)
        {
            source.SetParent(_receiver);
            source.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        private void Unfix(Transform source) =>
            source.SetParent(null);
    }
}
