using System;


namespace MMO_RPG
{
    internal class Plain : ITerrain
    {
        public double GetDefenseBonus(Unit unit)
        {
            return 0;
        }

        public double GetSpeedModifier(Unit unit)
        {
            return 1;
        }

        public bool IsPassable(Unit unit)
        {
            return true;
        }

        public bool IsStuck(Unit unit)
        {
            return false;
        }

        public TerrainType GetTerrainType()
        {
            return TerrainType.Plain;
        }
    }
}
