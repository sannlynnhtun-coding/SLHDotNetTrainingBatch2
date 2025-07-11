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
    public partial class frmProduct : Form
    {
        private readonly AppDbContext _db;
        private int _editID;
        public frmProduct()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvProductList.AutoGenerateColumns = false;
        }

        private void btnSavelClick(object sender, EventArgs e)
        {
            try
            {
                if (_editID == 0)
                {

                    _db.TblProducts.Add(new TblProduct
                    {
                        ProductCode = txtProductCode.Text.Trim(),
                        ProductItem = txtProductName.Text.Trim(),
                        Price = Convert.ToDecimal(txtProductPrice.Text.Trim()),
                        IsDelete = false
                    });
                    int result = _db.SaveChanges();
                    string messageStr = result > 0 ? "Saving Successful!" : "Saving Failed";
                    MessageBox.Show(messageStr, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtProductCode.Clear();
                    txtProductName.Clear();
                    txtProductPrice.Clear();

                    txtProductCode.Focus();
                }
                else
                {
                    TblProduct? productList = _db.TblProducts.FirstOrDefault(x => x.ProductId == _editID);
                    if (productList == null)
                    {
                        //MessageBox.Show(" Product is deleted, It cannot change anything");
                        return;
                    }
                    productList.ProductCode = txtProductCode.Text.Trim();
                    productList.ProductItem = txtProductName.Text.Trim();
                    productList.Price = Convert.ToInt32(txtProductPrice.Text.Trim());
                    productList.IsDelete = false;

                    int result = _db.SaveChanges();
                    var message = result > 0 ? " Updating Successful" : " Updating Failed";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtProductCode.Clear();
                    txtProductName.Clear();
                    txtProductPrice.Clear();
                    txtProductCode.Focus();
                    _editID = 0;
                    BlindData();

                }


            }
            catch (Exception)
            {

            }
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {
            BlindData();
        }

        private void BlindData()
        {
            try
            {
                dgvProductList.DataSource = _db.TblProducts.ToList();
            }
            catch (Exception)
            {


            }
        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (e.ColumnIndex == dgvProductList.Columns["colEdit"].Index)
            {
                int id = Convert.ToInt32(dgvProductList.Rows[e.RowIndex].Cells["colPId"].Value.ToString()!);
                var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
                if (item is null) return;

                txtProductCode.Text = item.ProductCode;
                txtProductName.Text = item.ProductItem;
                txtProductPrice.Text = Convert.ToString(item.Price);
                chkDelete.Checked = Convert.ToBoolean(item.IsDelete);
                _editID = id;


            }
            else if (e.ColumnIndex == dgvProductList.Columns["colDelete"].Index)
            {
                int id = Convert.ToInt32(dgvProductList.Rows[e.RowIndex].Cells["colPId"].Value.ToString());
                TblProduct? item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
                if (item is null) return;

                //_db.TblProducts.Remove(item);

                item.IsDelete = true;

                int result = _db.SaveChanges();
                var message = result > 0 ? "Deleting Successful" : "Deleteing Failed";
                MessageBox.Show(message, "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            }
        }
    }
}