using System;


namespace MMO_RPG
{
    abstract class Unit
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Health Health { get; protected set; }
        public Armor Armor { get; protected set; }
        public Attack Attack { get; protected set; }

        public AttackRange AttackRange { get; protected set; }
        public AttackSpeed AttackSpeed { get; protected set; }


        protected Unit(int x, int y, Health health, Armor armor, Attack attack,
            AttackRange attackRange, AttackSpeed attackSpeed)
        {
            X = x;
            Y = y;
            Health = health;
            Armor = armor;
            Attack = attack;
            AttackRange = attackRange;
            AttackSpeed = attackSpeed;
        }

        protected Unit(Unit other)
        {
            X = other.X;
            Y = other.Y;

            Health = new Health(other.Health);
            Armor = new Armor(other.Armor);
            Attack = new Attack(other.Attack);
            AttackRange = new AttackRange(other.AttackRange);
            AttackSpeed = new AttackSpeed(other.AttackSpeed);
        }

        internal virtual void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract Unit Clone();

        public abstract string GetUnitType();
    }
}
