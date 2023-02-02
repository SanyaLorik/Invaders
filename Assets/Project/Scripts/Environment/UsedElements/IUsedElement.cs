namespace Invaders.Environment.UsedElements
{
    public interface IUsedElement
    {
        bool IsAllow { get; }

        void Use();
    }
}