using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace MMO_RPG
{
    class GameField
    {
        private int width;
        private int height;
        private int maxUnits;
        private List<Unit> units;

        public GameField(int width, int height, int maxUnits)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Size must be positive");
            }
            if (maxUnits <= 0)
            {
                throw new ArgumentException("Count of units must be positive");
            }
            this.width = width;
            this.height = height;
            this.maxUnits = maxUnits;

            units = new List<Unit>();
        }

        public void AddUnit(Unit unit, int x, int y)
        {

        }

        public void DeleteUnit(Unit unit)
        {

        }

        public GameField CloneField()
        {
            GameField other = new GameField(0, 0, 1);
            return other;
        }

        public void MoveFrom(GameField other)
        {
            if (ReferenceEquals(this, other))
            {
                return;
            }
            this.units = other.units;
            other.units = new List<Unit>();

            this.width = other.width;
            other.width = 0;

            this.height = other.height;
            other.height = 0;

            this.maxUnits = other.maxUnits;
            other.maxUnits = 0;
        }

        public Unit GetUnit(int x, int y)
        {
            Unit test = new Assasin();
            return test;
        }

        public GameFieldIterator CreateIterator()
        {
            return new GameFieldIterator(units);
        }

    }

    class GameFieldIterator
    {
        private readonly List<Unit> units;
        int position = 0;
        public GameFieldIterator(List<Unit> units)
        {
            this.units = units;
        }

        public bool HasNext()
        {
            return position < units.Count;
        }

        public Unit Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("There's no next unit");
            }
            return units[position++];
        }
    }
}
