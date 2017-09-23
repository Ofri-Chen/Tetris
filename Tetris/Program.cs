using OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tetris.Common;
using Tetris.Keyboard;
using Tetris.Types;
using Tetris.Utilities;

namespace Tetris
{
    class Program
    {
        public static ShaderProgram ShaderProgram;
        private static Stopwatch watch;

        private static Grid Grid;
        private static Shape Shape;

        static void Main(string[] args)
        {
            InitializeGlut();

            ShaderProgram = new ShaderProgram(VertexShader, FragmentShader);
            watch = Stopwatch.StartNew();

            Grid = new Grid();

            Shape = ShapeGenerator.GenerateShape(5);

            Glut.glutMainLoop();
        }

        private static void InitializeGlut()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(ConfigurationHandler.WindowWidth, ConfigurationHandler.WindowHeight);
            Glut.glutCreateWindow("Tetris");
            Glut.glutFullScreen();

            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);

            Glut.glutKeyboardFunc(KeyboardManager.OnKeyboardDown);
            Glut.glutSpecialFunc(KeyboardManager.OnSpecialKeyboardDown);
            Glut.glutSpecialUpFunc(KeyboardManager.OnSpecialKeyboardUp);
        }


        private static void OnClose()
        {
            ShaderProgram.DisposeChildren = true;
            ShaderProgram.Dispose();
        }

        private static void OnDisplay()
        {
        }

        private static void OnRenderFrame()
        {
            Gl.Viewport(0, 0, ConfigurationHandler.WindowWidth, ConfigurationHandler.WindowHeight);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.ClearColor(0.53f, 0.8f, 0.98f, 1);

            ShaderProgram.Use();
            ShaderProgram["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f,
                (float)ConfigurationHandler.WindowWidth / ConfigurationHandler.WindowHeight,
                0.1f, 1000f));
            ShaderProgram["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up));


            Shape.Draw();
            Grid.Draw();


            Glut.glutSwapBuffers();
            Shape.Dispose();
            Grid.Dispose();
        }

        public static string VertexShader = @"
in vec3 vertexPosition;
in vec3 vertexColor;

out vec3 color;

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 model_matrix;

void main(void)
{
    color = vertexColor;
    gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
}
";

        public static string FragmentShader = @"
in vec3 color;

void main(void){
    gl_FragColor = vec4(color, 1);
}
";
    }
}
