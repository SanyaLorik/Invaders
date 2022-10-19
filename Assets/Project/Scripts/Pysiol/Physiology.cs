using System;

namespace Invaders.Pysiol
{
    public abstract class Physiology : IPhysiology<int>
    {
        private const int _minimum = 0;

        public event Action<int> OnChanged; 

        private int _maximum;
        private int _current;

        public Physiology(int current, int maximum)
        {
            if (current > maximum)
                throw new Exception($"Current {current} is greater than maximum {maximum}.");

            if (_minimum > current)
                throw new Exception($"Minimum {_minimum} is greater than current {current}.");
            
            _current = current;
            _maximum = maximum;
        }

        public void Add(int value)
        {
            if (0 > value)
                throw new Exception($"Value {value} is less than zero.");

            ChangeHealth(value);
        }

        public void TakeAway(int value)
        {
            if (0 > value)
                throw new Exception($"Value {value} is less than zero.");
            
            ChangeHealth(-value);
        }

        private void ChangeHealth(int value)
        {
            _current += value;
            _current = Math.Clamp(_current, _minimum, _maximum);
            
            OnChanged?.Invoke(_current);
        }
    }
}