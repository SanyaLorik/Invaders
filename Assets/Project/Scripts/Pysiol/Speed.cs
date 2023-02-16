namespace Invaders.Pysiol
{
    public class Speed : Physiology, ISpeed
    {
        public Speed(int current, int maximum) : base(current, maximum)
        {
            
        }

        public void TurnOnSneaking() =>
            TakeAway(Current / 2);

        public void TurnOffSneaking() =>
            Add(Current);
    }
}