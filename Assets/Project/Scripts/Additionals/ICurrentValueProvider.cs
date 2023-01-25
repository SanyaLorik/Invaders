namespace Invaders.Additional
{
    public interface ICurrentValueProvider<T>
    {
        T Current { get; }
    }
}