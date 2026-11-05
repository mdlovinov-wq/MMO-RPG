using System;

namespace MMO_RPG
{
    internal class Mountains : ITerrain
    {
        public double GetDefenseBonus(Unit unit)
        {
            return 0;
        }

        public double GetSpeedModifier(Unit unit)
        {
            return 0;
        }

        public bool IsPassable(Unit unit)
        {
            if (unit.GetUnitType() != "Sorcerer" && unit.GetUnitType() != "Healer")
            {
                return true;
            }
            return false;
        }
    }
}
