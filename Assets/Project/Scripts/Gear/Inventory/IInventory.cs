namespace Invaders.Gear
{
    public interface IInventory<Tkey, TValue>
        where TValue : IItem
    {
        bool HavePlace { get; }

        void Add(Tkey id, TValue item);

        TValue Get(Tkey id);

        TValue TrailGet(Tkey id);
    }
}