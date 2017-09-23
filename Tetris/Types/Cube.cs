using OpenGL;
using System;
using System.Collections.Generic;
using Tetris.Common;
using Tetris.Utilities;

namespace Tetris.Types
{
    public class Cube : IDisposable
    {
        public Point Origin { get; private set; }
        public float SideLength { get; private set; }
        public RGB Color { get; set; }
        public bool IsFilled { get; set; }

        private VBO<Vector3> _square;
        private VBO<int> _squareElements;
        private VBO<Vector3> _squareColors;

        public Cube(Point origin, float sideLength, RGB color)
        {
            Origin = origin;
            SideLength = sideLength;
            Color = color;
        }
        public Cube(Point origin, float sideLength, RGB color, bool isFilled)
        {
            Origin = origin;
            SideLength = sideLength;
            Color = color;
            IsFilled = isFilled;
        }


        public void Draw()
        {
            Dispose();
            BuildDisplayObject();
            BindDisplayObject();
            Gl.DrawElements(IsFilled ? BeginMode.TriangleFan : BeginMode.LineLoop,
                _squareElements.Count, DrawElementsType.UnsignedInt,
                IntPtr.Zero);
        }

        private void BuildDisplayObject()
        {
            _square = new VBO<Vector3>(new Vector3[] {
                //new Vector3(Origin.X, Origin.Y, 0),
                //new Vector3(Origin.X + SideLength, Origin.Y, 0),
                //new Vector3(Origin.X + SideLength, Origin.Y - SideLength, 0),
                //new Vector3(Origin.X, Origin.Y - SideLength, 0)

                new Vector3(Origin.Y, Origin.X, 0),
                new Vector3(Origin.Y, Origin.X + SideLength, 0),
                new Vector3(Origin.Y - SideLength, Origin.X + SideLength, 0),
                new Vector3(Origin.Y - SideLength, Origin.X,  0)
            });
            _squareElements = new VBO<int>(new[] { 0, 1, 2, 3 }, BufferTarget.ElementArrayBuffer);
            _squareColors = new VBO<Vector3>(new[] { Color.ToVector3(), Color.ToVector3(), Color.ToVector3() });
        }

        private void BindDisplayObject()
        {
            Program.ShaderProgram["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(-1.5f, 0, 0)));
            Gl.BindBufferToShaderAttribute(_square, Program.ShaderProgram, "vertexPosition");
            Gl.BindBufferToShaderAttribute(_squareColors, Program.ShaderProgram, "vertexColor");
            Gl.BindBuffer(_squareElements);
        }

        public void Dispose()
        {
            _square?.Dispose();
            _squareElements?.Dispose();
            _squareColors?.Dispose();
        }
    }
}