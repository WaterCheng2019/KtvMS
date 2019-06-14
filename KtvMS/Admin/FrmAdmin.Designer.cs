namespace KtvMS
{
    partial class FrmAdmin1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.歌曲管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.歌手管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.播放记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.数据管理ToolStripMenuItem,
            this.记录ToolStripMenuItem,
            this.系统管理ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip1_ItemAdded);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 21);
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.歌曲管理ToolStripMenuItem,
            this.歌手管理ToolStripMenuItem});
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(85, 21);
            this.数据管理ToolStripMenuItem.Text = "数据管理(&D)";
            // 
            // 歌曲管理ToolStripMenuItem
            // 
            this.歌曲管理ToolStripMenuItem.Name = "歌曲管理ToolStripMenuItem";
            this.歌曲管理ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.歌曲管理ToolStripMenuItem.Text = "歌曲管理(&M)";
            this.歌曲管理ToolStripMenuItem.Click += new System.EventHandler(this.歌曲管理ToolStripMenuItem_Click);
            // 
            // 歌手管理ToolStripMenuItem
            // 
            this.歌手管理ToolStripMenuItem.Name = "歌手管理ToolStripMenuItem";
            this.歌手管理ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.歌手管理ToolStripMenuItem.Text = "歌手管理(&N)";
            this.歌手管理ToolStripMenuItem.Click += new System.EventHandler(this.歌手管理ToolStripMenuItem_Click);
            // 
            // 记录ToolStripMenuItem
            // 
            this.记录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载记录ToolStripMenuItem,
            this.播放记录ToolStripMenuItem});
            this.记录ToolStripMenuItem.Name = "记录ToolStripMenuItem";
            this.记录ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.记录ToolStripMenuItem.Text = "记录查看(&C)";
            // 
            // 下载记录ToolStripMenuItem
            // 
            this.下载记录ToolStripMenuItem.Name = "下载记录ToolStripMenuItem";
            this.下载记录ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.下载记录ToolStripMenuItem.Text = "下载记录(&M)";
            this.下载记录ToolStripMenuItem.Click += new System.EventHandler(this.下载记录ToolStripMenuItem_Click);
            // 
            // 播放记录ToolStripMenuItem
            // 
            this.播放记录ToolStripMenuItem.Name = "播放记录ToolStripMenuItem";
            this.播放记录ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.播放记录ToolStripMenuItem.Text = "播放记录(&N)";
            this.播放记录ToolStripMenuItem.Click += new System.EventHandler(this.播放记录ToolStripMenuItem_Click);
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改密码ToolStripMenuItem,
            this.用户管理ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(85, 21);
            this.系统管理ToolStripMenuItem.Text = "系统管理(&G)";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码(&E)";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.用户管理ToolStripMenuItem.Text = "用户管理(&U)";
            this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.关于ToolStripMenuItem.Text = "关于(&A)";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLable
            // 
            this.tsLable.Name = "tsLable";
            this.tsLable.Size = new System.Drawing.Size(68, 17);
            this.tsLable.Text = "登陆信息：";
            // 
            // FrmAdmin1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 579);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAdmin1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "后台管理";
            this.Load += new System.EventHandler(this.FrmAdmin1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 歌曲管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 歌手管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 播放记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLable;
    }
}