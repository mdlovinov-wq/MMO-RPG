using System;


namespace MMO_RPG
{
    class PhantomAssasin : Assasin
    {

        public PhantomAssasin(int x, int y) : base(x, y,
            new Health(90), new Armor(15),
            new Attack(40), new AttackRange(1),
            new AttackSpeed(2))
        {
        }

        public override Unit Clone()
        {
            return new PhantomAssasin(X, Y);
        }

        public override string GetUnitType()
        {
            return "PhantomAssasin";
        }

    }
}
