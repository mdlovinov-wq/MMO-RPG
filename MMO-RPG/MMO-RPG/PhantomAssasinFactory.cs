using System;

namespace MMO_RPG
{
    class PhantomAssasinFactory : IUnitFactory
    {

        public Unit CreateUnit(int x, int y)
        {
            return new PhantomAssasin(x, y);
        }

    }
}
