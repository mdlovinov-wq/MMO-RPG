using System;


namespace MMO_RPG
{
    abstract class Unit
    {
        public abstract void Move(int x, int y);

        public abstract void Clone();

        public abstract string GetUnitType();
    }
}
