using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//此项目由杨泽毅开发完成于2023
namespace reversegobang
{
    public partial class Form1 : Form
    {
        //判断游戏是否开始
        private bool start;

        //白子/黑子回合
        private bool chessCheck = true;

        //棋盘大小
        private const int size = 15;

        //棋盘点位数组
        private int[,] checkBoard =new int[size,size];

        //移动对手棋子
        private bool moveChess = false;

        //被替换棋子位置
        private int[] lastPosition = new int[2];

        public Form1()
        {
            InitializeComponent();
        }

        //窗体加载
        private void Form1_Load(object sender, EventArgs e)
        {
            initializeGame();                      // 调用初始化游戏
            this.Width = MainSize.FormWidth;       // 设置窗口宽度
            this.Height = MainSize.FormHeight;     // 设置窗口高度
            this.Location = new Point(400, 75);     // 设置窗口位置
        }

        // 初始化游戏
        private void initializeGame()
        {
            // 棋盘点位数组 重置为0
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    checkBoard[i, j] = 0;
                }
            }
            lastPosition[0] = -1;
            lastPosition[1] = -1;
            start = false;                         // 未开始
            labelstatus.Text = "游戏未开始";            // 提示文本改为"游戏未开始"
            btnstart.Visible = true;                // 显示'开始游戏'按钮
            btnrestart.Visible = false;               // 隐藏'重新开始'按钮
        }

        private void panelboard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panelboard.CreateGraphics();      // 创建面板画布
            ChessBoard.DrawCB(g);                      // 调用画棋盘方法
            Chess.ReDrawC(panelboard, checkBoard);         // 调用重新加载棋子方法
        }

        private void panelright_Paint(object sender, PaintEventArgs e)
        {
            // 设置控制界面的大小
            panelright.Size = new Size(MainSize.FormWidth - MainSize.CBoardWidth - 20, MainSize.FormHeight);
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            start = true;                              // 开始
            chessCheck = true;                         // 黑子回合
            labelstatus.Text = "黑子回合";                  // 提示文本改为"黑子回合"
            btnstart.Visible = false;                   // 隐藏'开始游戏'按钮
            btnrestart.Visible = true;                    // 显示'重新开始'按钮
            panelboard.Invalidate();                       // 重绘面板"棋盘"
        }

        private void btnrestart_Click(object sender, EventArgs e)
        {
            // 确认是否重新开始
            if (MessageBox.Show("确认要重新开始？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                initializeGame();                      // 调用初始化游戏方法
                btnstart_Click(sender, e);              // 调用按钮"开始游戏"Click事件
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Dispose();                            // 退出窗口
        }

        private void panelboard_MouseDown(object sender, MouseEventArgs e)
        {
            // 判断游戏是否开始
            if (start)
            {
                int Judgment = 0;            // 判断数组当前行列，白子还是黑子回合，0表示没有，1表示黑子，2表示白子、用来判断胜利

                int PlacementX = e.X / MainSize.CBoardGap;      // 求鼠标点击的X方向的第几个点位
                int PlacementY = e.Y / MainSize.CBoardGap;      // 求鼠标点击的Y方向的第几个点位

                try
                {

                    // 黑子回合还是白子回合
                    if (chessCheck)//黑子回合
                    {
                        if (checkBoard[PlacementX, PlacementY] == 1)
                        {
                            return;                                                             // 此位置有黑子
                        }

                        if (checkBoard[PlacementX, PlacementY] == 0 && !moveChess)               //无棋子并不移动对手棋子
                        {
                            checkBoard[PlacementX, PlacementY] = 1;                             // 当前位置置为黑子
                            Judgment = 1;                                                       // 切换为判断黑子
                            labelstatus.Text = "白子回合";                                      // 提示文本改为"白子回合"
                            Chess.DrawC(panelboard, chessCheck, PlacementX, PlacementY);        // 画黑子
                            chessCheck = !chessCheck;                                           //改为白子回合
                        }



                        if (checkBoard[PlacementX, PlacementY] == 2)                            //当前位置有白子
                        {
                            checkBoard[PlacementX, PlacementY] = 1;                             // 将当前置为黑子
                            Judgment = 1;                                                       // 切换为判断黑子
                            moveChess = true;                                                   //下次点击移动对方棋子
                            lastPosition[0]=PlacementX; 
                            lastPosition[1]=PlacementY;                                         //保存当前位置
                            Chess.DrawC(panelboard, chessCheck, PlacementX, PlacementY);        // 画黑子
                        }

                        if (checkBoard[PlacementX, PlacementY] == 0 && moveChess)               //无棋子并移动对手棋子
                        {
                            if (PlacementX == lastPosition[0] || PlacementY == lastPosition[1] || Math.Abs(PlacementX - lastPosition[0]) == Math.Abs(PlacementY - lastPosition[1]))
                            {
                                checkBoard[PlacementX, PlacementY] = 2;                             // 当前位置置为白子
                                Judgment = 2;                                                       // 切换为判断白子
                                labelstatus.Text = "白子回合";                                      // 提示文本改为"白子回合"
                                Chess.DrawC(panelboard, !chessCheck, PlacementX, PlacementY);       // 画白子
                                moveChess = false;                                                  //取消移动状态
                                chessCheck = !chessCheck;                                           //改为白子回合
                                lastPosition[0] = -1;
                                lastPosition[1] = -1;
                            }
                            else
                            {
                                MessageBox.Show("位置错误，仅能放置在同行，列，对角线上");    // 提示位置错误
                                return;
                            }
                        }
                    }
                    else//白子回合
                    {
                        if (checkBoard[PlacementX, PlacementY] == 2)
                        {
                            return;                                                             // 此位置有白子
                        }
                        if (checkBoard[PlacementX, PlacementY] == 0 && !moveChess)               //无棋子并不移动对手棋子
                        {
                            checkBoard[PlacementX, PlacementY] = 2;                             // 当前位置置为白子
                            Judgment = 2;                                                       // 切换为判断白子
                            labelstatus.Text = "黑子回合";                                      // 提示文本改为"黑子回合"
                            Chess.DrawC(panelboard, chessCheck, PlacementX, PlacementY);        // 画黑子
                            chessCheck = !chessCheck;                                           //改为白子回合
                        }



                        if (checkBoard[PlacementX, PlacementY] == 1)                            //当前位置有黑子
                        {
                            checkBoard[PlacementX, PlacementY] = 2;                             // 将当前置为白子
                            Judgment = 2;                                                       // 切换为判断白子
                            moveChess = true;                                                   //下次点击移动对方棋子
                            lastPosition[0] = PlacementX;
                            lastPosition[1] = PlacementY;                                         //保存当前位置
                            Chess.DrawC(panelboard, chessCheck, PlacementX, PlacementY);        // 画白子

                        }

                        if (checkBoard[PlacementX, PlacementY] == 0 && moveChess)               //无棋子并移动对手棋子
                        {
                            if (PlacementX == lastPosition[0] || PlacementY == lastPosition[1] || Math.Abs(PlacementX - lastPosition[0]) == Math.Abs(PlacementY - lastPosition[1]))
                            {
                                checkBoard[PlacementX, PlacementY] = 1;                             // 当前位置置为黑子
                                Judgment = 1;                                                       // 切换为判断黑子
                                labelstatus.Text = "黑子回合";                                      // 提示文本改为"黑子回合"
                                Chess.DrawC(panelboard, !chessCheck, PlacementX, PlacementY);       // 画黑子
                                moveChess = false;                                                  //取消移动状态
                                chessCheck = !chessCheck;                                           //改为白子回合
                                lastPosition[0] = -1;
                                lastPosition[1] = -1;
                            }
                            else
                            {
                                MessageBox.Show("位置错误，仅能放置在同行，列，对角线上");    // 提示位置错误
                                return;
                            }
                        }
                    }


                    // 胜利判断
                    if (WinJudgment.ChessJD(checkBoard, Judgment))
                    {
                        // 判断黑子还是白子胜利
                        if (Judgment == 1)
                        {
                            MessageBox.Show("五连珠，白胜！", "胜利提示");    // 提示黑胜
                        }
                        else
                        {
                            MessageBox.Show("五连珠，黑胜！", "胜利提示");    // 提示白胜
                        }
                        initializeGame();                      // 调用初始化游戏
                    }

                }
                catch (Exception ) {
                }                            // 防止鼠标点击边界，导致数组越界

            }
            else
            {
                MessageBox.Show("请先开始游戏！", "提示");      // 提示开始游戏
            }
        }

        private void btnrule_Click(object sender, EventArgs e)
        {
            string rule = "反五子棋" + "\n" + "游戏目标：让你的对手五子连珠，并保证自己不五子连珠" + "\n" + "游戏规则:" + "\n" + "在正常五子棋规则下加入移动对手棋子的功能，在你的回合可以选择对手的一颗棋子位置进行替换，并将对手棋子移动到当前棋子的同行，同列，或斜角方向。" + "\n" + "此项目由杨泽毅开发完成，未经本人允许禁止进行任何商业活动，本人保留一切解释权利。" + "\n" + "祝大家游玩愉快。";
            MessageBox.Show(rule, "游戏规则");
        }
    }
}
