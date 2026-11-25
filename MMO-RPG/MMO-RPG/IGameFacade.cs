using System;

namespace MMO_RPG
{
    internal interface IGameFacade
    {

        Unit CreateUnit(int x, int y);
        void MoveUnit(Unit unit, Direction direction);
        void Attack(Unit damager, Unit defender);
        void CollectResource(Unit unit, int resources);
    }
}
