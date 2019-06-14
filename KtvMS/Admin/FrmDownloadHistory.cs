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
    public partial class FrmDownloadHistory : Form
    {
        DownloadSongManager downloadSongManager = new DownloadSongManager();
        public FrmDownloadHistory()
        {
            InitializeComponent();
        }

        private void FrmDownloadHistory_Load(object sender, EventArgs e)
        {
            bindDgvSongHistory();
        }

        public void bindDgvSongHistory()
        {
            try
            {
                dgvDownloadHistory.DataSource = downloadSongManager.GetDownloadHistoyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDownloadHistory_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}",e.Row.Index+1);
        }
    }
}
