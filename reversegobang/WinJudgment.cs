using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversegobang
{
    internal class WinJudgment
    {
        // 棋子判断
        public static bool ChessJD(int[,] CheckBoard, int Judgment)
        {
            bool Win = false;         // 胜利判断

            // 遍历 获取棋盘数组的每行
            for (int i = 0; i < CheckBoard.GetLength(1); i++)
            {
                // 遍历 获取棋盘数组每行的每列
                for (int j = 0; j < CheckBoard.GetLength(0); j++)
                {
                    // 判断是否有棋子
                    if (CheckBoard[j, i] == Judgment)
                    {
                        // 水平判断
                        if (j < 11)
                        {
                            if (CheckBoard[j + 1, i] == Judgment && CheckBoard[j + 2, i] == Judgment && CheckBoard[j + 3, i] == Judgment && CheckBoard[j + 4, i] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                        // 垂直判断
                        if (i < 11)
                        {
                            if (CheckBoard[j, i + 1] == Judgment && CheckBoard[j, i + 2] == Judgment && CheckBoard[j, i + 3] == Judgment && CheckBoard[j, i + 4] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                        // 右下判断
                        if (j < 11 && i < 11)
                        {
                            if (CheckBoard[j + 1, i + 1] == Judgment && CheckBoard[j + 2, i + 2] == Judgment && CheckBoard[j + 3, i + 3] == Judgment && CheckBoard[j + 4, i + 4] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                        // 左下判断
                        if (j > 3 && i < 11)
                        {
                            if (CheckBoard[j - 1, i + 1] == Judgment && CheckBoard[j - 2, i + 2] == Judgment && CheckBoard[j - 3, i + 3] == Judgment && CheckBoard[j - 4, i + 4] == Judgment)
                            {
                                return Win = true;
                            }
                        }
                    }
                }
            }
            return Win;
        }
    }
}
