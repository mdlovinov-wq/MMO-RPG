using System;

namespace MMO_RPG
{
    internal class MoveSpeed
    {
        public int Current
        {
            get;
            private set;
        }
        public MoveSpeed(int initMoveSpeed)
        {
            if (initMoveSpeed < 0)
            {
                throw new ArgumentOutOfRangeException("Move speed can't be negative");
            }
            Current = initMoveSpeed;
        }

        public MoveSpeed(MoveSpeed other)
        {
            Current = other.Current;
        }

        public void DecreaseMoveSpeed(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Debuff must be positive");
            }
            Current = Math.Max(0, Current - amount); 
        }

        public void IncreaseMoveSpeed(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Buff must be positive");
            }
            Current += amount;
        }

    }
}
