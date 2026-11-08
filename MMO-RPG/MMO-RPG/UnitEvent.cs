using System;

namespace MMO_RPG
{
    internal class UnitEvent
    {

        public Unit Unit { get; }
        public UnitEventType Type { get; }

        public UnitEvent(Unit unit, UnitEventType type)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            Unit = unit;
            Type = type;
        }
    }
}
