using System;
using System.Collections.Generic;

namespace MMO_RPG
{
    internal class Base
    {

        private readonly List<Unit> units = new List<Unit>();

        public Health Health {
            get;
            private set;
        }

        public DamageResist DefenseLevel
        {
            get;
            private set;
        }

        public int MaxUnits { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Base(int x, int y, int maxUnits, Health initHealth, DamageResist defenseLevel)
        {
            X = x;
            Y = y;
            MaxUnits = maxUnits;
            Health = initHealth;
            DefenseLevel = defenseLevel;
        }

        public Base(Base other)
        {

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            X = other.X;
            Y = other.Y;
            MaxUnits = other.MaxUnits;
            Health = new Health(other.Health);
            DefenseLevel = new DamageResist(other.DefenseLevel);

            foreach (Unit unit in other.units)
            {
                units.Add(unit.Clone());
            }
        }

        public Unit CreateUnit(IUnitFactory factory, int x, int y)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (units.Count == MaxUnits)
            {
                throw new InvalidOperationException("Limit of untis has been reached");
            }
            Unit unit = factory.CreateUnit(x, y);
            units.Add(unit);
            return unit;
        }

    }
}
