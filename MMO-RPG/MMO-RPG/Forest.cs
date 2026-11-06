using System;

namespace MMO_RPG
{
    internal class Forest : ITerrain
    {
        public double GetDefenseBonus(Unit unit)
        {
            if (unit.GetUnitType() == "Sorcerer" || unit.GetUnitType() == "Healer")
            {
                return 10;
            }
            return 0;
        }

        public double GetSpeedModifier(Unit unit)
        {
            if (unit.GetUnitType() == "PhantomAssain" || unit.GetUnitType() == "BountyHunter")
            {
                return 1.5;
            }
            if (unit.GetUnitType() == "Knight")
            {
                return 0.5;
            }
            return 1;
        }

        public bool IsPassable(Unit unit)
        {
            if (unit.GetUnitType() == "Tank")
            {
                return false;
            }
            return true;
        }

        public bool IsStuck(Unit unit)
        {
            return false;
        }
    }
}
