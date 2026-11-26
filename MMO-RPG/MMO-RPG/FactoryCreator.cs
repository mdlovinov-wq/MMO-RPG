using System;
using System.Collections.Generic;

namespace MMO_RPG
{
    internal class FactoryCreator
    {

        private readonly Dictionary<string, IUnitFactory> factories = new
        {
            "Knight": new KnightFactory(),
            "Tank": new TankFactory(),
            "PhantomAssasin": new PhantomAssasinFactory(),
            "BountyHunter": new BountyHunter(),
            "Healer": new HealerFactory(),
            "Sorcerer": new SorcererFactory()
        }

        public static IUnitFactory GetFactory(string type)
        {
            if (!factories.ContainsKey(type))
            {
                throw new ArgumentException($"Unit type {type} does not exist");
            }
            return factories[type];
        }


    }
}
