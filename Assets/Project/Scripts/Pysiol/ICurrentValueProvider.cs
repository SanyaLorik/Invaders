namespace Invaders.Pysiol
{
    public interface ICurrentValueProvider<T>
    {
        T Current { get; }
    }
}