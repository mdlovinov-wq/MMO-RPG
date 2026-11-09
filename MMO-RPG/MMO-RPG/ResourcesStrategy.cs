using System;

namespace MMO_RPG
{
    internal class ResourcesStrategy : IInteractionStrategy
    {

        private int amount;

        public void Apply(Unit unit, Base gameBase)
        {
            if (!gameBase.IsUnitInBase(unit))
            {
                throw new InvalidOperationException("Unit does not belong to the base");
            }
            gameBase.IncreaseResources(amount);

        }

    }
}
