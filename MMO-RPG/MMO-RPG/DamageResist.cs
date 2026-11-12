using System;
using System.Text;

namespace MMO_RPG
{
    internal class DamageResist
    {

        public double Current
        {
            get;
            private set;
        }

        public DamageResist(double initResist)
        {
            if (initResist < 0 || initResist > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(initResist));
            }
            Current = initResist;
        }

        public DamageResist(DamageResist other)
        {
            Current = other.Current;
        }

        public void IncreaseResist(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Resist can't be negative");
            }

            Current = Math.Min(100, Current + amount);
        }

        public void DecreaseResist(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Resist can't be negative");
            }

            Current = Math.Max(0, Current - amount);
        }
    }
}
