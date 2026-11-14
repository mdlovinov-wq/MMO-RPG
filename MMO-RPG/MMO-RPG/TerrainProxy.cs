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

        public TerrainType GetTerrainType()
        {
            return terrain.GetTerrainType();
        }

        public bool IsPassable(Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
                

            bool result = terrain.IsPassable(unit);

            Console.WriteLine($"[Proxy] {unit.GetUnitType()} | " + $"{terrain.GetTerrainType()} | Passable: {result}");

            return result;

        }

        public bool IsStuck(Unit unit)
        {
            return terrain.IsStuck(unit);
        }
    }
}
