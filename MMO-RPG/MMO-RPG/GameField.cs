using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

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
            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentException("Coordinates must be between width and height");
            }
            if (unit == null)
            {
                throw new ArgumentException(nameof(unit));
            }
            if (GetUnit(x, y) == null)
            {
                if (units.Count >= maxUnits)
                {
                    throw new InvalidOperationException("Maximum number of units reached");
                }
                unit.Move(x, y);
                units.Add(unit);
            }
            else
            {
                throw new InvalidOperationException("Cell is already occupied");
            }
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
            foreach (Unit unit in units)
            {
                if (unit.X == x && unit.Y == y)
                {
                    return unit;
                }
            }
            throw new InvalidOperationException("Unit doesn't exist");
        }

        public void FillWithUnits(IUnitFactory factory, int count)
        {

            if (factory == null)
            {
                throw new ArgumentException(nameof(factory));
            }

            if (count < 0)
            {
                throw new ArgumentException(nameof(count));
            }
            int coordX = 0;
            int coordY = 0;
            while (count != 0)
            {

                if (coordX >= width)
                {
                    coordX = 0;
                    coordY++;
                }

                if (coordX < 0 || coordY < 0 || coordY >= height)
                {
                    throw new InvalidOperationException("Too many units for this size of field");
                }

                if (GetUnit(coordX, coordY) == null)
                {
                    Unit unit = factory.CreateUnit(coordX, coordY);

                    AddUnit(unit, coordX, coordY);
                    count--;
                }

                coordX++;

            }
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
