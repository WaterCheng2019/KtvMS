using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KtvSYSBLL;
using KtvMSModel;

namespace KtvMS
{
    public partial class FrmSinger : Form
    {
        SingerTypeManager singTypeManager = new SingerTypeManager();
        SingerManager singerManager = new SingerManager();
        string ImageUrl;
        string pathPhoto = System.IO.Directory.GetCurrentDirectory() + @"\Images\默认图片\默认图.png";//默认图 路径
        string path = System.IO.Directory.GetCurrentDirectory() + @"\Images\Singer\";//歌手图片
        string ImageName = "";//图片名


        public FrmSinger()
        {
            InitializeComponent();
        }

        #region 事件

        private void FrmSinger_Load(object sender, EventArgs e)
        {
            bindSingType();
            showDgvSingers();
            pbPhoto.Image = Image.FromFile(pathPhoto);//显示默认图片片
            cboGrande.SelectedIndex = 0;
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("请输入歌手姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CopyPhoto();//复制图片到运行目录下

                Singer s = new Singer();
                s.Name = txtName.Text.Trim();
                s.Gender = cboGrande.Text.Trim();
                s.Type = cboType.SelectedValue.ToString();
                s.PhotoURL = ImageName.Trim();
                s.Remake = txtRemark.Text.Trim();
                s.AddTime = DateTime.Now;

                int count = 0;


                if (string.IsNullOrEmpty(txtId.Text))//增加
                {
                    count = singerManager.AddSingerInfo(s);
                }
                else//修改
                {
                    s.SingId = Convert.ToInt32(txtId.Text);
                    count = singerManager.UpdateSingerInfo(s);
                }

                if (count > 0)
                {
                    showDgvSingers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (ofPicture.ShowDialog() == DialogResult.OK)
            {
                ImageUrl = ofPicture.FileName;//获取图片绝对路径
                pbPhoto.Image = Image.FromFile(ImageUrl);//加载图片
                ImageName = System.IO.Path.GetFileName(ImageUrl);
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbReset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            cboGrande.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            txtRemark.Text = "";
            pbPhoto.Image = Image.FromFile(pathPhoto);
        }
        /// <summary>
        /// 单击DGV行同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSinger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSinger.SelectedRows.Count > 0)
            {
                txtId.Text = dgvSinger.SelectedRows[0].Cells["编号"].Value.ToString();//编号
                txtName.Text = dgvSinger.SelectedRows[0].Cells["歌手"].Value.ToString();
                cboGrande.Text = dgvSinger.SelectedRows[0].Cells["性别"].Value.ToString();
                cboType.Text = dgvSinger.SelectedRows[0].Cells["类型"].Value.ToString();
                txtRemark.Text = dgvSinger.SelectedRows[0].Cells["简介"].Value.ToString();
                ImageUrl = dgvSinger.SelectedRows[0].Cells["图片"].Value.ToString();
               

                try
                {
                    if (!string.IsNullOrEmpty(ImageUrl))
                    {
                        //pbPhoto.Image = Image.FromFile(path+ dgvSinger.SelectedRows[0].Cells[5].Value.ToString());
                        pbPhoto.Image = Image.FromFile(path + ImageUrl);
                    }
                    else
                    {
                        pbPhoto.Image = Image.FromFile(pathPhoto);
                    }
                }
                catch (Exception ex)
                {
                    pbPhoto.Image = Image.FromFile(pathPhoto);
                    //MessageBox.Show("图片不存在：" + ex.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        /// <summary>
        /// 删除,同时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("请选择要删除的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确定要删除改行吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (singerManager.DeleteSingerById(int.Parse(txtId.Text)) > 0)
                {


                    showDgvSingers();
                }
            }
        }
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSinger_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}",e.Row.Index+1);
        }

        #endregion

        #region 方法
        /// <summary>
        /// 绑定类型下拉框
        /// </summary>
        public void bindSingType()
        {
            try
            {
                cboType.DataSource = singTypeManager.GetAllTypes();
                cboType.DisplayMember = "singType";
                cboType.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 绑定歌手信息到DGV
        /// </summary>
        public void showDgvSingers()
        {
            try
            {
                dgvSinger.DataSource = singerManager.GetAllSingers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 保存图片到程序运行目录
        /// </summary>
        public void CopyPhoto()
        {
            try
            {
                //string path = System.IO.Directory.GetCurrentDirectory();//获取程序运行目录
                if (ImageUrl != "")
                {
                    bool isPic = false;
                    string fileExtension = System.IO.Path.GetExtension(ImageUrl);//获取文件的扩展名

                    string[] exites = { ".gtf", ".png", ".jpg", ".bmp", ".jpeg" };
                    foreach (string each in exites)
                    {
                        if (fileExtension == each)
                        {
                            isPic = true;
                            break;
                        }
                    }

                    if (isPic)
                    {
                        if (!System.IO.File.Exists(path + ImageName))//判断图片是否存在
                        {
                            System.IO.File.Copy(ImageUrl, path + ImageName);//复制图片到运行目录
                        }
                    }
                    else
                    {
                        MessageBox.Show("只能保存：.gtf、.png、.jpg、.bmp、.jpeg图片文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("请选择图片！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        #endregion


    }
}
