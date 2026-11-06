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
            if (!gameField.IsCellFree(x, y))
            {
                throw new InvalidOperationException("You can't create unit here");
            }

            Unit unit = gameBase.CreateUnit(factory, x, y);
            gameField.AddUnit(unit, x, y);
            return unit;
        }

        public Base CreateBase(int x, int y, int maxUnits)
        {
            if (!gameField.IsCellFree(x, y))
            {
                throw new InvalidOperationException("You can't create base here");
            }

            Base gameBase = new Base(x, y, maxUnits, new Health(100), new DamageResist(0), 10);
            gameField.AddBase(gameBase, x, y);
            return gameBase;
        }

        public void MoveUnit(Unit unit, int x, int y)
        {
            
        }

    }
}
