using System;

namespace MMO_RPG
{
    internal class TrapStrategy : IInteractionStrategy
    {
        private int damage;

        public TrapStrategy(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentNullException(nameof(damage));
            }
            this.damage = damage;
        }

        public void Apply(Unit unit)
        {
            unit.TakeDamage(damage);
        }
    }
}
