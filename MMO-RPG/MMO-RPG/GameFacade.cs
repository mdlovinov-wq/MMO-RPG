using System;

namespace MMO_RPG
{
    internal class GameFacade : IGameFacade
    {

        private readonly GameMediator mediator;

        public GameFacade(GameField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            mediator = new GameMediator(field);
        }

        public void MoveUnit(int unitId, Direction direction)
        {
            mediator.MoveUnit(unitId, direction);
        }

        public void AttackUnit(int attackerId, int targetId)
        {
            mediator.AttackUnit(attackerId, targetId);
        }

    }
}
