using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Common
{
    public static class ConfigurationHandler
    {
        private static NameValueCollection _appSettings = ConfigurationManager.AppSettings;

        public static int WindowWidth => int.Parse(_appSettings["windowWidth"]);
        public static int WindowHeight => int.Parse(_appSettings["windowHeight"]);
        public static int GridRows => int.Parse(_appSettings["gridRows"]);
        public static int GridColumns => int.Parse(_appSettings["gridColumns"]);

        public const float WindowYSize = 2.15f;
        public static readonly float CubeSideLength = WindowYSize * 2 / GridRows * 0.7f;
        public static float GridHeight = CubeSideLength * GridRows + 0.1f;
        public static float GridWidth = CubeSideLength * GridColumns;
    }
}