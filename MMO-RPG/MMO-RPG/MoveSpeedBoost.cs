using System;

namespace MMO_RPG
{
    internal class MoveSpeedBoost : IInteractionStrategy
    {

        private int bonus;

        public MoveSpeedBoost(int bonus)
        {
            this.bonus = bonus;
        }

        public void Apply(Unit unit, Base gameBase)
        {
            if (!gameBase.IsUnitInBase(unit))
            {
                throw new InvalidOperationException("Unit does not belong to the base");
            }
            unit.MoveSpeed.IncreaseMoveSpeed(bonus);
        }
    }
}
