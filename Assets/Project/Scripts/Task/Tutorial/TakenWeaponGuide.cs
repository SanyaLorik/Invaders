using Invaders.Gear;
using Invaders.Ui;
using UnityEngine;

namespace Invaders.Task
{
    public class TakenWeaponGuide : Mission
    {
        [SerializeField] private SpeciallyInventorySlot<IItem> _used;

        private void OnEnable() =>
            _used.OnTaken += OnTake;

        private void OnDisable() =>
            _used.OnTaken -= OnTake;

        private void OnTake(IItem item) =>
            base.Complate();
    }
}