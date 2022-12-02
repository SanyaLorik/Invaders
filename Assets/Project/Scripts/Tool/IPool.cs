namespace Invaders.Tool
{
    public interface IPool
    {
        void Add();

        void ReturnToCollection();

        void Get();
    }
}
