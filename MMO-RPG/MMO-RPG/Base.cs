using System;
using System.Collections.Generic;

namespace MMO_RPG
{
    internal class Base : IObserver
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

        public int Resources { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Base(int x, int y, int maxUnits, Health initHealth, DamageResist defenseLevel, int resources)
        {
            if (x < 0 || y < 0)
                throw new ArgumentOutOfRangeException(nameof(x), "Coordinates cannot be negative");

            if (maxUnits <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxUnits), "MaxUnits must be positive");

            if (resources < 0)
                throw new ArgumentOutOfRangeException(nameof(resources), "Resources cannot be negative");
            if (initHealth == null)
            {
                throw new ArgumentNullException(nameof(initHealth));
            }
            if (defenseLevel == null)
            {
                throw new ArgumentNullException(nameof(defenseLevel));
            }
            X = x;
            Y = y;
            MaxUnits = maxUnits;
            Resources = resources;

            Health = new Health(initHealth);
            DefenseLevel = new DamageResist(defenseLevel);
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
            if (Resources < 3)
            {
                throw new InvalidOperationException("Not enough resources for creating");
            }
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
            unit.Subscribe(this);
            Resources -= 3;
            return unit;
        }

        public void IncreaseResources(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Count of amount new resources must be positive");
            }
            Resources += amount;
        }

        public void OnUnitEvent(UnitEvent unitEvent)
        {
            if (unitEvent.Type == UnitEventType.Died)
            {
                units.Remove(unitEvent.Unit);
                unitEvent.Unit.Unsubscribe(this);
            }
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentNullException(nameof(damage));
            }

            if (Health.IsDead())
            {
                return;
            }

            Health.Decrease(damage);
        }
    }
}
