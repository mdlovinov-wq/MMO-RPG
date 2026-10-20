using System;

namespace MMO_RPG
{
    class Attack
    {
        private int damage;

        public Attack(int damage)
        {
            if (damage <= 0)
            {
                throw new ArgumentException("Damage must be positive");
            }
            this.damage = damage;
        }

        public Attack(Attack other)
        {
            damage = other.damage;
        }

        public int CalculateDamage(Armor targetArmor)
        {
            return targetArmor.ReduceDamage(damage);
        }


    }
}
