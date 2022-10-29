using System;

namespace Invaders.Gear
{
    public interface IInventory<T>
        where T : IItem
    {
        void Add(T item);

        void Remove(T item);
        
        T Get(Type type);
    }

    public interface IEquipment<T>
        where T : IItem
    {
        
    }
}