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
                throw new ArgumentNullException(nameof(resources));
            }
            Resources = resources;

        }

        public override void Interact(Unit unit)
        {
            throw new InvalidOperationException("Unit requires base to collect resources");
        }

        public void Collect(Unit unit, Base gameBase)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            if (gameBase == null)
            {
                throw new ArgumentNullException(nameof(gameBase));
            }
            gameBase.IncreaseResources(Resources);
        }
    }
}
