namespace Invaders.Additionals
{
    public interface IValueProvider<T>
    {
        T Value { get; }
    }
}