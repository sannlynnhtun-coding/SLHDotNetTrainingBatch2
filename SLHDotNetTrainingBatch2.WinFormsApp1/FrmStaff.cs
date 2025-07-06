using SLHDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;
using System.Net.Mail;

namespace SLHDotNetTrainingBatch2.WinFormsApp1
{
    public partial class FrmStaff : Form
    {
        private readonly AppDbContext _db;
        private int _editId;
        public FrmStaff()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvData.AutoGenerateColumns = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editId == 0)
                {
                    _db.TblStaffs.Add(new TblStaff
                    {
                        EmailAddress = txtEmail.Text.Trim(), // " Mg Mg "
                        IsDelete = false,
                        MobileNo = txtMobileNo.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        Position = cboPosition.Text.Trim(),
                        StaffCode = txtCode.Text.Trim(),
                        StaffName = txtName.Text.Trim()
                    });
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCode.Clear();
                    txtEmail.Clear();
                    txtMobileNo.Clear();
                    txtPassword.Clear();
                    cboPosition.Text = "";
                    txtName.Clear();

                    txtCode.Focus();

                    BindData();
                } else
                {
                    TblStaff? staffData = _db.TblStaffs.FirstOrDefault(x => x.StaffId == _editId && x.IsDelete == false);
                    if (staffData is null)
                    {
                        return;
                    }

                    staffData.StaffCode = txtCode.Text.Trim();
                    staffData.StaffName = txtName.Text.Trim();
                    staffData.EmailAddress = txtEmail.Text.Trim();
                    staffData.Password = txtPassword.Text.Trim();
                    staffData.Position = cboPosition.Text.Trim();
                    staffData.MobileNo = txtMobileNo.Text.Trim();
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "Update Successful." : "Update Failed.";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCode.Clear();
                    txtName.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    cboPosition.SelectedIndex = -1;
                    txtMobileNo.Clear();
                    txtCode.Focus();
                    _editId = 0;
                    btnSave.Text = "Save";
                    txtCode.Focus();

                    BindData();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                dgvData.DataSource = _db.TblStaffs.ToList();
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            //if(e.ColumnIndex == 0)
            if (e.ColumnIndex == dgvData.Columns["colEdit"].Index)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if (item is null)
                {
                    return;
                }

                txtCode.Text = item.StaffCode;
                txtName.Text = item.StaffName;
                txtEmail.Text = item.EmailAddress;
                txtPassword.Text = item.Password;
                cboPosition.Text = item.Position;
                txtMobileNo.Text = item.MobileNo;
                _editId = id;

                btnSave.Text = "Update";
            }
            else if (e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
                var confirm = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;

                // Delete process

                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString()!);
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if (item is null)
                {
                    return;
                }

                _db.TblStaffs.Remove(item);
                int result = _db.SaveChanges();
                string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
            }
        }
    }
}
