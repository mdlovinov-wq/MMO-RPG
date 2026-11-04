using System;

namespace MMO_RPG
{
    class Armor
    {
        public int Current
        {
            get;
            private set;
        }

        public Armor(int armor)
        {
            if (armor < 0)
            {
                throw new ArgumentException("Armor can't be negative");
            }
            Current = armor;
        }

        public Armor(Armor other)
        {
            Current = other.Current;    
        }

        public int ReduceDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Damage can't be negative");
            }
            return Math.Max(0, damage - Current);
        }

    }
}
