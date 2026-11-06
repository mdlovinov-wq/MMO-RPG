using System;

namespace MMO_RPG
{
    internal class TerrainProxy : ITerrain
    {

        private readonly ITerrain terrain;

        public TerrainProxy(ITerrain terrain)
        {
            if (terrain == null)
            {
                throw new ArgumentNullException(nameof(terrain));
            }
            this.terrain = terrain;
        }
        public double GetDefenseBonus(Unit unit)
        {
            return terrain.GetDefenseBonus(unit);
        }

        public double GetSpeedModifier(Unit unit)
        {
            return terrain.GetSpeedModifier(unit);
        }

        public bool IsPassable(Unit unit)
        {
            return terrain.IsPassable(unit);
        }

        public bool IsStuck(Unit unit)
        {
            return terrain.IsStuck(unit);
        }
    }
}
