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

        public void DecreaseSpeed(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Debuff must be positive");
            }
            if (amount > attackSpeed)
            {
                attackSpeed = 1;
                return;
            }
            attackSpeed -= amount;
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
