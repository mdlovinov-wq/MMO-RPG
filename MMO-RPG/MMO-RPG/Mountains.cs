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
            if (unit.GetUnitType() != UnitType.Sorcerer && unit.GetUnitType() != UnitType.Healer)
            {
                return true;
            }
            return false;
        }

        public bool IsStuck(Unit unit)
        {
            return false;
        }

        public TerrainType GetTerrainType()
        {
            return TerrainType.Mountain;
        }
    }
}
