namespace KtvMS
{
    partial class FrmSong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.歌手 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.cboSingers = new System.Windows.Forms.ComboBox();
            this.cboTypes = new System.Windows.Forms.ComboBox();
            this.txtPinYin = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSongs = new System.Windows.Forms.DataGridView();
            this.ofOpenFlie = new System.Windows.Forms.OpenFileDialog();
            this.编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.歌曲 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.歌手名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.歌曲全名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.添加时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.播放次数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.拼音 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.路径 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.歌手.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).BeginInit();
            this.SuspendLayout();
            // 
            // 歌手
            // 
            this.歌手.BackColor = System.Drawing.SystemColors.Control;
            this.歌手.Controls.Add(this.btnSearch);
            this.歌手.Controls.Add(this.btnOpenFile);
            this.歌手.Controls.Add(this.txtFile);
            this.歌手.Controls.Add(this.cboSingers);
            this.歌手.Controls.Add(this.cboTypes);
            this.歌手.Controls.Add(this.txtPinYin);
            this.歌手.Controls.Add(this.txtName);
            this.歌手.Controls.Add(this.label7);
            this.歌手.Controls.Add(this.txtId);
            this.歌手.Controls.Add(this.toolStrip1);
            this.歌手.Controls.Add(this.label6);
            this.歌手.Controls.Add(this.label5);
            this.歌手.Controls.Add(this.label3);
            this.歌手.Controls.Add(this.label2);
            this.歌手.Controls.Add(this.label1);
            this.歌手.Dock = System.Windows.Forms.DockStyle.Top;
            this.歌手.Location = new System.Drawing.Point(0, 0);
            this.歌手.Margin = new System.Windows.Forms.Padding(2);
            this.歌手.Name = "歌手";
            this.歌手.Padding = new System.Windows.Forms.Padding(2);
            this.歌手.Size = new System.Drawing.Size(736, 154);
            this.歌手.TabIndex = 0;
            this.歌手.TabStop = false;
            this.歌手.Text = "歌曲信息";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(586, 45);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "搜 索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(586, 120);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(67, 26);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "选择文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(105, 124);
            this.txtFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(454, 21);
            this.txtFile.TabIndex = 13;
            // 
            // cboSingers
            // 
            this.cboSingers.FormattingEnabled = true;
            this.cboSingers.Location = new System.Drawing.Point(105, 98);
            this.cboSingers.Margin = new System.Windows.Forms.Padding(2);
            this.cboSingers.Name = "cboSingers";
            this.cboSingers.Size = new System.Drawing.Size(151, 20);
            this.cboSingers.TabIndex = 3;
            // 
            // cboTypes
            // 
            this.cboTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypes.FormattingEnabled = true;
            this.cboTypes.Location = new System.Drawing.Point(408, 76);
            this.cboTypes.Margin = new System.Windows.Forms.Padding(2);
            this.cboTypes.Name = "cboTypes";
            this.cboTypes.Size = new System.Drawing.Size(151, 20);
            this.cboTypes.TabIndex = 2;
            // 
            // txtPinYin
            // 
            this.txtPinYin.Location = new System.Drawing.Point(105, 71);
            this.txtPinYin.Margin = new System.Windows.Forms.Padding(2);
            this.txtPinYin.Name = "txtPinYin";
            this.txtPinYin.Size = new System.Drawing.Size(151, 21);
            this.txtPinYin.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(408, 45);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 21);
            this.txtName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "类型";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(105, 46);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(151, 21);
            this.txtId.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReset,
            this.tsbSave,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(2, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbReset
            // 
            this.tsbReset.Image = global::KtvMS.Properties.Resources.reload;
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(86, 24);
            this.tsbReset.Text = "重置（&F）";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::KtvMS.Properties.Resources.filesave;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(87, 24);
            this.tsbSave.Text = "保存（&S）";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::KtvMS.Properties.Resources.Remove;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(88, 24);
            this.tsbDelete.Text = "删除（&R）";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "文件";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "歌手";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "拼音";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "歌曲";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.dgvSongs);
            this.groupBox2.Location = new System.Drawing.Point(0, 159);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(736, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "歌曲列表";
            // 
            // dgvSongs
            // 
            this.dgvSongs.AllowUserToAddRows = false;
            this.dgvSongs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSongs.BackgroundColor = System.Drawing.Color.White;
            this.dgvSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.编号,
            this.歌曲,
            this.歌手名称,
            this.歌曲全名,
            this.添加时间,
            this.播放次数,
            this.类型,
            this.拼音,
            this.路径,
            this.playTime,
            this.songSize,
            this.source});
            this.dgvSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSongs.Location = new System.Drawing.Point(2, 16);
            this.dgvSongs.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSongs.MultiSelect = false;
            this.dgvSongs.Name = "dgvSongs";
            this.dgvSongs.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSongs.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSongs.RowHeadersWidth = 80;
            this.dgvSongs.RowTemplate.Height = 27;
            this.dgvSongs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSongs.Size = new System.Drawing.Size(732, 280);
            this.dgvSongs.TabIndex = 0;
            this.dgvSongs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSongs_CellClick);
            this.dgvSongs.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvSongs_RowStateChanged);
            // 
            // ofOpenFlie
            // 
            this.ofOpenFlie.FileName = "openFileDialog1";
            // 
            // 编号
            // 
            this.编号.DataPropertyName = "Id";
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            this.编号.ReadOnly = true;
            this.编号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 歌曲
            // 
            this.歌曲.DataPropertyName = "name";
            this.歌曲.HeaderText = "歌曲";
            this.歌曲.Name = "歌曲";
            this.歌曲.ReadOnly = true;
            // 
            // 歌手名称
            // 
            this.歌手名称.DataPropertyName = "singerId";
            this.歌手名称.HeaderText = "歌手";
            this.歌手名称.Name = "歌手名称";
            this.歌手名称.ReadOnly = true;
            // 
            // 歌曲全名
            // 
            this.歌曲全名.DataPropertyName = "SongName";
            this.歌曲全名.HeaderText = "歌曲全名";
            this.歌曲全名.Name = "歌曲全名";
            this.歌曲全名.ReadOnly = true;
            // 
            // 添加时间
            // 
            this.添加时间.DataPropertyName = "addTime";
            this.添加时间.HeaderText = "添加时间";
            this.添加时间.Name = "添加时间";
            this.添加时间.ReadOnly = true;
            // 
            // 播放次数
            // 
            this.播放次数.DataPropertyName = "playCount";
            this.播放次数.HeaderText = "播放次数";
            this.播放次数.Name = "播放次数";
            this.播放次数.ReadOnly = true;
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "songtypeID";
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.ReadOnly = true;
            // 
            // 拼音
            // 
            this.拼音.DataPropertyName = "pinyin";
            this.拼音.HeaderText = "拼音";
            this.拼音.Name = "拼音";
            this.拼音.ReadOnly = true;
            this.拼音.Visible = false;
            // 
            // 路径
            // 
            this.路径.DataPropertyName = "songURL";
            this.路径.HeaderText = "路径";
            this.路径.Name = "路径";
            this.路径.ReadOnly = true;
            this.路径.Visible = false;
            // 
            // playTime
            // 
            this.playTime.DataPropertyName = "playTime";
            this.playTime.HeaderText = "播放时长";
            this.playTime.Name = "playTime";
            this.playTime.ReadOnly = true;
            // 
            // songSize
            // 
            this.songSize.DataPropertyName = "songSize";
            this.songSize.HeaderText = "大小";
            this.songSize.Name = "songSize";
            this.songSize.ReadOnly = true;
            // 
            // source
            // 
            this.source.DataPropertyName = "source";
            this.source.HeaderText = "来源";
            this.source.Name = "source";
            this.source.ReadOnly = true;
            // 
            // FrmSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.歌手);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "歌曲管理";
            this.Load += new System.EventHandler(this.FrmSong_Load);
            this.歌手.ResumeLayout(false);
            this.歌手.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox 歌手;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.OpenFileDialog ofOpenFlie;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.ComboBox cboSingers;
        private System.Windows.Forms.ComboBox cboTypes;
        private System.Windows.Forms.TextBox txtPinYin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView dgvSongs;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn 歌曲全名;
        private System.Windows.Forms.DataGridViewTextBoxColumn source;
        private System.Windows.Forms.DataGridViewTextBoxColumn songSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn playTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn 路径;
        private System.Windows.Forms.DataGridViewTextBoxColumn 拼音;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 播放次数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 添加时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 歌手名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 歌曲;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编号;
    }
}