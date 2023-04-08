using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversegobang
{
    internal class ChessBoard
    {
        public static void DrawCB(Graphics g)  //这里的形参，是画布对象
        {
            int GapWidth = MainSize.CBoardGap;                   // 棋格宽度
            int GapNum = MainSize.CBoardWidth / GapWidth - 1;    // 棋格数量
            g.Clear(Color.Bisque);                               // 清除画布、并用Bisque颜色填满画布
            Pen pen = new Pen(Color.FromArgb(192, 166, 107));    // 实例化画笔
            // 画棋盘
            for (int i = 0; i < GapNum + 1; i++)
            {
                g.DrawLine(pen, new Point(20, i * GapWidth + 20), new Point(GapWidth * GapNum + 20, i * GapWidth + 20));
                g.DrawLine(pen, new Point(i * GapWidth + 20, 20), new Point(i * GapWidth + 20, GapWidth * GapNum + 20));
            }
            
        }
    }
}
