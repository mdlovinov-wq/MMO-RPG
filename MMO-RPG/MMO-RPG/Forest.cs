using System;

namespace MMO_RPG
{
    internal class Forest : ITerrain
    {
        public double GetDefenseBonus(Unit unit)
        {
            if (unit.GetUnitType() == UnitType.Sorcerer || unit.GetUnitType() == UnitType.Healer)
            {
                return 10;
            }
            return 0;
        }

        public double GetSpeedModifier(Unit unit)
        {
            if (unit.GetUnitType() == UnitType.PhantomAssasin || unit.GetUnitType() == UnitType.BountyHunter)
            {
                return 1.5;
            }
            if (unit.GetUnitType() == UnitType.Knight)
            {
                return 0.5;
            }
            return 1;
        }

        public bool IsPassable(Unit unit)
        {
            if (unit.GetUnitType() == UnitType.Tank)
            {
                return false;
            }
            return true;
        }

        public bool IsStuck(Unit unit)
        {
            return false;
        }

        public TerrainType GetTerrainType()
        {
            return TerrainType.Forest;
        }
    }
}
