using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Managment.Customers
{
    public partial class frmListCustomers : Form
    {

        private DataTable _dtCustomers;
        private clsCustomer _Customer;


        private int nRow;
        public frmListCustomers()
        {
            InitializeComponent();
        }

        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            _dtCustomers = clsCustomer.GetAllCustomers();
            dgvListCustomers.DataSource = _dtCustomers;

            if (dgvListCustomers.Rows.Count > 0)
            {
                dgvListCustomers.Rows[nRow].Selected = true;

                txtFirstName.Text = _dtCustomers.Rows[nRow][1].ToString();
                txtLastName.Text = _dtCustomers.Rows[nRow][2].ToString();
                txtPhone.Text = _dtCustomers.Rows[nRow][4].ToString();
                txtEmail.Text = _dtCustomers.Rows[nRow][5].ToString();
                if (_dtCustomers.Rows[nRow][6].ToString() != "")
                    pbCustomerImage.Load(_dtCustomers.Rows[nRow][6].ToString());
                else
                    pbCustomerImage.Image = null;

                dgvListCustomers.Columns[0].Visible = false;
                dgvListCustomers.Columns[1].Visible = false;
                dgvListCustomers.Columns[2].Visible = false;
                dgvListCustomers.Columns[6].Visible = false;


                dgvListCustomers.Columns[3].HeaderText = "الاسم الكامل";
                dgvListCustomers.Columns[4].HeaderText = "البريد الاكتروني";
                dgvListCustomers.Columns[5].HeaderText = "رقم الهاتف";
            }

        }

        private void dgvListCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nRow = dgvListCustomers.CurrentCell.RowIndex;
            int CustomerID = (int)dgvListCustomers.CurrentRow.Cells[0].Value;
            _Customer = clsCustomer.FindCustomerByCustomerID(CustomerID);
            if (_Customer == null)
                return;

            txtFirstName.Text = _Customer.FirstName;
            txtLastName.Text = _Customer.LastName;
            txtEmail.Text = _Customer.Email;
            txtPhone.Text = _Customer.Phone;

            if (_Customer.ImagePath != "")
            {
                pbCustomerImage.Load(_Customer.ImagePath);
            }
            else
                pbCustomerImage.Image = null;


        }

        private void ClearTextBoxes()
        {
            txtEmail.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            pbCustomerImage.Image = null;
            pbCustomerImage.ImageLocation = "";

        }



        private void btnNew_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes();
            _Customer = new clsCustomer();
            txtFirstName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_Customer == null)
            {
                return;
            }

            _Customer.FirstName = txtFirstName.Text.Trim();
            _Customer.LastName = txtLastName.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();

            if (pbCustomerImage.ImageLocation != "")
                _Customer.ImagePath = pbCustomerImage.ImageLocation;
            else
                _Customer.ImagePath = "";

            if (_Customer.Save())
            {
                MessageBox.Show("تم التعديل بنجاح", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("لم يتم التعديل", "لم يتم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            frmListCustomers_Load(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _Customer.FirstName = txtFirstName.Text.Trim();
            _Customer.LastName = txtLastName.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            if (pbCustomerImage.ImageLocation != "")
                _Customer.ImagePath = pbCustomerImage.ImageLocation;
            else
                _Customer.ImagePath = "";

            if (_Customer.Save())
            {
                MessageBox.Show("تم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("لم يتم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            frmListCustomers_Load(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int CustomerID = (int)dgvListCustomers.CurrentRow.Cells[0].Value;

            if (clsCustomer.DeleteByCustomerID(CustomerID))
            {
                MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("لم يتم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            frmListCustomers_Load(null, null);
        }


        private void _Navigate(bool Next = true, int Position=0)
        {
            if(Next)
            {
                if (nRow < dgvListCustomers.RowCount - 1)
                {
                    dgvListCustomers.Rows[nRow].Selected = false;
                    dgvListCustomers.Rows[++nRow].Selected = true;

                    txtFirstName.Text = _dtCustomers.Rows[nRow][1].ToString();
                    txtLastName.Text = _dtCustomers.Rows[nRow][2].ToString();
                    txtPhone.Text = _dtCustomers.Rows[nRow][4].ToString();
                    txtEmail.Text = _dtCustomers.Rows[nRow][5].ToString();
                    if (_dtCustomers.Rows[nRow][6].ToString() != "")
                        pbCustomerImage.Load(_dtCustomers.Rows[nRow][6].ToString());
                    else
                        pbCustomerImage.Image = null;

                }


            }
            else
            {
                if (nRow > 0)
                {
                    dgvListCustomers.Rows[nRow].Selected = false;
                    dgvListCustomers.Rows[--nRow].Selected = true;

                    txtFirstName.Text = _dtCustomers.Rows[nRow][1].ToString();
                    txtLastName.Text = _dtCustomers.Rows[nRow][2].ToString();
                    txtPhone.Text = _dtCustomers.Rows[nRow][4].ToString();
                    txtEmail.Text = _dtCustomers.Rows[nRow][5].ToString();
                    if (_dtCustomers.Rows[nRow][6].ToString() != "")
                        pbCustomerImage.Load(_dtCustomers.Rows[nRow][6].ToString());
                    else
                        pbCustomerImage.Image = null;

                }

               
            }
        }
        private void pbCustomerImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "ملفات الصور|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbCustomerImage.Load(selectedFilePath);

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                _dtCustomers.DefaultView.RowFilter = "";
                return; 
            }

            
                _dtCustomers.DefaultView.RowFilter = String.Format("[{0}] like '{1}%'", "FullName", txtSearch.Text.Trim());

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            _Navigate();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _Navigate(false);
        }

        private void dgvListCustomers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //if(nRow< dgvListCustomers.Rows.Count-1)
            //{
            //    MessageBox.Show("هذا اخر عنصر", "اخر عنصر");
            //    return; 
            //}
        }
    }
}
