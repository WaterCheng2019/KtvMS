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
    public partial class FrmPlayHistory : Form
    {
        SongManager songManager = new SongManager();
        
        public FrmPlayHistory()
        {
            InitializeComponent();
        }

        private void FrmPlayHistory_Load(object sender, EventArgs e)
        {
            bindDgvSongHistory();
        }

        public void bindDgvSongHistory()
        {
            try
            {
                dgvPlayHistory.DataSource = songManager.GetPlayHistoryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        private void dgvPlayHistory_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = String.Format("{0}", e.Row.Index + 1);
        }
    }
}
