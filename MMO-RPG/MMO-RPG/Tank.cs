using System;

namespace MMO_RPG
{
    class Tank : Swordsman
    {

        public Tank(int x, int y) : base(x, y, 
            new Health(130), new Armor(70),
            new Attack(35), new AttackRange(1), 
            new AttackSpeed(1),  new DamageResist(10), 
            new MoveSpeed(1))
        {
        }

        public Tank(Tank other) : base(other) { }

        public override Unit Clone()
        {
            return new Tank(this);
        }

        public override UnitType GetUnitType()
        {
            return UnitType.Tank;
        }

    }
}
