using System;
using Tetris.Common;
using Tetris.Utilities;

namespace Tetris.Types
{
    public static class ShapeGenerator
    {
        public static Point Origin { get; set; } = new Point(-1 * windowYSize + gridHeight, gridWidth / 4);
        private const int MATRIX_COLUMNS = 2;
        private const int MATRIX_ROWS = 4;
        private static Random Random = new Random();
        private static float gridHeight = ConfigurationHandler.GridHeight;
        private static float gridWidth = ConfigurationHandler.GridWidth;
        private static readonly float windowYSize = ConfigurationHandler.WindowYSize;
        private static readonly int gridRows = ConfigurationHandler.GridRows;
        private static readonly int gridColumns = ConfigurationHandler.GridColumns;


        private static readonly float cubeSideLength = ConfigurationHandler.CubeSideLength;

        public static Shape GenerateShape() => _shapes[Random.Next(0, 7)];
        public static Shape GenerateShape(int index) => _shapes[index];

        private static Shape[] _shapes = new Shape[]
        {
            Straight,
            Square,
            Plus,
            ReverseSquiggly,
            Squiggly,
            ReverseL,
            L
        };

        #region Shapes
        private static Shape Straight
        {
            get
            {
                Cube[,] matrix = new Cube[MATRIX_ROWS, MATRIX_COLUMNS];

                var color = new RGB(0, 240, 240);
                matrix = CubeCreator(matrix, color, new OpenGL.Point[] {
                                   new OpenGL.Point(0, 0),
                                   new OpenGL.Point(1, 0),
                                   new OpenGL.Point(2, 0),
                                   new OpenGL.Point(3, 0) });
                return new Shape(matrix, color, Origin);
            }
        }

        private static Shape Square
        {
            get
            {
                Cube[,] matrix = new Cube[MATRIX_ROWS, MATRIX_COLUMNS];

                var color = new RGB(240, 240, 0);
                matrix = CubeCreator(matrix, color, new OpenGL.Point[] {
                                   new OpenGL.Point(1, 0),
                                   new OpenGL.Point(1, 1),
                                   new OpenGL.Point(2, 0),
                                   new OpenGL.Point(2, 1) });
                return new Shape(matrix, color, Origin);
            }
        }

        private static Shape Plus
        {
            get
            {
                Cube[,] matrix = new Cube[MATRIX_COLUMNS, MATRIX_ROWS];

                var color = new RGB(160, 0, 240);
                matrix = CubeCreator(matrix, color, new OpenGL.Point[] {
                                   new OpenGL.Point(0, 1),
                                   new OpenGL.Point(1, 0),
                                   new OpenGL.Point(1, 1),
                                   new OpenGL.Point(1, 2) });
                return new Shape(matrix, color, Origin);
            }
        }

        private static Shape ReverseSquiggly
        {
            get
            {
                Cube[,] matrix = new Cube[MATRIX_ROWS, MATRIX_COLUMNS];

                var color = new RGB(0, 240, 0);
                matrix = CubeCreator(matrix, color, new OpenGL.Point[] {
                                   new OpenGL.Point(1, 0),
                                   new OpenGL.Point(2, 0),
                                   new OpenGL.Point(2, 1),
                                   new OpenGL.Point(3, 1) });
                return new Shape(matrix, color, Origin);
            }
        }

        private static Shape Squiggly
        {
            get
            {
                Cube[,] matrix = new Cube[MATRIX_ROWS, MATRIX_COLUMNS];

                var color = new RGB(240, 0, 0);
                matrix = CubeCreator(matrix, color, new OpenGL.Point[] {
                                   new OpenGL.Point(1, 1),
                                   new OpenGL.Point(2, 1),
                                   new OpenGL.Point(2, 0),
                                   new OpenGL.Point(3, 0) });
                return new Shape(matrix, color, Origin);
            }
        }

        private static Shape ReverseL
        {
            get
            {
                Cube[,] matrix = new Cube[MATRIX_ROWS, MATRIX_COLUMNS];

                var color = new RGB(0, 0, 240);
                matrix = CubeCreator(matrix, color, new OpenGL.Point[] {
                                   new OpenGL.Point(1, 1),
                                   new OpenGL.Point(2, 1),
                                   new OpenGL.Point(3, 1),
                                   new OpenGL.Point(3, 0) });
                return new Shape(matrix, color, Origin);
            }
        }

        private static Shape L
        {
            get
            {
                Cube[,] matrix = new Cube[MATRIX_ROWS, MATRIX_COLUMNS];

                var color = new RGB(240, 160, 0);
                matrix = CubeCreator(matrix, color, new OpenGL.Point[] {
                                   new OpenGL.Point(1, 0),
                                   new OpenGL.Point(2, 0),
                                   new OpenGL.Point(3, 0),
                                   new OpenGL.Point(3, 1) });
                return new Shape(matrix, color, Origin);
            }
        }
        #endregion

        private static Cube[,] CubeCreator(Cube[,] matrix, RGB color, OpenGL.Point[] points)
        {
            return Shape.MatrixCubeCreator(matrix, Origin, color, points, cubeSideLength);
        }
    }
}