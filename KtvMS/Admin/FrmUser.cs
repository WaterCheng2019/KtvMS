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
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }
        UserManager userManager = new UserManager();

        #region 事件

        private void FrmUser_Load(object sender, EventArgs e)
        {
            bindDgvSongs();
            cboType.SelectedIndex = 0;
        }
        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUsers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}",e.Row.Index+1);

        }
       
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.SelectedRows.Count>0)
            {
                txtId.Text = dgvUsers.SelectedRows[0].Cells["编号"].Value.ToString();
                txtName.Text = dgvUsers.SelectedRows[0].Cells["用户名"].Value.ToString();
                cboType.Text = dgvUsers.SelectedRows[0].Cells["用户类型"].Value.ToString();
                txtPwd.Enabled = false;
                txtConfriPwd.Enabled = false;
            }
        }
          

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tdbRest_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPwd.Text = "";
            txtConfriPwd.Text = "";
            cboType.SelectedIndex = 0;
            txtPwd.Enabled = true;
            txtConfriPwd.Enabled = true;
        }
        /// <summary>
        /// 增加账户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("请输入用户名！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            if (txtPwd.Text.Trim()!=txtConfriPwd.Text.Trim())
            {
                MessageBox.Show("密码不一致！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfriPwd.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtId.Text))
            {
                if (userManager.isUserName(txtName.Text.Trim()))
                {
                    MessageBox.Show("用户名已存在，请重新输入！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }

                User u = new User();
                u.UserName = txtName.Text.Trim();
                u.UserPwd = txtPwd.Text.Trim();
                u.UserType = cboType.Text;

                if (userManager.AddUser(u)>0)
                {
                    bindDgvSongs();
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtId.Text.Trim()))
            {
                MessageBox.Show("请选择要删除的信息~~~", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (MessageBox.Show("确认要删除该条信息吗？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
                {
                    if (userManager.DeleteUserById(Convert.ToInt32(txtId.Text))>0)
                    {
                        bindDgvSongs();
                    } 
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 方法

        public void bindDgvSongs()
        {
            try
            {
                dgvUsers.DataSource = userManager.GetAllUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }






        #endregion

     
    }
}
