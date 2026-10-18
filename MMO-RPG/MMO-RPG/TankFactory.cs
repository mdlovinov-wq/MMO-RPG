using System;

namespace MMO_RPG
{
    class TankFactory : IUnitFactory
    {

        public Unit CreateUnit(int x, int y)
        {
            return new Tank(x, y);
        }

    }
}
