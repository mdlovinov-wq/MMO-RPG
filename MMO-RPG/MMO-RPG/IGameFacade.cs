using System;

namespace MMO_RPG
{
    internal interface IGameFacade
    {

        Unit CreateUnit(string type, int baseId, int x, int y);
        void MoveUnit(int unitId, Direction direction);
        void AttackUnit(int attackerId, int targetId);
        void AttackBase(int attackerId, int gameBaseId);
        Base CreateBase(int x, int y, int maxUnits);
        void CreateNeutral(NeutralObjects neutral);
        void HealUnit(int unitId, int amount);
        void BuildBuilding(string type);
    }
}
