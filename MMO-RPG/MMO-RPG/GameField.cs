using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MMO_RPG
{
    class GameField : IEnumerable<Unit>
    {
        private int width;
        private int height;
        private int maxUnits;
        private int maxBases;
        private List<Unit> units;
        private List<Base> bases;
        public TerrainMap TerrainMap
        {
            get;
        }

        public GameField(int width, int height, int maxUnits, int maxBases)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Size must be positive");
            }
            if (maxUnits <= 0)
            {
                throw new ArgumentException("Count of units must be positive");
            }
            if (maxBases <= 0)
            {
                throw new ArgumentException("Count of bases must be positive");
            }
            this.width = width;
            this.height = height;
            this.maxUnits = maxUnits;
            this.maxBases = maxBases;

            units = new List<Unit>();
            bases = new List<Base>();
            TerrainMap = new TerrainMap(width, height);
        }

        public GameField(GameField other) : this(other.width, other.height, other.maxUnits, other.maxBases)
        {
            foreach(Unit unit in other.units)
            {
                Unit clone = unit.Clone();
                AddUnit(clone, clone.X, clone.Y);
            }
        }

        public void AddUnit(Unit unit, int x, int y)
        {

            if (unit == null)
            {
                throw new ArgumentException(nameof(unit));
            }

            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentException("Coordinates must be between width and height");
            }
            
            if (units.Any(u => ReferenceEquals(u, unit)))
            {
                throw new InvalidOperationException("Unit already exists on this field");
            }
            if (GetUnit(x, y) == null && GetBase(x, y) == null)
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

        public void AddBase(Base gameBase, int x, int y)
        {

            if (gameBase == null)
            {
                throw new ArgumentException(nameof(gameBase));
            }

            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentException("Coordinates must be between width and height");
            }

            if (bases.Any(b => ReferenceEquals(b, gameBase)))
            {
                throw new InvalidOperationException("Base already exists on this field");
            }
            if (GetUnit(x, y) == null && GetBase(x, y) == null)
            {
                if (bases.Count >= maxBases)
                {
                    throw new InvalidOperationException("Maximum number of bases reached");
                }
                bases.Add(gameBase);
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

        public void RemoveBase(Base gameBase)
        {
            if (gameBase == null)
            {
                throw new ArgumentNullException(nameof(gameBase));
            }

            if (!bases.Remove(gameBase))
            {
                throw new InvalidOperationException("Base doesn't exist");
            }

        }

        public int UnitsCount()
        {
            return units.Count;
        }
        public int BasesCount()
        {
            return bases.Count;
        }

        public bool IsEmpty()
        {
            return units.Count == 0 && bases.Count == 0;
        }

        public void Clear()
        {
            units.Clear();
            bases.Clear();
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
                other.maxUnits,
                other.maxBases
                );

            newField.units = other.units;
            other.units = new List<Unit>();
            newField.bases = other.bases;
            other.bases = new List<Base>();

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

        public Unit GetUnit(int index)
        {
            if (index < 0 || index >= units.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            return units[index];
        }

        public Base GetBase(int x, int y)
        {
            foreach (Base gameBase in bases)
            {
                if (gameBase.X == x && gameBase.Y == y)
                {
                    return gameBase;
                }
            }
            return null;
        }

        public Base GetBase(int index)
        {
            if (index < 0 || index >= bases.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            return bases[index];
        }

        public void MoveUnit(Unit unit, int x, int y)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            if (!units.Contains(unit))
            {
                throw new InvalidOperationException("Unit doesn't exist on this field");
            }

            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentException("Coordinates outside the field");
            }

            Unit otherUnit = GetUnit(x, y);

            if (otherUnit != null && ReferenceEquals(unit, otherUnit))
            {
                throw new InvalidOperationException("Cell is already occupied");
            }

            unit.Move(x, y);

        }

        public bool IsCellFree(int x, int y)
        {
            if (GetBase(x, y) != null || GetUnit(x, y) != null)
            {
                return false;
            }
            return true;
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

        public IEnumerable<Base> GetBases()
        {
            foreach (Base gameBase in bases.ToArray())
            {
                yield return gameBase;
            }
        }

    }
}
