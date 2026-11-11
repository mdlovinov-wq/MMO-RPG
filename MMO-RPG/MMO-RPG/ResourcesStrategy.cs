using System;

namespace MMO_RPG
{
    internal class ResourcesStrategy : IInteractionStrategy
    {

        private int amount;

        public ResourcesStrategy(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentNullException(nameof(amount));
            }
            this.amount = amount;
        }

        public void Apply(Unit unit)
        {

            unit.IncreaseResources(amount);

        }

    }
}
