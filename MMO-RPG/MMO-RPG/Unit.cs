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

        public DamageResist DamageResist { get; protected set; }
        public MoveSpeed MoveSpeed { get; protected set; }

        public double TerrainDefenseBonus { get; private set; }
        public double TerrainSpeedBonus { get; private set; }

        protected Unit(int x, int y, Health health, Armor armor, Attack attack,
            AttackRange attackRange, AttackSpeed attackSpeed, DamageResist damageResist, 
            MoveSpeed moveSpeed)
        {
            X = x;
            Y = y;
            Health = health;
            Armor = armor;
            Attack = attack;
            AttackRange = attackRange;
            AttackSpeed = attackSpeed;
            DamageResist = damageResist;
            MoveSpeed = moveSpeed;
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
            DamageResist = new DamageResist(other.DamageResist);
            MoveSpeed = new MoveSpeed(other.MoveSpeed);
        }

        internal virtual void Move(int x, int y)
        {
            X = x;
            Y = y; 
        }

        public abstract Unit Clone();

        public abstract string GetUnitType();

        internal virtual void SetTerrainDefenseBonus(double bonus)
        {
            if (double.IsNaN(bonus) || double.IsInfinity(bonus))
            {
                throw new ArgumentOutOfRangeException(nameof(bonus));
            }

            TerrainDefenseBonus = bonus;
        }

        public double EffectiveDamageResist
        {
            get
            {
                double result = DamageResist.Current + TerrainDefenseBonus;
                if (result < 0)
                {
                    return 0;
                }
                if (result > 100)
                {
                    return 100;
                }
                return result;
            }
        }

        internal virtual void SetTerrainSpeedBonus(double bonus)
        {
            if (double.IsNaN(bonus) || double.IsInfinity(bonus))
            {
                throw new ArgumentOutOfRangeException(nameof(bonus));
            }

            TerrainSpeedBonus = bonus;
        }

        public double EffectiveSpeed
        {
            get
            {
                double result = MoveSpeed.Current + TerrainSpeedBonus;
                if (result < 0)
                {
                    return 0;
                }
                if (result > 100)
                {
                    return 100;
                }
                return result;
            }
        }
    }
}
