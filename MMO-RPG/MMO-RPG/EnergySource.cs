using System;

namespace MMO_RPG
{
    internal class EnergySource : NeutralObjects
    {
        public EnergySource(int x, int y) : base(x, y) { }

        public override void Interact(Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            unit.MaxHealth();
        }

        public static Unit operator ^(Unit unit, EnergySource source)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            source.Interact(unit);

            return unit;
        }
    }
}
