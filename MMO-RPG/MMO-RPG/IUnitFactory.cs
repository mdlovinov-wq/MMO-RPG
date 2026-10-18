using System;

namespace MMO_RPG
{
    internal interface IUnitFactory
    {
        Unit CreateUnit(int x, int y);
    }
}
