using System;
using System.Collections.Generic;

namespace Invaders.Gear
{
    public class Inventory<Tkey, TValue> : IInventory<Tkey, TValue>
        where TValue : IItem
    {
        private readonly IDictionary<Tkey, TValue> _items = new Dictionary<Tkey, TValue>();
        private readonly int _capacity;

        public Inventory(int capacity) =>
            _capacity = capacity;

        public bool HavePlace => _items.Count < _capacity;

        public void Add(Tkey id, TValue item)
        {
            if (HavePlace == false)
                throw new Exception($"Capacity is over.");

            if (_items.ContainsKey(id) == true)
                throw new Exception($"Key {id} is exist.");

            _items.Add(id, item);
        }

        public TValue Get(Tkey id)
        {
            if (_items.ContainsKey(id) == false)
                throw new KeyNotFoundException($"Key {id} is not exist.");

            var result = _items[id];
            _items.Remove(id);

            return result;
        }

        public TValue TrailGet(Tkey id)
        {
            if (_items.ContainsKey(id) == false)
                throw new KeyNotFoundException($"Key {id} is not exist.");

            return _items[id];
        }
    }
}