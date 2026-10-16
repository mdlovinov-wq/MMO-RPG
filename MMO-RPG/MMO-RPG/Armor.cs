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
            if (damage < 0)
            {
                throw new ArgumentException("Damage can't be negative");
            }
            return Math.Max(0, damage - armor);
        }

    }
}
