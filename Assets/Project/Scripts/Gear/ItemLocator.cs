using System.Collections.Generic;
using UnityEngine;

namespace Invaders.Gear
{
    [RequireComponent(typeof(Collider))]
    public class ItemLocator : MonoBehaviour
    {
        private readonly IList<IItem> _items = new List<IItem>();

        private void OnTriggerEnter(Collider other)
        {
            if (TryGetItem(other, out IItem item) == true)
                _items.Add(item);
        }

        private void OnTriggerExit(Collider other)
        {
            if (TryGetItem(other, out IItem item) == true)
                _items.Remove(item);
        }

        public bool HaveItemInArea => _items.Count > 0;

        public IItem Receive()
        {
            IItem item = _items[0];
            _items.Remove(item);

            return item;
        }

        private bool TryGetItem(Collider other, out IItem item)
        {
            item = null;

            if (other.TryGetComponent(out IItem component) == false)
                return false;

            if (component.CanTaken == false)
                return false;

            item = component;
            return true;
        }
    }
}