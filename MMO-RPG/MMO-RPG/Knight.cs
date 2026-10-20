using System;

namespace MMO_RPG
{
    class Knight : Swordsman
    {

        public Knight(int x, int y) : base(x, y,
            new Health(100), new Armor(30),
            new Attack(30), new AttackRange(3),
            new AttackSpeed(3))
        {
        }

        public Knight(Knight other) : base(other) { }

        public override Unit Clone()
        {
            return new Knight(this);
        }

        public override string GetUnitType()
        {
            return "Knight";
        }

    }
}
