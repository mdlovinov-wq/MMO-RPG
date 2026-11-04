using System;

namespace MMO_RPG
{
    internal class Forest : ITerrain
    {
        public double GetDefenseBonus(Unit unit)
        {
            throw new NotImplementedException();
        }

        public double GetSpeedModifier(Unit unit)
        {
            throw new NotImplementedException();
        }

        public bool IsPassable(Unit unit)
        {
            throw new NotImplementedException();
        }
    }
}
