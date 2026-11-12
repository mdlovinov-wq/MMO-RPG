using System;
using System.Security.Policy;

namespace MMO_RPG
{
    internal class GameController
    {
        private readonly GameField gameField;
        public GameController(GameField gameField)
        {
            if (gameField == null)
            {
                throw new ArgumentNullException(nameof(gameField));
            }
            this.gameField = gameField;
        }

        public Unit CreateUnit(Base gameBase, IUnitFactory factory, int x, int y)
        {
            if (gameBase == null)
            {
                throw new ArgumentNullException(nameof(gameBase));
            }
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            if (gameField.GetBase(x, y) == null)
            {
                throw new InvalidOperationException("Base doesn't exist on field");
            }
            if (!gameField.IsCellValid(x, y))
            {
                throw new InvalidOperationException("You can't create unit here");
            }

            Unit unit = gameBase.CreateUnit(factory, x, y);
            gameField.AddUnit(unit, x, y);
            return unit;
        }

        public Base CreateBase(int x, int y, int maxUnits)
        {
            if (!gameField.IsCellValid(x, y))
            {
                throw new InvalidOperationException("You can't create base here");
            }

            Base gameBase = new Base(x, y, maxUnits, new Health(100), new DamageResist(0), 10);
            gameField.AddBase(gameBase, x, y);
            return gameBase;
        }

        public void MoveUnit(Unit unit, int x, int y)
        {

            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            if (!gameField.IsCellValid(x, y))
            {
                throw new InvalidOperationException("You can't move unit here");
            }

            if (gameField.GetUnit(unit.X, unit.Y) != unit)
            {
                throw new InvalidOperationException("Unit doesn't exist on field");
            }

            ITerrain terrain = gameField.TerrainMap.GetTerrain(x, y);
            if (terrain.IsStuck(unit))
            {
                throw new InvalidOperationException("Unit stucked");
            }

            if (!terrain.IsPassable(unit))
            {
                throw new InvalidOperationException("Terrain is not passable");

            }
            gameField.MoveUnit(unit, x, y);
            unit.SetTerrainDefenseBonus(terrain.GetDefenseBonus(unit));
            unit.SetTerrainSpeedBonus(terrain.GetSpeedModifier(unit));
        }

        public void AttackUnit(Unit unitAttack, Unit unitDefense)
        {
            if (unitAttack == null)
            {
                throw new ArgumentNullException(nameof(unitAttack));
            }
            if (unitDefense == null)
            {
                throw new ArgumentNullException(nameof(unitDefense));
            }
            if (ReferenceEquals(unitAttack, unitDefense))
            {
                throw new InvalidOperationException("Unit cannot attack itself");
            }

            if (!ReferenceEquals(gameField.GetUnit(unitAttack.X, unitAttack.Y), unitAttack))
            {
                throw new InvalidOperationException("Attacker is not on the field");
            }

            if (!ReferenceEquals(gameField.GetUnit(unitDefense.X, unitDefense.Y), unitDefense))
            {
                throw new InvalidOperationException("Defender is not on the field");
            }

            int distance = Math.Abs(unitAttack.X - unitDefense.X) + Math.Abs(unitAttack.Y - unitDefense.Y);
            if (distance > unitAttack.AttackRange.Current)
            {
                throw new InvalidOperationException("Target is out of attack range");
            }

            int damage = unitAttack.Attack.CalculateDamage(unitDefense.Armor, new DamageResist(unitDefense.EffectiveDamageResist));
            unitDefense.TakeDamage(damage);
        }

        public void AttackBase(Unit unit, Base gameBase)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }
            if (gameBase == null)
            {
                throw new ArgumentNullException(nameof(gameBase));
            }
            if (!ReferenceEquals(gameField.GetUnit(unit.X, unit.Y), unit))
            {
                throw new InvalidOperationException("Unit does not exist on the field");
            }
            if (!ReferenceEquals(gameField.GetBase(gameBase.X, gameBase.Y), gameBase))
            {
                throw new InvalidOperationException("Base does not exist on the field");
            }

            int distance = Math.Abs(unit.X - gameBase.X) + Math.Abs(unit.Y - gameBase.Y);
            if (distance > unit.AttackRange.Current)
            {
                throw new InvalidOperationException("Targer is out of attack range");
            }
            int damage = unit.Attack.CalculateDamage(new Armor(0), gameBase.DefenseLevel);
            gameBase.TakeDamage(damage);
        }

        public void CreateNeutral(NeutralObjects neutral)
        {
            if (neutral == null)
            {
                throw new ArgumentNullException(nameof(neutral));
            }
            if (!gameField.IsCellValid(neutral.X, neutral.Y))
            {
                throw new InvalidOperationException("You can't create neutral object here");
            }

            gameField.AddNeutralObject(neutral);
        }

    }
}
