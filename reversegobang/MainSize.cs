using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversegobang
{
    internal class MainSize
    {
        // 窗口大小
        public static int FormWidth { get { return 750; } }
        public static int FormHeight { get { return 640; } }

        // 棋盘大小
        public static int CBoardWidth { get { return 600; } }
        public static int CBoardHeight { get { return 600; } }

        // 棋格宽度
        public static int CBoardGap { get { return 40; } }

        // 棋子直径
        public static int ChessDiameter { get { return 37; } }
    }
}
