using System;

namespace MMO_RPG
{
    class BountyHunter : Assasin
    {

        public BountyHunter(int x, int y) : base(x, y,
            new Health(100), new Armor(15),
            new Attack(35), new AttackRange(2),
            new AttackSpeed(2), new DamageResist(3), 
            new MoveSpeed(3))
        {
        }

        public BountyHunter(BountyHunter other) : base(other) { }

        public override Unit Clone()
        {
            return new BountyHunter(this);
        }

        public override UnitType GetUnitType()
        {
            return UnitType.BountyHunter;
        }

    }
}
