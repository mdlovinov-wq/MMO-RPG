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
        
        public void Apply(Unit unit, Base gameBase)
        {
            if (!gameBase.IsUnitInBase(unit))
            {
                throw new InvalidOperationException("Unit does not belong to the base");
            }
            unit.Attack.IncreaseDamage(bonus);
        }
    }
}
