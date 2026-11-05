using System;

namespace MMO_RPG
{
    internal class Swamp : ITerrain
    {
        public double GetDefenseBonus(Unit unit)
        {
            return 0;
        }

        public double GetSpeedModifier(Unit unit)
        {
            if (unit.GetUnitType() == "BountyHunter" || unit.GetUnitType() == "Tank" ||
                unit.GetUnitType() == "Knight")
            {
                return 0.5;
            }
            return 1;
        }

        public bool IsPassable(Unit unit)
        {
            if (unit.GetUnitType() == "PhantomAssasin")
            {
                return false;
            }
            return true;
        }

        public bool IsStuck(Unit unit)
        {
            if (unit.GetUnitType() == "Tank")
            {
                Random random = new Random();
                if (random.Next(1, 5) == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
