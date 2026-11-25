using System;

namespace MMO_RPG
{
    internal interface IGameFacade
    {

        Unit CreateUnit(Base gameBase, IUnitFactory factory, int x, int y);
        void MoveUnit(int unitId, Direction direction);
        void AttackUnit(int attackerId, int targetId);
        void AttackBase(Unit attacker, Base gameBase);
        Base CreateBase(int x, int y, int maxUnits);
        void CreateNeutral(NeutralObjects neutral);
    }
}
