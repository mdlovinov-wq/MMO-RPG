using System;

namespace MMO_RPG
{
    internal class Program
    {
        public static void Main()
        {

            Scenario1();
            Console.ReadKey();
            Console.Clear();

        }

        private static void Scenario1()
        {

            Console.WriteLine("Scenario 1");
            Console.WriteLine("Base and units");
            Console.WriteLine();

            GameField field = new GameField(10, 10, 50, 10);
            GameController controller = new GameController(field);

            IUnitFactory factory = null;
            Base gameBase = controller.CreateBase(0, 0, 10);
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
            Console.WriteLine("Base and units");
            Console.WriteLine();
        }

        private static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
