using System;

namespace MMO_RPG
{
    internal class Trap : NeutralObjects
    {

        public Trap(int x, int y) : base(x, y)
        {
            strategies[UnitType.Knight] = new TrapStrategy(15);
            strategies[UnitType.Tank] = new TrapStrategy(10);
            strategies[UnitType.PhantomAssasin] = new TrapStrategy(20);
            strategies[UnitType.BountyHunter] = new TrapStrategy(25);
            strategies[UnitType.Sorcerer] = new TrapStrategy(30);
            strategies[UnitType.Healer] = new TrapStrategy(35);
        }

        public static Unit operator -(Unit unit, Trap trap)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            if (trap == null)
            {
                throw new ArgumentNullException(nameof(trap));
            }
            trap.Interact(unit);

            return unit;
        }

        public override NeutralType GetNeutralType()
        {
            return NeutralType.Trap;
        }
    }
}
