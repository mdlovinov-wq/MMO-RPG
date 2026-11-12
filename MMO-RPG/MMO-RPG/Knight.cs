using System;

namespace MMO_RPG
{
    class Knight : Swordsman
    {

        public Knight(int x, int y) : base(x, y,
            new Health(100), new Armor(30),
            new Attack(30), new AttackRange(3),
            new AttackSpeed(3), new DamageResist(7),
            new MoveSpeed(2))
        {
        }

        public Knight(Knight other) : base(other) { }

        public override Unit Clone()
        {
            return new Knight(this);
        }

        public override UnitType GetUnitType()
        {
            return UnitType.Knight;
        }

    }
}
