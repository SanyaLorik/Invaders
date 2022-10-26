namespace Invaders.Pysiol
{
    public interface IValueProvider<T>
    {
        T Value { get; }
    }
}