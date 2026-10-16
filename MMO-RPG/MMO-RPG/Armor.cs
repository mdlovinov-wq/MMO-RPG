using System;

namespace MMO_RPG
{
    class Armor
    {
        private int armor;

        public Armor(int armor)
        {
            if (armor < 0)
            {
                throw new ArgumentException("Armor can't be negative");
            }
            this.armor = armor;
        }

        public int ReduceDamage(int damage)
        {
            if (armor > damage)
            {
                armor -= damage;
                return 0;
            }
            armor = 0;
            return damage - armor;
        }

    }
}
