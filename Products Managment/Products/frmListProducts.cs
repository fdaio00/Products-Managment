using Product_Managment_BusniessLayer;
using Products_Managment.Products;
using Products_Managment.Products.Report;
using System;
using System.Data;
using System.Windows.Forms;

namespace Products_Managment
{
    public partial class frmListProducts : Form
    {

        private DataTable _dtAllProducts;
        public frmListProducts()
        {
            InitializeComponent();
            _FillFilterComboBox();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilter.Text.Trim();

            if (txtSearch.Text.Trim() == "")
            {
                _dtAllProducts.DefaultView.RowFilter = "";
                return;
            }
            if (FilterColumn == "معرف المنتج")
                _dtAllProducts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());

            if (FilterColumn == "الكمية")
                _dtAllProducts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());

            if (FilterColumn == "السعر")
                _dtAllProducts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());

            else
                _dtAllProducts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());



        }

        void _FillFilterComboBox()
        {
            DataTable dt = clsProduct.GetAllProducts();
            cbFilter.Items.Clear();
            foreach (DataColumn col in dt.Columns)
            {
                cbFilter.Items.Add(col.ColumnName);
            }
        }
        private void frmManageProducts_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            _dtAllProducts = clsProduct.GetAllProducts();
            
            dgvListProducts.DataSource = _dtAllProducts;

            //if(dgvListProducts.Rows.Count>0)
            //{

            //    dgvListProducts.Columns[0].HeaderText = "معرف المنتج";
            //    dgvListProducts.Columns[0].Width = 100;

            //    dgvListProducts.Columns[1].HeaderText = "اسم المنتج";
            //    dgvListProducts.Columns[1].Width = 160;

            //    dgvListProducts.Columns[2].HeaderText = "الكمية";
            //    dgvListProducts.Columns[2].Width = 110;

            //    dgvListProducts.Columns[3].HeaderText = "السعر";
            //    dgvListProducts.Columns[3].Width = 110;

            //    dgvListProducts.Columns[4].HeaderText = "نوع الصنف";
            //    dgvListProducts.Columns[4].Width = 130;



            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddEditProduct frm = new frmAddEditProduct();
            frm.ShowDialog();
            frmManageProducts_Load(null, null);
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            int ProductID = (int)(long)dgvListProducts.CurrentRow.Cells[0].Value;

            frmAddEditProduct frm = new frmAddEditProduct(ProductID);
            frm.ShowDialog();
            frmManageProducts_Load(null, null);
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {

            int ProductID = (int)(long)dgvListProducts.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("هل انت متاكد من حذف المنتج المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (clsProduct.DeleteProduct(ProductID))
                {
                    MessageBox.Show("تم الحذف بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("حدث خطأ ما", "لم يتم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            frmManageProducts_Load(null, null);
        }

        private void btnPrintProduct_Click(object sender, EventArgs e)
        {
            repPrintSelectedProduct MyRepoert = new repPrintSelectedProduct();
            frmPrintSelecteProduct frm = new frmPrintSelecteProduct();
            MyRepoert.SetParameterValue("@ProductID", (int)(long)dgvListProducts.CurrentRow.Cells[0].Value);
            frm.crystalReportViewer1.ReportSource = MyRepoert;
            frm.ShowDialog();
        }

        private void btnPrintAllProducts_Click(object sender, EventArgs e)
        {
            repPrintAllProducts myReport = new repPrintAllProducts();
            frmPrintAllProducts frm = new frmPrintAllProducts();
            frm.crystalReportViewer1.ReportSource = myReport;
            frm.ShowDialog();
        }

        private void btnSaveInExcle_Click(object sender, EventArgs e)
        {

        }
    }
}
