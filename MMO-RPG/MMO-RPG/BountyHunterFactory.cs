using System;

namespace MMO_RPG
{
    class BountyHunterFactory : IUnitFactory
    {

        public Unit CreateUnit(int x, int y)
        {
            return new BountyHunter(x, y);
        }

    }
}
