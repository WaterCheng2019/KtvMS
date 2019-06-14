using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtvMS
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private int currentIndex = 0;



        private void FrmAbout_Load(object sender, EventArgs e)
        {
           // pictureBox1.Image = imageList2.Images[0];
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //pictureBox1.Image = imageList2.Images[1];
        //    currentIndex++;
        //    if (currentIndex > imageList2.Images.Count - 1)
        //    {
        //        currentIndex = 0;
            
        //}
    }
    }
}
