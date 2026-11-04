using System;

namespace MMO_RPG
{
    class Attack
    {
        public int Damage
        {
            get;
            private set;
        }

        public Attack(int damage)
        {
            if (damage <= 0)
            {
                throw new ArgumentException("Damage must be positive");
            }
            Damage = damage;
        }

        public Attack(Attack other)
        {
            Damage = other.Damage;
        }

        public int CalculateDamage(Armor targetArmor, DamageResist targetResist)
        {
            return targetArmor.ReduceDamage(Damage) * (1 - targetResist.Current);
        }
    }
}
