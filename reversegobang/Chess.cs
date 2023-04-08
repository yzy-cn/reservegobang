using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reversegobang
{
    internal class Chess
    {
        // 画棋子
        public static void DrawC(Panel p, bool ChessCheck, int PlacementX, int PlacementY)
        {
            Graphics g = p.CreateGraphics();                // 创建面板画布
            // 消除棋子边缘的锯齿(后面加的，博客的图片没更新)
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            int AccurateX = PlacementX * MainSize.CBoardGap + 20 - 17; // 精确棋子的X中心位置
            int AccurateY = PlacementY * MainSize.CBoardGap + 20 - 17; // 精确棋子的Y中心位置

            // 判断谁的回合并画棋子
            if (ChessCheck)
            {
                // 线性渐变会平铺整个面板，根据你的位置填颜色，从上至下渐变，使棋子具有真实感
                g.FillEllipse(new LinearGradientBrush(new Point(20, 0), new Point(20, 40),
                    Color.FromArgb(122, 122, 122),
                    Color.FromArgb(0, 0, 0)), new Rectangle(new Point(AccurateX, AccurateY), 
                    new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
            }
            else
            {
                g.FillEllipse(new LinearGradientBrush(new Point(20, 0),
                    new Point(20, 40), Color.FromArgb(255, 255, 255), 
                    Color.FromArgb(204, 204, 204)), new Rectangle(new Point(AccurateX, AccurateY),
                    new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
            }
        }

        // 界面重新聚焦时，重新加载棋子
        public static void ReDrawC(Panel p, int[,] CheckBoard)
        {
            Graphics g = p.CreateGraphics();                // 创建面板画布
            // 消除棋子边缘的锯齿
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 遍历 获取棋盘数组的每行
            for (int i = 0; i < CheckBoard.GetLength(1); i++)
            {
                // 遍历 获取棋盘数组每行的每列
                for (int j = 0; j < CheckBoard.GetLength(0); j++)
                {
                    int Judgment = CheckBoard[j, i];        // 判断数组当前行列，白子还是黑子回合，0表示没有，1表示黑子，2表示白子

                    // 判断是否有棋子
                    if (Judgment != 0)
                    {
                        int AccurateX = j * MainSize.CBoardGap + 20 - 17; // 精确棋子的X中心位置
                        int AccurateY = i * MainSize.CBoardGap + 20 - 17; // 精确棋子的Y中心位置

                        // 判断谁的回合并画棋子
                        if (Judgment == 1)
                        {
                            // 线性渐变会平铺整个面板，根据你的位置填颜色，从上至下渐变，使棋子具有真实感
                            g.FillEllipse(new LinearGradientBrush(new Point(20, 0), 
                                new Point(20, 40), Color.FromArgb(122, 122, 122),
                                Color.FromArgb(0, 0, 0)),
                                new Rectangle(new Point(AccurateX, AccurateY),
                                new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
                        }
                        else
                        {
                            g.FillEllipse(new LinearGradientBrush(new Point(20, 0),
                                new Point(20, 40), Color.FromArgb(255, 255, 255),
                                Color.FromArgb(204, 204, 204)), 
                                new Rectangle(new Point(AccurateX, AccurateY),
                                new Size(MainSize.ChessDiameter, MainSize.ChessDiameter)));
                        }
                    }
                }
            }
        }
    }
}
