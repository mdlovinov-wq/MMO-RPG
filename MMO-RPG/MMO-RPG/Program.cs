using System;
using System.Collections.Generic;

namespace MMO_RPG
{
    internal class Program
    {
        public static void Main()
        {


            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int width = 20;
            int height = 12;

            GameField field = new GameField(width, height, 20, 2);
            GameController controller = new GameController(field);
            ConsoleRender renderer = new ConsoleRender();

            for (int x = 3; x <= 7; x++)
            {
                for (int y = 2; y <= 5; y++)
                {
                    field.TerrainMap.SetTerrain(x, y, new Forest());
                }
            }

            for (int x = 12; x <= 16; x++)
            {
                for (int y = 6; y <= 9; y++)
                {
                    field.TerrainMap.SetTerrain(x, y, new Swamp());
                }
            }

            for (int x = 8; x <= 11; x++)
            {
                for (int y = 3; y <= 5; y++)
                {
                    field.TerrainMap.SetTerrain(x, y, new Mountains());
                }
            }

            for (int x = 1; x <= 4; x++)
            {
                field.TerrainMap.SetTerrain(x, 9, new Forest());
            }

            for (int y = 0; y < height; y++)
            {
                field.TerrainMap.SetTerrain(10, y, new Mountains());
            }

            field.TerrainMap.SetTerrain(10, 5, new Plain());
            field.TerrainMap.SetTerrain(10, 6, new Plain());

            Base base1 = controller.CreateBase(1, 1, 5);
            Base base2 = controller.CreateBase(18, 10, 5);

            IUnitFactory tankFactory = new TankFactory();
            IUnitFactory knightFactory = new KnightFactory();
            IUnitFactory healerFactory = new HealerFactory();
            IUnitFactory bountyFactory = new BountyHunterFactory();

            Unit tank = base1.CreateUnit(tankFactory, 2, 1);
            field.AddUnit(tank, 2, 1);

            Unit knight = base1.CreateUnit(knightFactory, 1, 2);
            field.AddUnit(knight, 1, 2);

            Unit healer = base2.CreateUnit(healerFactory, 17, 10);
            field.AddUnit(healer, 17, 10);

            Unit hunter = base2.CreateUnit(bountyFactory, 18, 9);
            field.AddUnit(hunter, 18, 9);

            controller.CreateNeutral(new Chest(5, 7, 50));
            controller.CreateNeutral(new Chest(15, 2, 100));

            controller.CreateNeutral(new Altar(8, 8));
            controller.CreateNeutral(new Altar(11, 2));

            controller.CreateNeutral(new Trap(6, 10));
            controller.CreateNeutral(new Trap(14, 4));

            controller.CreateNeutral(new EnergySource(3, 7));
            controller.CreateNeutral(new EnergySource(16, 10));

            renderer.Render(field, width, height);

            Console.WriteLine();
            Console.WriteLine("Units: " + field.UnitsCount());
            Console.WriteLine("Bases: " + field.BasesCount());

            Console.ReadKey();


        }
    }
}
