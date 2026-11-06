using System;

namespace MMO_RPG
{
    interface ITerrain
    {

        bool IsPassable(Unit unit);
        double GetSpeedModifier(Unit unit);
        double GetDefenseBonus(Unit unit);
        bool IsStuck(Unit unit);

    }
}
