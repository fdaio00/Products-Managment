using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Products_Managment.Categories
{
    public partial class frmAddEditCat : Form
    {

        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        int _CatID = -1;
        clsCategory _Category;
        public frmAddEditCat()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditCat(int CatID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CatID = CatID;
        }

        void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                gbAddEditCat.Text = "إضافة صنف جديد ";
                btnSave.Text = "حفظ";
                this.Text = "إضافة صنف جديد";
                _Category = new clsCategory();

            }
            else
            {
                gbAddEditCat.Text = " تعديل صنف";
                btnSave.Text = "تعديل";
                this.Text = "تعديل صنف";
            }
            txtCatDescription.Text = "";
            txtCatDescription.Focus();
        }

        void _LoadInfo()
        {
            _Category = clsCategory.FindCategoryByCatID(_CatID);
            if (_Category == null)
            {
                MessageBox.Show("لم يتم العثور على الصنف المحدد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtCatDescription.Text = _Category.CatDescription;
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddCat_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("يجب عليك ملؤ حميع الخانات المطلوبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Category.CatDescription = txtCatDescription.Text.Trim();

            if (_Category.Save())
            {
                if (_Mode == enMode.AddNew)
                {
                    MessageBox.Show("تم اضافة الصنف بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("تم تعديل الصنف بنجاح", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gbAddEditCat.Text = "تعديل صنف";
                btnSave.Text = "تعديل";
                this.Text = "تعديل صنف";
                _Mode = enMode.Update;
                this.Close();
            }
            else
            {
                MessageBox.Show("لم يتم الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void txtCatDescription_Leave(object sender, EventArgs e)
        {

        }

        private void txtCatDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCatDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCatDescription, "هذا الحقل يجب تعبئته");

            }
            else
            {
                errorProvider1.SetError(txtCatDescription, null);

            }
        }
    }
}
