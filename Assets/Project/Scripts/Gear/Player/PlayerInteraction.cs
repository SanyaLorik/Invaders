using Invaders.Ui;
using System;
using UnityEngine;

namespace Invaders.Gear
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private SpeciallyInventorySlot<IItem> _usedSlot;

        private IPlayerInteractableHandler _interactableHandler;
        private IItem _item;

        private void OnEnable()
        {
            _usedSlot.OnTaken += OnTake;
            _usedSlot.OnDeprived += OnDeprive;
        }

        private void OnDisable()
        {
            _usedSlot.OnTaken -= OnTake;
            _usedSlot.OnDeprived -= OnDeprive;
        }

        private void OnTake(IItem item)
        {
            _item = item;
            _interactableHandler = 
        }

        private void OnDeprive()
        {
            throw new NotImplementedException();
        }
    }
}
