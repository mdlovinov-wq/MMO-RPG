using System;

namespace MMO_RPG
{
    internal class DamageBoost : IInteractionStrategy
    {

        private int bonus;

        public DamageBoost(int bonus)
        {
            this.bonus = bonus;
        }
        
        public void Apply(Unit unit)
        {
            unit.Attack.IncreaseDamage(bonus);
        }
    }
}
