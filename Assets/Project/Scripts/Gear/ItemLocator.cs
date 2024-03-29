﻿using System.Collections.Generic;
using UnityEngine;

namespace Invaders.Gear
{
    [RequireComponent(typeof(Collider))]
    public class ItemLocator : MonoBehaviour
    {
        private readonly IList<IItem> _items = new List<IItem>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IItem item) == false)
                return;

            if (item.CanTaken == false)
                return;

            _items.Add(item);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IItem item) == false)
                return;

            if (item.CanTaken == false)
                return;

            _items.Remove(item);
        }

        public bool HaveItemInArea => _items.Count > 0;

        public IItem Receive()
        {
            IItem item = _items[0];
            _items.Remove(item);

            return item;
        }
    }
}