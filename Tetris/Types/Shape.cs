using System;
using Tetris.Common;
using Tetris.Utilities;
using System.Linq;
namespace Tetris.Types
{
    public class Shape : IDisposable
    {
        public Cube[,] Matrix { get; set; }
        public Point Origin { get; set; }
        public RGB Color { get; set; }

        public Shape(Cube[,] matrix, RGB color, Point origin)
        {
            Matrix = matrix;
            Color = color;
            Origin = origin;
        }

        public void Draw()
        {
            foreach (var cube in Matrix)
            {
                cube?.Draw();
            }
        }

        public void Rotate()
        {
            var rotatedMatrix = new Cube[Matrix.GetLength(1), Matrix.GetLength(0)];
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                for (int j = 0; j < Matrix.GetLength(0); j++)
                {
                    rotatedMatrix[i, j] = Matrix[j, i];
                }
            }

            Matrix = MatrixCubeCreator(rotatedMatrix, Origin, Color, ConfigurationHandler.CubeSideLength);
        }

        public static Cube[,] MatrixCubeCreator(Cube[,] matrix, Point origin, RGB color, OpenGL.Point[] points, float cubeSideLength)
        {
            foreach (var point in points)
            {
                matrix[point.X, point.Y] = new Cube(
                    //new Point(origin.Y + point.Y * cubeSideLength, origin.X - point.X * cubeSideLength),

                    //new Point(origin.Y - (matrix.GetLength(0) * cubeSideLength - point.Y) * cubeSideLength,
                    //origin.X + (matrix.GetLength(1) * cubeSideLength - point.X) * cubeSideLength),

                    new Point(origin.Y - point.Y * cubeSideLength, origin.X + point.X * cubeSideLength),
                    cubeSideLength, color, isFilled: true);
            }


            //TODO: fix the bug where the shapes are being drawn sideways
            return matrix;
        }

        public static Cube[,] MatrixCubeCreator(Cube[,] matrix, Point origin, RGB color, float cubeSideLength)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] != null)
                    {
                        matrix[i, j].Origin.X = origin.X + j * cubeSideLength;
                        matrix[i, j].Origin.Y = origin.Y - i * cubeSideLength;
                    }
                }
            }

            return matrix;
        }

        public void Dispose()
        {
            foreach (var cube in Matrix)
            {
                cube?.Dispose();
            }
        }
    }
}