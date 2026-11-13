using System;

namespace MMO_RPG
{
    internal class ConsoleRender
    {

        public void Render(GameField gameField, int width, int height)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();

            Console.Write("   ");

            for (int x = 0; x < width; x++)
            {
                Console.Write($"{x,2}");
            }

            Console.WriteLine();

            for (int y = 0; y < height; y++)
            {
                Console.Write($"{y,2} ");

                for (int x = 0; x < width; x++)
                {
                    if (gameField.GetUnit(x, y) != null)
                    {
                        UnitType type = gameField.GetUnit(x, y).GetUnitType();
                        switch (type)
                        {
                            case UnitType.Tank:
                                Console.Write(" T");
                                break;
                            case UnitType.Knight:
                                Console.Write(" K");
                                break;
                            case UnitType.PhantomAssasin:
                                Console.Write(" P");
                                break;
                            case UnitType.BountyHunter:
                                Console.Write(" B");
                                break;
                            case UnitType.Healer:
                                Console.Write(" H");
                                break;
                            case UnitType.Sorcerer:
                                Console.Write(" S");
                                break;
                        }
                    }
                    else if (gameField.GetBase(x, y) != null)
                    {
                        Console.Write(" B");
                    }
                    else if (gameField.GetNeutral(x, y) != null)
                    {
                        NeutralType type = gameField.GetNeutral(x, y).GetNeutralType();
                        switch (type)
                        {
                            case NeutralType.Altar:
                                Console.Write(" *");
                                break;
                            case NeutralType.Chest:
                                Console.Write(" +");
                                break;
                            case NeutralType.Trap:
                                Console.Write(" -");
                                break;
                            case NeutralType.Source:
                                Console.Write(" ^");
                                break;
                        }
                    }
                    else
                    {
                        TerrainType type = gameField.TerrainMap.GetTerrain(x, y).GetTerrainType();
                        switch (type)
                        {
                            case TerrainType.Plain:
                                Console.Write(" .");
                                break;
                            case TerrainType.Forest:
                                Console.Write("🌲");
                                break;
                            case TerrainType.Mountain:
                                Console.Write(" ▲");
                                break;
                            case TerrainType.Swamp:
                                Console.Write(" ≈");
                                break;

                        }
                    }
                }

                Console.WriteLine();
            }
        }

    }
}
