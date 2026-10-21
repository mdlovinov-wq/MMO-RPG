using System;

namespace MMO_RPG
{
    class Health
    {
        private int health;
        public Health(int initHealth)
        {
            if (initHealth > 0)
            {
                health = initHealth;
                return;
            }   
            throw new ArgumentException("Initial health must be positive");
        }

        public Health(Health other)
        {
            health = other.health;
        }
        
        public void Decrease(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Damage must be positive");
            }
            if (amount > health)
            {
                health = 0;
                return;
            }
            health -= amount;
        }

        public void Increase(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Heal must be positive");
            }
            health += amount;
        }

        public bool IsZero()
        {
            return health == 0;
        }

        public int CountHealthPoints()
        {
            return health;
        }

    }
}
