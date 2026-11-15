using System;
using System.Collections.Concurrent;

namespace MMO_RPG
{
    internal class Program
    {
        public static void Main()
        {

            Scenario1();
            Console.ReadKey();
            Console.Clear();

            Scenario2();
            Console.ReadKey();
            Console.Clear();

            Scenario3();
            Console.ReadKey();
            Console.Clear();

            Scenario4();
            Console.ReadKey();

        }

        private static void Scenario1()
        {

            Console.WriteLine("Scenario 1");
            Console.WriteLine("Base and units");
            Console.WriteLine();

            GameField field = new GameField(10, 10, 50, 10);
            Log("Gamefield was created");
            GameController controller = new GameController(field);

            IUnitFactory factory = null;
            Base gameBase = controller.CreateBase(0, 0, 10);
            Log("The first base was created");
            Random random = new Random();
            switch (random.Next(1, 6))
            {
                case 1:
                    factory = new TankFactory();
                    break;
                case 2:
                    factory = new PhantomAssasinFactory();
                    break;
                case 3:
                    factory = new BountyHunterFactory();
                    break;
                case 4:
                    factory = new SorcererFactory();
                    break;
                case 5:
                    factory = new HealerFactory();
                    break;
            }

            int count = random.Next(1, 4);
            int x;
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    x = random.Next(0, field.Width - 1);
                    try
                    {
                        controller.CreateUnit(gameBase, factory, x, 1);
                        break;
                    }
                    catch (InvalidOperationException)
                    {
                        continue;
                    }
                }
                
                Log("Unit for the first base is created");
            }

            factory = new KnightFactory();
            Base otherGameBase = controller.CreateBase(field.Width - 1, field.Height - 1, 10);
            Log("The second base was created");
            count = random.Next(1, 4);
            for (int i = 0; i < count; i++)
            {
                while (true)
                {
                    x = random.Next(0, field.Width - 1);
                    try
                    {
                        controller.CreateUnit(otherGameBase, factory, x, field.Height - 2);
                        break;
                    }
                    catch (InvalidOperationException)
                    {
                        continue;
                    }
                }
                Log("Unit for the second base is created");
            }

            ConsoleRender renderer = new ConsoleRender();
            renderer.Render(field, 10, 10);
        }

        private static void Scenario2()
        {
            Console.WriteLine("Scenario 2");
            Console.WriteLine("Landscapes and proxy");
            Console.WriteLine();

            GameField field = new GameField(10, 10, 6, 2);
            Log("Gamefield was created");
            GameController controller = new GameController(field);


            for (int x = 1; x < 3; x++)
            {
                for (int y = 1; y < 3; y++)
                {
                    field.TerrainMap.SetTerrain(x, y, new Forest());
                    Log($"Forest was placed on [{x}, {y}]");
                }
            }
            for (int x = 3; x < 5; x++)
            {
                for (int y = 3; y < 5; y++)
                {
                    field.TerrainMap.SetTerrain(x, y, new Swamp());
                    Log($"Swamp was placed on [{x}, {y}]");
                }
            }
            for (int x = 5; x < 7; x++)
            {
                for (int y = 5; y < 7; y++)
                {
                    field.TerrainMap.SetTerrain(x, y, new Mountains());
                    Log($"Mountain was placed on [{x}, {y}]");
                }
            }

            Base gameBase = controller.CreateBase(0, 0, 3);
            Log("The first base was created");
            Base otherGameBase = controller.CreateBase(9, 9, 3);
            Log("The second base was created");

            IUnitFactory factory = new SorcererFactory();
            controller.CreateUnit(gameBase, factory, 1, 0);
            Log("Sorcerer was created");
            controller.CreateUnit(gameBase, factory, 5, 4);
            Log("Sorcerer was created");
            factory = new PhantomAssasinFactory();
            controller.CreateUnit(gameBase, factory, 2, 5);
            Log("Phantom Assasin was created");
            controller.CreateUnit(otherGameBase, factory, 3, 7);
            Log("Phantom Assasin was created");
            factory = new KnightFactory();
            controller.CreateUnit(otherGameBase, factory, 4, 2);
            Log("Knight was created");
            factory = new TankFactory();
            controller.CreateUnit(otherGameBase, factory, 6, 7);
            Log("Tank was created");

            ConsoleRender renderer = new ConsoleRender();
            renderer.Render(field, 10, 10);
            Unit current;
            bool isPassable;
            double defenseBonus, speedModifier;
            current = field.GetUnit(1, 0);
            controller.MoveUnit(current, Direction.Down); 
            defenseBonus = current.EffectiveDamageResist;
            Console.WriteLine($"Defense level of sorcerer in forest: {defenseBonus}");
            current = field.GetUnit(2, 5);
            controller.MoveUnit(current, Direction.Up);
            speedModifier = current.EffectiveSpeed;
            Console.WriteLine($"Speed of phantom assasin in forest: {speedModifier}");
            current = field.GetUnit(3, 7);
            try
            {
                controller.MoveUnit(current, Direction.Up);
                isPassable = true;
            }
            catch(InvalidOperationException)
            {
                isPassable = false;
            }
            Console.WriteLine($"Can phantom assasin pass swamp: {isPassable}");
            current = field.GetUnit(4, 2);
            controller.MoveUnit(current, Direction.Down);
            speedModifier = current.EffectiveSpeed;
            Console.WriteLine($"Speed of knight in swamp: {speedModifier}");
            current = field.GetUnit(5, 4);
            try
            {
                controller.MoveUnit(current, Direction.Down);
                isPassable = true;
            }
            catch (InvalidOperationException)
            {
                isPassable = false;
            }
            Console.WriteLine($"Can sorcerer pass mountain: {isPassable}");
            current = field.GetUnit(6, 7);
            try
            {
                controller.MoveUnit(current, Direction.Up);
                isPassable = true;
            }
            catch (InvalidOperationException)
            {
                isPassable = false;
            }
            Console.WriteLine($"Can tank pass mountain: {isPassable}");

            renderer.Render(field, 10, 10);
        }

        private static void Scenario3()
        {
            Console.WriteLine("Scenario 3");
            Console.WriteLine("Neutral objects");
            Console.WriteLine();

            GameField field = new GameField(10, 10, 50, 10);
            Log("Gamefield was created");
            GameController controller = new GameController(field);

            Base gameBase = controller.CreateBase(0, 0, 10);
            Log("The first base was created");
            IUnitFactory factory = new KnightFactory();
            controller.CreateUnit(gameBase, factory, 1, 1);
            Log("Unit was created");
            factory = new TankFactory();
            controller.CreateUnit(gameBase, factory, 3, 1);
            Log("Unit was created");
            factory = new SorcererFactory();
            controller.CreateUnit(gameBase, factory, 5, 1);
            Log("Unit was created");

            NeutralObjects altar = new Altar(1, 3);
            controller.CreateNeutral(altar);
            Log("Altar was created");
            altar = new Altar(3, 2);
            controller.CreateNeutral(altar);
            Log("Altar was created");
            altar = new Altar(5, 3);
            controller.CreateNeutral(altar);
            Log("Altar was created");

            NeutralObjects trap = new Trap(1, 5);
            controller.CreateNeutral(trap);
            Log("Trap was created");
            trap = new Trap(3, 3);
            controller.CreateNeutral(trap);
            Log("Trap was created");
            trap = new Trap(5, 5);
            controller.CreateNeutral(trap);
            Log("Trap was created");

            NeutralObjects energySource = new EnergySource(1, 7);
            controller.CreateNeutral(energySource);
            Log("Energy source was created");
            energySource = new EnergySource(3, 4);
            controller.CreateNeutral(energySource);
            Log("Energy source was created");
            energySource = new EnergySource(5, 7);
            controller.CreateNeutral(energySource);
            Log("Energy source was created");

            NeutralObjects chest = new Chest(1, 9, 10);
            controller.CreateNeutral(chest);
            Log("Chest was created");
            chest = new Chest(3, 5, 10);
            controller.CreateNeutral(chest);
            Log("Chest was created");
            chest = new Chest(5, 9, 10);
            controller.CreateNeutral(chest);
            Log("Chest was created");

            ConsoleRender renderer = new ConsoleRender();
            renderer.Render(field, 10, 10);

            Unit knight = field.GetUnit(1, 1);
            Unit tank = field.GetUnit(3, 1);
            Unit sorcerer = field.GetUnit(5, 1);
            Console.WriteLine("Knight's damage before altar: " + knight.Attack.Damage);
            Console.WriteLine("Tank's speed before altar: " + tank.MoveSpeed.Current);
            Console.WriteLine("Sorcerer's speed before altar: " + sorcerer.MoveSpeed.Current);
            controller.MoveUnit(knight, Direction.Down);
            Log("Knight was moved");
            controller.MoveUnit(tank, Direction.Down);
            Log("Tank was moved");
            controller.MoveUnit(sorcerer, Direction.Down);
            Log("Sorcerer was moved");
            Console.WriteLine("Knight's damage after altar: " + knight.Attack.Damage);
            Console.WriteLine("Tank's speed after altar: " + tank.MoveSpeed.Current);
            Console.WriteLine("Sorcerer's speed after altar: " + sorcerer.MoveSpeed.Current);
            tank.MoveSpeed.DecreaseMoveSpeed(1);
            sorcerer.MoveSpeed.DecreaseMoveSpeed(2);
            renderer.Render(field, 10, 10);
            Console.WriteLine();

            Console.WriteLine("Knight's hp before trap: " + knight.Health.Current);
            Console.WriteLine("Tank's hp before trap: " + tank.Health.Current);
            Console.WriteLine("Sorcerer's hp before trap: " + sorcerer.Health.Current);
            controller.MoveUnit(knight, Direction.Down);
            Log("Knight was moved");
            controller.MoveUnit(tank, Direction.Down);
            Log("Tank was moved");
            controller.MoveUnit(sorcerer, Direction.Down);
            Log("Sorcerer was moved");
            Console.WriteLine("Knight's hp after trap: " + knight.Health.Current);
            Console.WriteLine("Tank's hp after trap: " + tank.Health.Current);
            Console.WriteLine("Sorcerer's hp after trap: " + sorcerer.Health.Current);
            renderer.Render(field, 10, 10);
            Console.WriteLine();

            controller.MoveUnit(knight, Direction.Down);
            Log("Knight was moved");
            controller.MoveUnit(tank, Direction.Down);
            Log("Tank was moved");
            controller.MoveUnit(sorcerer, Direction.Down);
            Log("Sorcerer was moved");
            Console.WriteLine("Knight's hp after energy source: " + knight.Health.Current);
            Console.WriteLine("Tank's hp after energy source: " + tank.Health.Current);
            Console.WriteLine("Sorcerer's hp after energy source: " + sorcerer.Health.Current);
            renderer.Render(field, 10, 10);
            Console.WriteLine();

            Console.WriteLine("Knight's resources before chest: " + knight.Resources);
            Console.WriteLine("Tank's resources before chest: " + tank.Resources);
            Console.WriteLine("Sorcerer's resources before chest: " + sorcerer.Resources);
            controller.MoveUnit(knight, Direction.Down);
            Log("Knight was moved");
            controller.MoveUnit(tank, Direction.Down);
            Log("Tank was moved");
            controller.MoveUnit(sorcerer, Direction.Down);
            Log("Sorcerer was moved");
            Console.WriteLine("Knight's resources after chest: " + knight.Resources);
            Console.WriteLine("Tank's resources after chest: " + tank.Resources);
            Console.WriteLine("Sorcerer's resources after chest: " + sorcerer.Resources);
            renderer.Render(field, 10, 10);
            Console.WriteLine();

        }

        private static void Scenario4()
        {

            Console.WriteLine("Scenario 4");
            Console.WriteLine("Removing unit");
            Console.WriteLine();

            GameField field = new GameField(10, 10, 50, 10);
            Log("Gamefield was created");
            GameController controller = new GameController(field);

            Base gameBase = controller.CreateBase(0, 0, 10);
            Log("Base was created");
            IUnitFactory factory = new KnightFactory();
            Unit unit = controller.CreateUnit(gameBase, factory, 1, 1);
            Log("Unit was created");
            ConsoleRender renderer = new ConsoleRender();
            renderer.Render(field, 10, 10);
            unit.TakeDamage(100);
            Log("The unit was dealt 100 damage");
            Console.WriteLine($"In base: {gameBase.IsUnitInBase(unit)}");

            Console.WriteLine($"On field: {field.GetUnit(1, 1) != null}");

            renderer.Render(field, 10, 10);

        }

        private static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
