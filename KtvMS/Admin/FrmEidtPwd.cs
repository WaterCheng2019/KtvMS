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
using KtvSYSBLL;

namespace KtvMS
{
    public partial class FrmEidtPwd : Form
    {
        UserManager userManager = new UserManager();
        public FrmEidtPwd()
        {
            InitializeComponent();
        }

        private void FrmEidtPwd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtOldPwd.Text))
            //{
            //    MessageBox.Show("请输入旧密码！！！","温馨提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    txtOldPwd.Focus();
            //    return;
            //}
            if (txtNewPwd.Text.Trim()!=txtConfigPwd.Text.Trim())
            {
                MessageBox.Show("两次密码不一致！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfigPwd.Focus();
                return;
            }

            if (userManager.EditUserPwd(UserHelpercs.UserName, txtOldPwd.Text,txtNewPwd.Text.Trim())>0)
            {
                MessageBox.Show("密码修改成功,请重新登陆！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPwd.Text = "";
                txtNewPwd.Text = "";
                txtConfigPwd.Text = "";
                Application.Exit();
            }
            else
            {
                MessageBox.Show("旧密码错错误！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
