using System;

namespace MMO_RPG
{
    class Healer : Mage
    {
        
        public Healer(int x, int y) : base(x, y,
            new Health(80), new Armor(10),
            new Attack(10), new AttackRange(5),
            new AttackSpeed(1))
        {

        }

        public override Unit Clone()
        {
            return new Healer(X, Y);
        }

        public override string GetUnitType()
        {
            return "Healer";
        }

    }
}
