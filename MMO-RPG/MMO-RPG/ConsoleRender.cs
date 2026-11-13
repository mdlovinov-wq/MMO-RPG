using System;
using System.Runtime.ExceptionServices;

namespace MMO_RPG
{
    internal class ConsoleRender
    {

        public void Render(GameField gameField, int width, int height)
        {
            Console.Clear();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (gameField.GetUnit(x, y) != null)
                    {
                        Console.Write("U ");
                    }
                    if (gameField.GetBase(x, y) != null)
                    {
                        Console.Write("B ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
