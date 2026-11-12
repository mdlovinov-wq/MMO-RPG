using System;

namespace MMO_RPG
{
    class Healer : Mage
    {
        
        public Healer(int x, int y) : base(x, y,
            new Health(80), new Armor(10),
            new Attack(10), new AttackRange(5),
            new AttackSpeed(1), new DamageResist(1),
            new MoveSpeed(2))
        {
        }

        public Healer(Healer other) : base(other) { }

        public override Unit Clone()
        {
            return new Healer(this);
        }

        public override UnitType GetUnitType()
        {
            return UnitType.Healer;
        }

    }
}
