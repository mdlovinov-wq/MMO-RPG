using System;

namespace MMO_RPG
{
    class AttackRange
    {
        private int attackRange;

        public AttackRange(int attackRange)
        {
            if (attackRange <= 0)
            {
                throw new ArgumentException("Attack range must be positive");
            }
            this.attackRange = attackRange;
        }

        public AttackRange(AttackRange other)
        {
            attackRange = other.attackRange;
        }

        public void DecreaseRange(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Debuff must be positive");
            }
            attackRange = Math.Max(1, attackRange - amount);
        }

        public void IncreaseRange(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Buff must be positive");
            }
            attackRange += amount;
        }
    }
}
