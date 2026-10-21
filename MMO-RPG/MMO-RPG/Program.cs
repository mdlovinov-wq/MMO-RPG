using System;
using System.Collections.Generic;

namespace MMO_RPG
{
    internal class Program
    {
        public static void Main()
        {

            Console.WriteLine("First scenary:");
            GameField firstField = new GameField(14, 14, 120);
            IUnitFactory factory = new PhantomAssasinFactory();
            firstField.FillWithUnits(factory, 111);

            foreach (Unit unit in firstField)
            {
                Console.WriteLine(unit.GetUnitType());
            }
            Console.WriteLine();
            Console.WriteLine("Second scenary:"); 
            GameField secondField = firstField.CloneField();
            Unit firstUnit = firstField.GetUnit(0, 0);
            Unit secondUnit = secondField.GetUnit(0, 0);
            firstUnit.Health.Decrease(10);
            Console.WriteLine(firstUnit.Health.CountHealthPoints());
            Console.WriteLine(secondUnit.Health.CountHealthPoints());

            Console.WriteLine();
            Console.WriteLine("Third scenary:");
            GameField thirdField = new GameField(10, 10, 3);
            thirdField.MoveFrom(secondField);
            Console.WriteLine(secondField.Size());
            Console.WriteLine(thirdField.Size());

            Console.WriteLine();
            Console.WriteLine("Fourth scenary:");
            List<Unit> unitsToRemove = new List<Unit>();
            foreach (Unit unit in thirdField)
            {
                unitsToRemove.Add(unit);
            }

            foreach (Unit unit in unitsToRemove)
            {
                thirdField.RemoveUnit(unit);
            }
            Console.WriteLine(thirdField.Size());

            Console.WriteLine();
            Console.WriteLine("Fifth scenary:");
            Console.WriteLine(firstField.Size());
            foreach (Unit unit in firstField)
            {
                firstField.RemoveUnit(unit);
            }
            Console.WriteLine(firstField.Size());
        }
    }
}
