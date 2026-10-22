using System;
using System.Collections;
using System.Collections.Generic;

namespace MMO_RPG
{
    class GameField : IEnumerable<Unit>
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

        public GameField(GameField other) : this(other.width, other.height, other.maxUnits)
        {
            foreach(Unit unit in other.units)
            {
                Unit clone = unit.Clone();
                AddUnit(clone, clone.X, clone.Y);
            }
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

        public void RemoveUnit(Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            if (!units.Remove(unit))
            {
                throw new InvalidOperationException("Unit doesn't exist");
            }

        }

        public int Size()
        {
            return units.Count;
        }

        public bool IsEmpty()
        {
            return units.Count == 0;
        }

        public void Clear()
        {
            units.Clear();
        }

        public GameField CloneField()
        {
            return new GameField(this);
            
        }
        
        public static GameField CreateByMoving(GameField other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            GameField newField = new GameField(
                other.width,
                other.height,
                other.maxUnits
                );

            newField.units = other.units;
            other.units = new List<Unit>();

            return newField;
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
            return null;
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

        public IEnumerator<Unit> GetEnumerator()
        {
            foreach(Unit unit in units.ToArray())
            {
                yield return unit;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
