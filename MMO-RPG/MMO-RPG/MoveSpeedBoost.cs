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

        public void Apply(Unit unit)
        {
            unit.MoveSpeed.IncreaseMoveSpeed(bonus);
        }
    }
}
