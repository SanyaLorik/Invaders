using System;
using UnityEngine;

namespace Invaders.Pysiol
{
    public abstract class PhysiologyBase : IPhysiology<int>, ICurrentValueProvider<int>
    {
        private const int _minimum = 0;

        public event Action<int> OnChanged;

        private int _maximum;
        private int _current;

        public PhysiologyBase(int current, int maximum)
        {
            if (current > maximum)
                throw new Exception($"Current {current} is greater than maximum {maximum}.");

            if (_minimum > current)
                throw new Exception($"Minimum {_minimum} is greater than current {current}.");
            
            _current = current;
            _maximum = maximum;
        }

        public ICurrentValueProvider<int> Provider => this;

        public int Current => _current;

        public void Add(int value)
        {
            if (0 > value)
                throw new Exception($"Value {value} is less than zero.");

            ChangeCurrentValue(value);
            Debug.Log("DA");
        }

        public void TakeAway(int value)
        {
            if (0 > value)
                throw new Exception($"Value {value} is less than zero.");
            
            ChangeCurrentValue(-value);
        }

        private void ChangeCurrentValue(int value)
        {
            _current += value;
            _current = Math.Clamp(_current, _minimum, _maximum);
            
            OnChanged?.Invoke(_current);
        }
    }
}