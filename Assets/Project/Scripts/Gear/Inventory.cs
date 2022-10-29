using System;
using System.Collections.Generic;
using System.Linq;

namespace Invaders.Gear
{
    public class Inventory : IInventory<IItem>
    {
        private readonly IList<IItem> _items = new List<IItem>(); 

        public void Add(IItem item)
        {
            if (item == null)
                throw new NullReferenceException();
            
            _items.Add(item);
        }

        public void Remove(IItem item)
        {
            if (item == null)
                throw new NullReferenceException($"{item} US null/");

            if (_items.Contains(item) == false)
                throw new SystemException($"There is no {item} in collection.");
            
            _items.Remove(item);
        }

        public IItem Get(Type type)
        {
            var item = _items.First(i => i.GetType() == type);
            if (item == null)
                throw new NullReferenceException($"There is no {item} in collection.");

            return item;
        }
    }
}