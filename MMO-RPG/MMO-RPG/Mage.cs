using System;

namespace MMO_RPG
{
    abstract class Mage : Unit
    {

        protected Mage(int x, int y,
            Health health, Armor armor,
            Attack attack, AttackRange attackRange,
            AttackSpeed attackSpeed) :
            base(x, y,
            health, armor,
            attack, attackRange,
            attackSpeed)
        { }

    }
}
