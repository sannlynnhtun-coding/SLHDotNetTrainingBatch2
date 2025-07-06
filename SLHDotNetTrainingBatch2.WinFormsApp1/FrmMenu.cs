using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLHDotNetTrainingBatch2.WinFormsApp1
{
    public partial class FrmMenu : Form
    {
        public bool isExit = false;
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmProduct frm = new FrmProduct();
            //frm.ShowDialog();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStaff frm = new FrmStaff();
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isExit = true;
                this.Close();
            }
        }
    }
}
