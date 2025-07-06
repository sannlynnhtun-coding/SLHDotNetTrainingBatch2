using SLHDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;
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
    public partial class FrmLogin : Form
    {
        private readonly AppDbContext _db;

        public FrmLogin()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string staffCode = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var item = _db.TblStaffs.FirstOrDefault(x => x.StaffCode == staffCode && x.Password == password);
            //if(item == null)
            if (item is null)
            {
                MessageBox.Show("Username or Password was wrong.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();

            FrmMenu frm = new FrmMenu();
            frm.ShowDialog();

            if (!frm.isExit)
            {
                this.Show();
                return;
            }

            Application.Exit();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
