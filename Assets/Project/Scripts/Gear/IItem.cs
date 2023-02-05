namespace Invaders.Gear
{
    public interface IItem
    {
        string Name { get; }

        void PickUp();

        void Drop();
    }
}