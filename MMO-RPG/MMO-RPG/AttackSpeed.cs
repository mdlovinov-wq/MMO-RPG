using System;

namespace MMO_RPG
{
    class AttackSpeed
    {
        public int Current
        {
            get;
            private set;
        }
        public AttackSpeed(int attackSpeed)
        {
            if (attackSpeed <= 0)
            {
                throw new ArgumentException("Attack speed must be positive");
            }
            Current = attackSpeed;
        }

        public AttackSpeed(AttackSpeed other)
        {
            Current = other.Current;
        }

        public void DecreaseSpeed(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Debuff must be positive");
            }
            Current = Math.Max(1, Current - amount);
        }

        public void IncreaseSpeed(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Buff must be positive");
            }
            Current += amount;
        }
    }
}
