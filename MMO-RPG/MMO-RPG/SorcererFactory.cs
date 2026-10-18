using System;

namespace MMO_RPG
{
    class SorcererFactory : IUnitFactory
    {

        public Unit CreateUnit(int x, int y)
        {
            return new Sorcerer(x, y);
        }

    }
}
