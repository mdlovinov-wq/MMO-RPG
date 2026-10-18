using System;

namespace MMO_RPG
{
    class KnightFactory : IUnitFactory
    {
        public Unit CreateUnit(int x, int y)
        {
            return new Knight(x, y);
        }

    }
}
