using System;

namespace MMO_RPG
{
    class HealerFactory : IUnitFactory
    {

        public Unit CreateUnit(int x, int y)
        {
            return new Healer(x, y);
        }

    }
}
