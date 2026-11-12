using System;


namespace MMO_RPG
{
    class PhantomAssasin : Assasin
    {

        public PhantomAssasin(int x, int y) : base(x, y,
            new Health(90), new Armor(15),
            new Attack(40), new AttackRange(1),
            new AttackSpeed(2), new DamageResist(3),
            new MoveSpeed(3))
        {
        }

        public PhantomAssasin(PhantomAssasin other) : base(other) { }

        public override Unit Clone()
        {
            return new PhantomAssasin(this);
        }

        public override UnitType GetUnitType()
        {
            return UnitType.PhantomAssasin;
        }

    }
}
