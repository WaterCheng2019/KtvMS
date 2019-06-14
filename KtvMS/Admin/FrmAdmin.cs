using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KtvMSModel;

namespace KtvMS
{
    public partial class FrmAdmin1 : Form
    {
        public FrmAdmin1()
        {
            InitializeComponent();
        }

        private Form myForm;

        private void ShowSonForm(Form sonForm)
        {
            if (myForm != null)
            {
                myForm.Close();
            }
            myForm = sonForm;
            sonForm.MdiParent = this;
            sonForm.WindowState = FormWindowState.Maximized;
            sonForm.Show();
        }

        private void FrmAdmin1_Load(object sender, EventArgs e)
        {
            tsLable.Text = String.Format("欢迎你！{0}，登陆时间：{1}", UserHelpercs.UserName, DateTime.Now.ToString());

            FrmSong frmSong = new FrmSong();
            ShowSonForm(frmSong);
        }

        private void 歌曲管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSong frmSong = new FrmSong();
            ShowSonForm(frmSong);
        }

        private void 歌手管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSinger frmSinger = new FrmSinger();
            ShowSonForm(frmSinger);
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEidtPwd frmEidtPwd = new FrmEidtPwd();
            ShowSonForm(frmEidtPwd);
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUser frmUser = new FrmUser();
            ShowSonForm(frmUser);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            ShowSonForm(frmAbout);
        }

        private void 下载记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDownloadHistory frmDownloadHistory = new FrmDownloadHistory();
            ShowSonForm(frmDownloadHistory);
        }

        private void 播放记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlayHistory frmPlayHistory = new FrmPlayHistory();
            ShowSonForm(frmPlayHistory);
        }

        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length==0)
            {
                e.Item.Visible = false;
            }
        }
    }
}
