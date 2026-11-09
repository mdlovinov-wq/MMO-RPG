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

        public void Apply(Unit unit, Base gameBase)
        {
            if (!gameBase.IsUnitInBase(unit))
            {
                throw new InvalidOperationException("Unit does not belong to the base");
            }
            unit.AttackRange.IncreaseRange(bonus);
            
        }
    }
}