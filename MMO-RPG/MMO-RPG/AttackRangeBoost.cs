using System;

namespace MMO_RPG
{
    internal class AttackRangeBoost : IInteractionStrategy
    {

        private int bonus;
        
        public AttackRangeBoost(int bonus)
        {
            this.bonus = bonus;
        }

        public void Apply(Unit unit)
        {

            unit.AttackRange.IncreaseRange(bonus);
            
        }
    }
}