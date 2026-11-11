using System;

namespace MMO_RPG
{
    internal class Altar : NeutralObjects
    {
        public Altar(int x, int y) : base(x, y)
        {

            strategies[UnitType.Tank] = new MoveSpeedBoost(1);
            strategies[UnitType.Knight] = new DamageBoost(10);
            strategies[UnitType.BountyHunter] = new AttackRangeBoost(1);
            strategies[UnitType.PhantomAssasin] = new DamageBoost(15);
            strategies[UnitType.Healer] = new MoveSpeedBoost(2);
            strategies[UnitType.Sorcerer] = new MoveSpeedBoost(2);

        }

        public static Unit operator *(Unit unit, Altar altar)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            if (altar == null)
            {
                throw new ArgumentNullException(nameof(altar));
            }
            altar.Interact(unit);

            return unit;
        }
    }
}
