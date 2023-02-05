namespace Invaders.Additionals
{
    public static class AsyncSupporter
    {
        public static int DelayMillisecond(this float number) =>
            (int)(number * 1000);
    }
}