using System;

namespace MMO_RPG
{
    class AttackRange
    {
        public int Current
        {
            get;
            private set;
        }

        public AttackRange(int attackRange)
        {
            if (attackRange <= 0)
            {
                throw new ArgumentException("Attack range must be positive");
            }
            Current = attackRange;
        }

        public AttackRange(AttackRange other)
        {
            Current = other.Current;
        }

        public void DecreaseRange(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Debuff must be positive");
            }
            Current = Math.Max(1, Current - amount);
        }

        public void IncreaseRange(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Buff must be positive");
            }
            Current += amount;
        }
    }
}
