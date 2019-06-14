using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using KtvMSModel;
using KtvSYSBLL;

namespace KtvMS
{
    public partial class FrmMain : Form
    {
        UserManager userManager = new UserManager();
        SongManager songManager = new SongManager();
        SingerManager singerManager = new SingerManager();
        NewSongManager newSongManager = new NewSongManager();
        DownloadSongManager downloadSongManger = new DownloadSongManager();

        List<Song> songs = new List<Song>();
        String path = Directory.GetCurrentDirectory() + @"\misucs\";//获取音乐文件目录

        delegate void UpdateListCallback(List<ListViewItem> listViewItems);//用于将LvSong更新的委托类型


        public FrmMain()
        {
            InitializeComponent();
        }
        #region 事件

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "admin";
            bindSongs();
            //tc.SelectedIndex = 1;

            txtDownLoadPath.Text = path;
        }
        /// <summary>
        /// 切换选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tcIndex = tc.SelectedIndex;
            switch (tcIndex)
            {
                case 0://主页面
                    bindSongs();
                    break;
                case 1://歌曲下载

                    break;
                case 2://登陆后台

                    break;
            }
        }
        /// <summary>
        /// 定时随机播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_Tick(object sender, EventArgs e)
        {
            try
            {
                if (wmpSong.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    int Index = new Random(GetRandomSeed()).Next(0, dgvSong1.Rows.Count);
                    String SongName = dgvSong1.Rows[Index].Cells["AllSongName"].Value.ToString();
                    int SongId= Convert.ToInt32(dgvSong1.Rows[Index].Cells["SongId"].Value.ToString());
                    wmpSong.URL = path + SongName;
                    wmpSong.Ctlcontrols.play();
                    SavePlayInfo(SongId);//保存播放记录、更新播放次数

                    lblSongName1.Text = "正在播放的歌曲："+SongName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("随机播放异常    " + ex.Message, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 双击播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSong1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSong1.SelectedRows.Count > 0)
                {
                    String SongName = dgvSong1.SelectedRows[0].Cells["AllSongName"].Value.ToString();
                    int SongId = int.Parse(dgvSong1.SelectedRows[0].Cells["SongId"].Value.ToString());
                    wmpSong.URL = path + SongName;
                    wmpSong.Ctlcontrols.play();
                    SavePlayInfo(SongId);//保存播放记录、更新播放次数

                    lblSongName1.Text = "正在播放的歌曲：" + SongName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("双击播放异常", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //查询
        private void btnSearchSong_Click(object sender, EventArgs e)
        {
            try
            {
                //if (String.IsNullOrEmpty(txtName.Text))
                //{
                //    MessageBox.Show("请输入查询条件！歌名、歌手或播放次数", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                dgvSong1.DataSource=songManager.GetAllSongs(txtName.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常信息 "+ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("请输入用户名！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (userManager.isLogin(txtUserName.Text.Trim(), txtUserPwd.Text.Trim()))
            {
                UserHelpercs.UserName = txtUserName.Text.Trim();
                userManager.LoginLog();
                FrmAdmin1 frmAdmin = new FrmAdmin1();
                frmAdmin.Show();
            }
            else
            {
                MessageBox.Show("密码或账号错误！！！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSong1_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }

        #endregion

        #region 方法
        /// <summary>
        /// 绑定DGV
        /// </summary>
        public void bindSongs()
        {
            try
            {
                songs = songManager.GetAllSongs();
                dgvSong1.DataSource = songs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 判断歌手是否存在
        /// </summary>
        /// <returns></returns>
        public bool isExeitsSinger(string singer)
        {
            bool falg = false;
            try
            {
                List<Singer> singerList = singerManager.GetAllSingers();

                if (singerList != null)
                {
                    foreach (Singer s in singerList)
                    {
                        if (s.Name == singer)
                        {
                            falg = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("插入歌手异常    " + ex.Message, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return falg;
        }
        /// <summary>
        /// 保存播放信息
        /// </summary>
        /// <param name=""></param>
        public void SavePlayInfo(int SongId)
        {
            songManager.UpatePlayCount(SongId);//更新播放次数
            songManager.SavePlayHistory(SongId);//保存播放记录
        }

        //随机播放
        public void RandomPlay(int A)
        {
            try
            {
                if (wmpSong.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                   
                    int Index = new Random(GetRandomSeed()).Next(0, dgvSong1.Rows.Count);
                    String SongName = dgvSong1.Rows[Index].Cells["AllSongName"].Value.ToString();
                    int SongId = Convert.ToInt32(dgvSong1.Rows[Index].Cells["SongId"].Value.ToString());
                    wmpSong.URL = path + SongName;
                    wmpSong.Ctlcontrols.play();
                    SavePlayInfo(SongId);//保存播放记录、更新播放次数

                    lblSongName1.Text = "正在播放的歌曲：" + SongName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("随机播放异常    " + ex.Message, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 描 述:创建加密随机数生成器 生成强随机种子
        /// </summary>
        /// <returns></returns>
        private  static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }


        #endregion


        #region 连网搜索下载

        int page = 1;
        string target = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Downlod";
        MusicProviders provider = MusicProviders.Instance;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            page = 1;
            GetList(page);
        }
        /// <summary>
        /// 获取歌曲列表
        /// </summary>
        public void GetList(int page)
        {
            StartProcessBar();
            lblPageIndex.Text = "第" + page + "页";
            lvSongs.Items.Clear();
            tsLable.Text = "搜索中。。。";
            List<ListViewItem> listViewItems = new List<ListViewItem>();

            var songs = provider.SearchSongs(txtSearch.Text, page, 15);

            songs.ForEach(item =>
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.SongName;
                lvi.SubItems.Add(item.Singer);
                lvi.SubItems.Add(item.Rate + "kb");
                lvi.SubItems.Add((item.Size / (1024 * 1024)).ToString("F2") + "MB");//将文件大小装换成MB的单位

                TimeSpan ts = new TimeSpan(0, 0, (int)item.Duration);//把秒转换成分钟
                lvi.SubItems.Add(ts.Minutes + ":" + ts.Seconds.ToString("00"));
                lvi.SubItems.Add(item.Source);
                lvi.Tag = item;
                listViewItems.Add(lvi);

            });

            UpdateUI(listViewItems);
        }

        /// <summary>
        /// 用于获取歌曲列表，并更新
        /// </summary>
        /// <param name="listViewItems"></param>
        private void UpdateUI(List<ListViewItem> listViewItems)
        {
            if (this.lvSongs.InvokeRequired)// 如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.lvSongs.IsHandleCreated)
                {
                    if (this.lvSongs.Disposing || this.lvSongs.IsDisposed)
                    {
                        return;
                    }
                    UpdateListCallback d = new UpdateListCallback(UpdateUI);
                    lvSongs.Invoke(d, new object[] { listViewItems });
                }
            }
            else
            {
                lvSongs.BeginUpdate();//数据更新，UI暂时挂起，直到EndUpdate绘制控件,可有效避免闪烁大大提高加载速度
                lvSongs.Items.AddRange(listViewItems.ToArray());
                lvSongs.EndUpdate();//结束数据处理，UI界面一次性绘制
                tsLable.Text = "搜索完成";
                StopProcessBar();

                if (lvSongs.Items.Count > 0)
                {
                    btnNextPage.Enabled = true;
                }
                else
                {
                    btnNextPage.Enabled = false;
                }


            }
        }

        /// <summary>
        /// 开始显示进度栏动画
        /// </summary>
        private void StartProcessBar()
        {
            tsState.Visible = true;
            tsState.Style = ProgressBarStyle.Marquee;
            tsState.MarqueeAnimationSpeed = 50;
        }

        /// <summary>
        /// 结束显示进度动画
        /// </summary>
        public void StopProcessBar()
        {
            tsState.Visible = false;
            tsState.Style = ProgressBarStyle.Blocks;
        }
        //上一页
        private void btnLastPage_Click(object sender, EventArgs e)
        {

            if (page > 1)
            {
                page--;
                GetList(page);

                if (page == 1)
                {
                    btnLastPage.Enabled = false;
                }
            }
        }
        //下一页
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            page++;
            GetList(page);
            if (page > 1)
            {
                btnLastPage.Enabled = true;
            }
        }
        //浏览
        private void btnDownLoadPath_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("下载路径一旦更改，将无法在主页面播放,确定要更改吗？", "温馨警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)==DialogResult.OK)
            {
                FolderBrowserDialog ofb = new FolderBrowserDialog();
                if (ofb.ShowDialog() == DialogResult.OK)
                {
                    txtDownLoadPath.Text = ofb.SelectedPath + "\\";
                    path = txtDownLoadPath.Text;
                }
            }
            

         
        }
        //下载
        SongDownloader downloader;
        private void btnStartDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                tsState.Value = 0;
                tsState.Visible = true;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (downloader == null)
                {
                    downloader = new SongDownloader(provider, path);
                }

                foreach (ListViewItem item in lvSongs.CheckedItems)
                {
                    timer1.Enabled = true;
                    timer1.Interval = 100;
                    MergedSong1 song = (MergedSong1)item.Tag;
                    downloader.AddDownload(song);

                    //若路径更改，则不往库中保存数据
                    if (txtDownLoadPath.Text.Trim()== Directory.GetCurrentDirectory() + @"\misucs\")  
                    {

                        //判断歌手是否已存在,若不存在则添加
                        if (!isExeitsSinger(song.Singer))
                        {
                            KtvMSModel.Singer singer = new KtvMSModel.Singer();
                            singer.Name = song.Singer;
                            singerManager.AddSingerInfo(singer);
                        }

                        //根据歌名判断歌曲是否存在，
                        if (!newSongManager.isExeitsSongByName(song.SongName))
                        {
                            Song1 song1 = new Song1();
                            song1.SongName = song.SongName;
                            song1.Singer = song.Singer;
                            song1.Source = song.Source;
                            song1.Duration = song.Duration;//播放时间
                            song1.Size = Convert.ToDouble((song.Size / (1024 * 1024)).ToString("F2"));//歌曲文件大小


                            int row = newSongManager.AddSong(song1);//添加歌曲
                            if (row > 0)
                            {
                                int songId = newSongManager.GetSongIdByName(song.SongName);
                                if (songId != null && songId != 0)
                                {
                                    downloadSongManger.AddDownloadSong(songId);//下载记录
                                }
                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsLable.Text = "下载进度" + (int)(downloader.totaPercent) + "%" + string.Format(",速度{0}", (downloader.totalSpeed / 1024.0 / 1024.0).ToString("F2") + "MB/S");
            tsState.Value = (int)(downloader.totaPercent);
            if (downloader.totaPercent >= 100d)
            {
                tsLable.Text = "下载完成！";
                timer1.Enabled = false;
                tsState.Visible = false;
            }
        }







        #endregion

      
    }
}
