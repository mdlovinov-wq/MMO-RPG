using System;

namespace MMO_RPG
{
    class AttackSpeed
    {
        private int attackSpeed;
        public AttackSpeed(int attackSpeed)
        {
            if (attackSpeed <= 0)
            {
                throw new ArgumentException("Attack speed must be positive");
            }
            this.attackSpeed = attackSpeed;
        }

        public AttackSpeed(AttackSpeed other)
        {
            attackSpeed = other.attackSpeed;
        }

        public void DecreaseSpeed(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Debuff must be positive");
            }
            attackSpeed = Math.Max(1, attackSpeed - amount);
        }

        public void IncreaseSpeed(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Buff must be positive");
            }
            attackSpeed += amount;
        }
    }
}
