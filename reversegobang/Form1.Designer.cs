namespace reversegobang
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnstart = new System.Windows.Forms.Button();
            this.btnrestart = new System.Windows.Forms.Button();
            this.btnrule = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.panelboard = new System.Windows.Forms.Panel();
            this.panelright = new System.Windows.Forms.Panel();
            this.labelstatus = new System.Windows.Forms.Label();
            this.panelright.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.White;
            this.btnstart.Location = new System.Drawing.Point(28, 38);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(145, 44);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "开始游戏";
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnrestart
            // 
            this.btnrestart.BackColor = System.Drawing.Color.White;
            this.btnrestart.Location = new System.Drawing.Point(28, 104);
            this.btnrestart.Name = "btnrestart";
            this.btnrestart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnrestart.Size = new System.Drawing.Size(145, 44);
            this.btnrestart.TabIndex = 1;
            this.btnrestart.Text = "重新开始";
            this.btnrestart.UseVisualStyleBackColor = false;
            this.btnrestart.Click += new System.EventHandler(this.btnrestart_Click);
            // 
            // btnrule
            // 
            this.btnrule.BackColor = System.Drawing.Color.White;
            this.btnrule.Location = new System.Drawing.Point(28, 170);
            this.btnrule.Name = "btnrule";
            this.btnrule.Size = new System.Drawing.Size(145, 44);
            this.btnrule.TabIndex = 2;
            this.btnrule.Text = "游戏规则";
            this.btnrule.UseVisualStyleBackColor = false;
            this.btnrule.Click += new System.EventHandler(this.btnrule_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.Location = new System.Drawing.Point(28, 776);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(145, 44);
            this.btnexit.TabIndex = 3;
            this.btnexit.Text = "退出";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // panelboard
            // 
            this.panelboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelboard.Location = new System.Drawing.Point(0, 0);
            this.panelboard.Name = "panelboard";
            this.panelboard.Size = new System.Drawing.Size(1283, 856);
            this.panelboard.TabIndex = 4;
            this.panelboard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelboard_Paint);
            this.panelboard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelboard_MouseDown);
            // 
            // panelright
            // 
            this.panelright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelright.Controls.Add(this.labelstatus);
            this.panelright.Controls.Add(this.btnstart);
            this.panelright.Controls.Add(this.btnrestart);
            this.panelright.Controls.Add(this.btnexit);
            this.panelright.Controls.Add(this.btnrule);
            this.panelright.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelright.Location = new System.Drawing.Point(1083, 0);
            this.panelright.Name = "panelright";
            this.panelright.Size = new System.Drawing.Size(200, 856);
            this.panelright.TabIndex = 5;
            this.panelright.Paint += new System.Windows.Forms.PaintEventHandler(this.panelright_Paint);
            // 
            // labelstatus
            // 
            this.labelstatus.AutoSize = true;
            this.labelstatus.Location = new System.Drawing.Point(54, 256);
            this.labelstatus.Name = "labelstatus";
            this.labelstatus.Size = new System.Drawing.Size(98, 18);
            this.labelstatus.TabIndex = 4;
            this.labelstatus.Text = "游戏未开始";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 856);
            this.Controls.Add(this.panelright);
            this.Controls.Add(this.panelboard);
            this.Name = "Form1";
            this.Text = "反五子棋";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelright.ResumeLayout(false);
            this.panelright.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnrestart;
        private System.Windows.Forms.Button btnrule;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panelboard;
        private System.Windows.Forms.Panel panelright;
        private System.Windows.Forms.Label labelstatus;
    }
}

