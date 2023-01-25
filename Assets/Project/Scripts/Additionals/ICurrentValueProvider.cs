namespace Invaders.Additionals
{
    public interface ICurrentValueProvider<T>
    {
        T Current { get; }
    }
}