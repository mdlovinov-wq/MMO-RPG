using System;
using System.Collections.Generic;

namespace MMO_RPG
{
    internal abstract class NeutralObjects
    {

        protected readonly Dictionary<UnitType, IInteractionStrategy> strategies;

        public int X { get; }
        public int Y { get; }

        protected NeutralObjects(int x, int y)
        {
            X = x;
            Y = y;
            strategies = new Dictionary<UnitType, IInteractionStrategy>();
        }

        public void Interact(Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            if (!strategies.TryGetValue(unit.GetUnitType(), out IInteractionStrategy strategy))
            {
                throw new InvalidOperationException("No strategy for this unit type");
            }
            strategy.Apply(unit);
        }
    }
}
