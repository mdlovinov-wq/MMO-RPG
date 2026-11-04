using System;

namespace MMO_RPG
{
    class Health
    {

        public int Current
        {
            get;
            private set;
        }
        public int Max
        {
            get;
            private set;
        }
        public Health(int initHealth)
        {
            if (initHealth > 0)
            {
                Current = initHealth;
                Max = initHealth;
                return;
            }   
            throw new ArgumentOutOfRangeException("Initial health must be positive");
        }

        public Health(Health other)
        {
            Current = other.Current;
        }
        
        public void Decrease(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Damage must be positive");
            }
            if (amount > Current)
            {
                Current = 0;
                return;
            }
            Current -= amount;
        }

        public void Increase(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Heal must be positive");
            }
            Current = Math.Min(Current + amount, Max); 
        }

        public bool IsDead()
        {
            return Current == 0;
        }

        public int CountHealthPoints()
        {
            return Current;
        }

    }
}
