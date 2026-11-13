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
            if (unit.GetUnitType() == UnitType.BountyHunter || unit.GetUnitType() == UnitType.Tank ||
                unit.GetUnitType() == UnitType.Knight)
            {
                return 0.5;
            }
            return 1;
        }

        public bool IsPassable(Unit unit)
        {
            if (unit.GetUnitType() == UnitType.PhantomAssasin)
            {
                return false;
            }
            return true;
        }

        public bool IsStuck(Unit unit)
        {
            if (unit.GetUnitType() == UnitType.Tank)
            {
                Random random = new Random();
                if (random.Next(1, 5) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public TerrainType GetTerrainType()
        {
            return TerrainType.Swamp;
        }
    }
}
