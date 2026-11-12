using System;

namespace MMO_RPG
{
    abstract class Assasin : Unit
    {
        protected Assasin(int x, int y, 
            Health health, Armor armor,
            Attack attack, AttackRange attackRange,
            AttackSpeed attackSpeed, DamageResist damageResist,
            MoveSpeed moveSpeed) : 
            base(x, y, 
            health, armor,
            attack, attackRange,
            attackSpeed, damageResist,
            moveSpeed)
        {
        }

        protected Assasin(Assasin other) : base(other)
        {
        }
    }
}
