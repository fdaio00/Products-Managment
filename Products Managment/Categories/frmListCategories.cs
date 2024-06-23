using Products_Managment.Categories.Reports;
using System;
using System.Data;
using System.Windows.Forms;

namespace Products_Managment.Categories
{
    public partial class frmListCategories : Form
    {
        clsCategory _Category;
        int nRow;

        //public event Action<int> OnCatSelected; 

        //public virtual void SelectedCat(int CatID)
        //{
        //    Action<int> handler = OnCatSelected;
        //    if(handler != null)
        //    {
        //        handler(CatID);    
        //    }
        //}
        private DataTable _dtListCategories;
        public frmListCategories()
        {
            InitializeComponent();

        }

        private void frmListCategories_Load(object sender, EventArgs e)
        {
            _dtListCategories = clsCategory.GetAllCategories();
            dgvListCategories.DataSource = _dtListCategories;

            if (dgvListCategories.Rows.Count > 0)
            {
                nRow = dgvListCategories.CurrentCell.RowIndex;
                dgvListCategories.Rows[0].Selected = true;
                

                dgvListCategories.Columns[0].HeaderText = "معرف الصنف";
                dgvListCategories.Columns[1].HeaderText = "وصف الصنف";
                int CatID = (int)(long)dgvListCategories.Rows[nRow].Cells[0].Value;

                _Category = clsCategory.FindCategoryByCatID(CatID);
                if (_Category == null)
                    return;
          }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (nRow < dgvListCategories.RowCount - 1)
            {
                dgvListCategories.Rows[nRow].Selected = false;
                dgvListCategories.Rows[++nRow].Selected = true;
                int CatID = (int)(long)dgvListCategories.Rows[nRow].Cells[0].Value;

                _Category = clsCategory.FindCategoryByCatID(CatID);
                if (_Category == null)
                    return;
                

            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {


            if (nRow > 0)
            {
                dgvListCategories.Rows[nRow].Selected = false;
                dgvListCategories.Rows[--nRow].Selected = true;
                int CatID = (int)(long)dgvListCategories.Rows[nRow].Cells[0].Value;

                _Category = clsCategory.FindCategoryByCatID(CatID);
                if (_Category == null)
                    return;
                
            }
        }


        private void dgvListCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nRow = dgvListCategories.CurrentCell.RowIndex;
            int CatID = (int)(long)dgvListCategories.Rows[nRow].Cells[0].Value;

            _Category = clsCategory.FindCategoryByCatID(CatID);
            if (_Category == null)
                return;
         

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int CatID = (int)(long)dgvListCategories.Rows[nRow].Cells[0].Value;
            frmAddEditCat frm = new frmAddEditCat(CatID);
            frm.ShowDialog();
            frmListCategories_Load(null, null);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddEditCat frm = new frmAddEditCat();
            frm.ShowDialog();
            frmListCategories_Load(null, null);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int CatID = (int)(long)dgvListCategories.Rows[nRow].Cells[0].Value;

            if (MessageBox.Show("هل انت متاكد من حذف الصنف المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (clsCategory.DeleteCategory(CatID))
                {
                    MessageBox.Show("تم الحذف بنجاح", "تم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListCategories_Load(null, null);

                }
                else
                {
                    MessageBox.Show("حدث خطأ ما", "لم يتم الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void btnCurrentCat_Click(object sender, EventArgs e)
        {
            repPrintCatWithItems myReport = new repPrintCatWithItems();
            frmPrintCategoryWithItmes frm = new frmPrintCategoryWithItmes();
            myReport.SetParameterValue("@ID", (int)(long)dgvListCategories.Rows[nRow].Cells[0].Value);
            frm.crystalReportViewer1.ReportSource = myReport;
            frm.ShowDialog(); 
        }

        private void btnSaveCatListInPDF_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintAllCat_Click(object sender, EventArgs e)
        {

        }
    }
}
