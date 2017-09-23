using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Common;
using Tetris.Utilities;

namespace Tetris.Types
{
    public class Grid : IDisposable
    {
        public Cube[,] GridMatrix { get; set; }

        private static readonly int gridRows = ConfigurationHandler.GridRows;
        private static readonly int gridColumns = ConfigurationHandler.GridColumns;
        private static readonly float windowYSize = ConfigurationHandler.WindowYSize;
        private static readonly float cubeSideLength = ConfigurationHandler.CubeSideLength;
        private float gridHeight = ConfigurationHandler.GridHeight;
        private float gridWidth = ConfigurationHandler.GridWidth;
        private readonly RGB gridColor = new RGB(0, 0, 0);

        public Grid()
        {
            GridMatrix = new Cube[gridRows, gridColumns];
            InitializeGrid();
        }

        public void InitializeGrid()
        {
            float yStart = -1 * windowYSize + gridHeight;
            float xStart = gridWidth / 4;

            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridColumns; j++)
                {
                    GridMatrix[i, j] = new Cube(new Point(yStart - i * cubeSideLength, xStart + j * cubeSideLength),
                    cubeSideLength,
                    gridColor);
                }
            }
        }

        public void Draw()
        {
            foreach (var row in GridMatrix)
            {
                row.Draw();
            }
        }

        public void Dispose()
        {
            foreach (var row in GridMatrix)
            {
                row.Dispose();
            }
        }
    }
}
