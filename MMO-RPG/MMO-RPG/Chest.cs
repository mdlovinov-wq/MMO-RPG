using System;

namespace MMO_RPG
{
    internal class Chest : NeutralObjects
    {
        public int Resources { get; }
        public Chest(int x, int y, int resources) : base(x, y)
        {

            if (resources < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(resources));
            }
            Resources = resources;
        }

        public override void Interact(Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            unit.IncreaseResources(Resources);
        }

        public static Unit operator +(Unit unit, Chest chest)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            if (chest == null)
            {
                throw new ArgumentNullException(nameof(chest));
            }
            chest.Interact(unit);

            return unit;
        }
    }
}
