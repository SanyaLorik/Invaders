namespace Invaders.Additional
{
    public interface IValueProvider<T>
    {
        T Value { get; }
    }
}