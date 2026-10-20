using System;

namespace MMO_RPG
{
    internal class Program
    {
        public static void Main()
        {
            IUnitFactory tankFactory = new TankFactory();
            IUnitFactory sorcererFactory = new SorcererFactory();

            Unit tank = new Tank(1, 1);
            Unit tank2 = tank.Clone();
            tank2.Health.Decrease(20);
            tank2.Move(2, 2);
            return;
        }
    }
}
