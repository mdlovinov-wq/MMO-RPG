using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace MMO_RPG
{
    internal class GameMediator
    {
        private readonly GameField gameField;
        public GameMediator(GameField gameField)
        {
            if (gameField == null)
            {
                throw new ArgumentNullException(nameof(gameField));
            }
            this.gameField = gameField;
        }

        public Unit CreateUnit(string type, int baseId, int x, int y)
        {
            Base gameBase = bases[baseId];
            IUnitFactory factory = FactoryCreator.GetFactory(type);
            if (gameBase == null)
            {
                throw new ArgumentNullException(nameof(gameBase));
            }
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            if (!ReferenceEquals(gameField.GetBase(gameBase.X, gameBase.Y), gameBase))
            {
                throw new InvalidOperationException("Base doesn't exist on field");
            }
            if (!gameField.IsCellValid(x, y))
            {
                throw new InvalidOperationException("You can't create unit here");
            }
            if (gameField.IsFull)
            {
                throw new InvalidOperationException("Maximum number of units on field reached");
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

        public void MoveUnit(int unitId, Direction direction)
        {
            Unit unit = gameField.UnitById(unitId);
            List<int> newCoordinates = gameField.NewCoordinates(unit, direction);
            int x = newCoordinates[0];
            int y = newCoordinates[1];
            if (!gameField.IsCellValid(x, y))
            {
                throw new InvalidOperationException("You can't move unit here");
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
            NeutralObjects neutral = gameField.GetNeutral(x, y);
            if (neutral != null)
            {
                switch (neutral.GetNeutralType())
                {
                    case NeutralType.Altar:
                        unit = unit * (Altar)neutral;
                        RemoveNeutral(neutral);
                        break;
                    case NeutralType.Chest:
                        unit = unit + (Chest)neutral;
                        RemoveNeutral(neutral);
                        break;
                    case NeutralType.Source:
                        unit = unit ^ (EnergySource)neutral;
                        RemoveNeutral(neutral);
                        break;
                    case NeutralType.Trap:
                        unit = unit - (Trap)neutral;
                        RemoveNeutral(neutral);
                        break;
                }
            }
        }

        public void AttackUnit(int attackerId, int targetId)
        {
            unitAttack = gameField.UnitById(attackerId);
            unitDefense = gameField.UnitById(targetId);
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

            gameField.AddNeutralObject(neutral, neutral.X, neutral.Y);
        }

        public void RemoveNeutral(NeutralObjects neutral)
        {
            if (neutral == null)
            {
                throw new ArgumentNullException(nameof(neutral));
            }
            if (!ReferenceEquals(gameField.GetNeutral(neutral.X, neutral.Y), neutral))
            {
                throw new InvalidOperationException("Neutral object does not exist on the field");
            }
            gameField.RemoveNeutral(neutral);
        }

    }
}
