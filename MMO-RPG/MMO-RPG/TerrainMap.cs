using System;
using System.Collections.Generic;

namespace MMO_RPG
{
    internal class TerrainMap
    {
        
        private readonly ITerrain[,] terrains;
        
        public int Height { get; private set; }
        public int Width { get; private set; }

        public TerrainMap(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Size must be positive");
            }

            Width = width;
            Height = height;

            terrains = new ITerrain[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    terrains[x, y] = new Plain();
                }
            }
        }

        private void ValidateCoordinates(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException("Corrdinates must be inside the field");
            }

        }

        public void SetTerrain(int x, int y, ITerrain terrain)
        {
            ValidateCoordinates(x, y);
            if (terrain == null)
            {
                throw new ArgumentNullException(nameof(terrain));
            }
            terrains[x, y] = terrain;
        }

        public ITerrain GetTerrain(int x, int y)
        {
            ValidateCoordinates(x, y);
            return terrains[x, y];
        }
    }
}
