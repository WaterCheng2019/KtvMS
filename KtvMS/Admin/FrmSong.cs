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
    public partial class FrmSong : Form
    {
        public FrmSong()
        {
            InitializeComponent();
        }
        SongTypeManager songTypeManger = new SongTypeManager();
        SongManager songManager = new SongManager();
        SingerManager singerManager = new SingerManager();
        String SongName = "";
        String filePath = System.IO.Directory.GetCurrentDirectory() + @"\misucs\";
        String ofFileURL = "";

        #region 事件
        private void FrmSong_Load(object sender, EventArgs e)
        {
            bindSongTypes();
            bindSinger();
            bindDgvSongs();

        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofOpenFlie.ShowDialog() == DialogResult.OK)
                {
                    ofFileURL = ofOpenFlie.FileName;
                    SongName = ofOpenFlie.SafeFileName;//获取文件名和扩展名
                    bool isSong = false;
                    string fileExtension = System.IO.Path.GetExtension(ofFileURL);
                    string[] exites = new string[] { ".mp3",".wav"};
                    foreach (string i in exites)
                    {
                        if (i==fileExtension)
                        {
                            isSong = true;
                            break;
                        }
                    }

                    if (isSong)
                    {
                        txtFile.Text = ofFileURL;
                    }
                    else
                    {
                        MessageBox.Show("请选择.mp3或.wav格式的音频文件", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("请输入歌曲名！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (String.IsNullOrEmpty(cboSingers.Text))
            {
                MessageBox.Show("请选择歌手！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (String.IsNullOrEmpty(txtFile.Text))
            //{
            //    MessageBox.Show("请选择歌曲文件！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            try
            {

                //手动录入，如果歌手不存在，则添加歌手
                bool isExist = true;
                String SingerName = cboSingers.Text;
                String SingerId = "";
                List<Singer> singers = singerManager.GetAllSingers();


                foreach (Singer i in singers)
                {
                    if (i.Name == SingerName)
                    {
                        isExist = false;
                        break;
                    }
                }

                if (isExist)
                {
                    Singer singer = new Singer();
                    singer.Name = cboSingers.Text;
                    singer.Type = "1";
                    singer.AddTime = DateTime.Now;
                    singerManager.AddSingerInfo(singer);
                    SingerId = singerManager.GetNewId();
                    bindSinger();
                }

                Song s = new Song();
                s.Id =txtId.Text;
                s.name = txtName.Text.Trim();
                s.songName = SongName;
                s.pinyin = txtPinYin.Text;
                s.songtypeID = cboTypes.SelectedValue.ToString();
               
            
                s.singerId = SingerId == "" ? cboSingers.SelectedValue.ToString() : SingerId;

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MoveSong();//移动歌曲
                    s.songURL = ofFileURL;//文件全路径
                }
                else
                {
                    s.songURL = txtFile.Text.Trim();// 文件全路径
                }
               
                int row = songManager.SaveSong(s);

                if (row>0)
                {
                    bindDgvSongs();
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("请选择要删除的歌曲！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvSongs.SelectedRows.Count>0)
            {
                if (MessageBox.Show("会永久删除本地歌曲！！确定要继续删除该歌曲吗？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    int SongId = Convert.ToInt32(dgvSongs.SelectedRows[0].Cells["编号"].Value);
                    String songName=dgvSongs.SelectedRows[0].Cells["歌曲全名"].Value.ToString();
                    if (songManager.DeleteSongById(SongId)>0)
                    {
                        String songPath = filePath + songName;
                        System.IO.File.Delete(songPath);//删除该行歌曲

                        bindDgvSongs();
                        Reset();
                    }
                }
            }

           
        }
        //搜索
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
          
                    dgvSongs.DataSource=songManager.GetAllSongs(txtName.Text);
          
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSongs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSongs.SelectedRows.Count>0)
            {
                txtId.Text = dgvSongs.SelectedRows[0].Cells["编号"].Value.ToString();
                txtName.Text = dgvSongs.SelectedRows[0].Cells["歌曲"].Value.ToString();
                txtPinYin.Text = dgvSongs.SelectedRows[0].Cells["拼音"].Value.ToString();
                txtFile.Text = dgvSongs.SelectedRows[0].Cells["路径"].Value.ToString();
                cboTypes.Text = dgvSongs.SelectedRows[0].Cells["类型"].Value.ToString();
                cboSingers.Text = dgvSongs.SelectedRows[0].Cells["歌手名称"].Value.ToString();

                //DataGridViewCheckBoxCell dgvCheck = (DataGridViewCheckBoxCell)(this.dgvSongs.Rows[this.dgvSongs.CurrentCell.RowIndex].Cells[0]);
                //if (Convert.ToBoolean(dgvCheck.EditedFormattedValue)==false)
                //{
                //    dgvCheck.Value = true;
                //}
                //else
                //{
                //    dgvCheck.Value = false;
                //}

                
            }

        }


        private void tsbReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSongs_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}",e.Row.Index+1);
           // e.Row.Cells[0].Value = false;
        }

        #endregion


        #region 方法
        /// <summary>
        ///绑定类型下拉框
        /// </summary>
        public void bindSongTypes()
        {
            try
            {
                cboTypes.DataSource = songTypeManger.GetAllSongType();
                cboTypes.DisplayMember = "songType";
                cboTypes.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"异常信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 绑定割手下拉框
        /// </summary>
        public void bindSinger()
        {
            try
            {
                cboSingers.DataSource = singerManager.GetAllSingers();
                cboSingers.DisplayMember = "Name";
                cboSingers.ValueMember = "SingId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 绑定歌曲列表
        /// </summary>
        public void bindDgvSongs()
        {
            try
            {
                dgvSongs.DataSource = songManager.GetAllSongs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 移动歌曲到程序运行目录
        /// </summary>
        private void MoveSong()
        {
            if (!System.IO.File.Exists(filePath+SongName))
            {
                System.IO.File.Move(ofFileURL, filePath+ SongName);//移动歌曲文件
            }
        }
        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPinYin.Text = "";
            txtFile.Text = "";
            cboTypes.SelectedIndex = 0;
            cboSingers.SelectedIndex = 0;
        }





        #endregion

     
    }
}
