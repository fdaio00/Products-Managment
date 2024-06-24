using Product_Managment_BusniessLayer;
using Products_Managment.GlobalClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Products_Managment
{
    public partial class frmAddEditProduct : Form
    {

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private int _ProductID = -1;
        private clsProduct _Product;
        public frmAddEditProduct()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public frmAddEditProduct(int ProductID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ProductID = ProductID;
        }

        void _FillCategoriesInComboBox()
        {
            DataTable dt = clsCategory.GetAllCategories();

            foreach (DataRow row in dt.Rows)
            {
                cbProductCat.Items.Add(row["CatDescription"]);
            }
        }

        void _ResetDefaultValues()
        {
            _FillCategoriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                gbAddEditProduct.Text = "إضافة منتج";
                this.Text = "اضافة منتج جديد";

                _Product = new clsProduct();
            }
            else
            {
                gbAddEditProduct.Text = "تعديل منتج";
                this.Text = "تعديل منتج سابق";
            }
            lblProductID.Text = "غير مدخل";
            txtPrice.Text = "";
            txtProductDescription.Text = "";
            txtQuantity.Text = "";
            lklRemoveImage.Visible = (pbProductImage.ImageLocation != null);
            cbProductCat.SelectedIndex = 0;


        }

        void _LoadImage()
        {
            if (_Product.ImageProduct != "")
            {
                pbProductImage.Load(_Product.ImageProduct);

            }
            else
                pbProductImage.Image = null;
        }
        void _LoadData()
        {
            _Product = clsProduct.FindProductByID(_ProductID);
            if (_Product == null)
            {
                MessageBox.Show("لم يتم العثور على هذا المنتج ", "لم يتم العثور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string CatDescription = clsCategory.FindCategoryByCatID(_Product.CatID).CatDescription;
            cbProductCat.SelectedIndex = cbProductCat.FindString(CatDescription);
            txtPrice.Text = _Product.Price.ToString();
            lblProductID.Text = _Product.ProductID.ToString();
            txtProductDescription.Text = _Product.ProductName;
            txtQuantity.Text = _Product.Quantity.ToString();

            if (_Product.ImageProduct != "")
            {
                pbProductImage.ImageLocation = _Product.ImageProduct;
            }
            lklRemoveImage.Visible = (_Product.ImageProduct != "");

            _LoadImage();
        }
        private void frmAddEditProduct_Load(object sender, EventArgs e)

        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void ValidateTextBox(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "يحب عليك ملء هذا الحقل");
            }
            else
            {
                errorProvider1.SetError(temp, null);
            }
        }
        private void lklAddImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbProductImage.Load(selectedFilePath);
                // ...
                lklRemoveImage.Visible = true;
            }
        }

        private void lklRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbProductImage.ImageLocation = null;
            lklRemoveImage.Visible = false;
        }

        private bool _HandleProductImage()
        {

            if (_Product.ImageProduct != pbProductImage.ImageLocation)
            {


                if (_Product.ImageProduct != "")
                {


                    try
                    {
                        File.Delete(_Product.ImageProduct);
                    }
                    catch (IOException iox)
                    {
                        MessageBox.Show(iox.Message);
                    }
                }
            }

            if (pbProductImage.ImageLocation != null)
            {
                string sourceImageFile = pbProductImage.ImageLocation;
                if (clsUtil.CopyImageToProjectImagesFolder(ref sourceImageFile))
                {
                    pbProductImage.ImageLocation = sourceImageFile;
                    return true;
                }

                else
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("يجب عليك ملء جميع الحقول الفارغة", "حقل فارغ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleProductImage())
                return;

            int CatID = clsCategory.FindCategoryByCatName(cbProductCat.Text.Trim()).CatID;

            _Product.CatID = CatID;
            _Product.Price = Convert.ToDecimal(txtPrice.Text.Trim());
            _Product.ProductName = txtProductDescription.Text.Trim();
            _Product.Quantity = Convert.ToInt16(txtQuantity.Text.Trim());

            if (pbProductImage.ImageLocation != null)
                _Product.ImageProduct = pbProductImage.ImageLocation;
            else
                _Product.ImageProduct = "";

            if (_Product.Save())
            {
                lblProductID.Text = _Product.ProductID.ToString();
                MessageBox.Show("تمت اضافة المنتج بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Text = "تعديل منتج سابق";
                gbAddEditProduct.Text = "تعديل منتج";
                this.Close();
            }

            else
            {
                MessageBox.Show("فشل في حفظ المنتج", "فشل الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrice, "يحب عليك ملء هذا الحقل");
            }
            else
            {

                errorProvider1.SetError(txtPrice, null);

            }

            if (!clsValidation.IsNumber(txtPrice.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrice, "هذا الحقل يجب ان يحتوي على أرقام فقط");
            }

            else
            {
                errorProvider1.SetError(txtPrice, null);

            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
