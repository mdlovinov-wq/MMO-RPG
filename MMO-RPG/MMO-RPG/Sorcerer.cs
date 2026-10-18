using System;

namespace MMO_RPG
{
    class Sorcerer : Mage
    {

        public Sorcerer(int x, int y) : base(x, y,
            new Health(90), new Armor(10),
            new Attack(17), new AttackRange(6),
            new AttackSpeed(2))
        {
        }

        public override Unit Clone()
        {
            return new Sorcerer(X, Y);
        }

        public override string GetUnitType()
        {
            return "Sorcerer";
        }

    }
}
