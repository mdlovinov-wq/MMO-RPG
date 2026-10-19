using System;

namespace MMO_RPG
{
    internal class Program
    {
        public static void Main()
        {
            IUnitFactory tankFactory = new TankFactory();
            IUnitFactory sorcererFactory = new SorcererFactory();

            Unit tank = tankFactory.CreateUnit(1, 1);
            Unit sorcerer = sorcererFactory.CreateUnit(12, 2);
        }
    }
}
