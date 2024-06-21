using Product_Managment_BusniessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Managment.User
{
    public partial class frmListUsers : Form
    {

        private DataTable _dtUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void _FillComboBox()
        {
            if (_dtUsers != null)
            {
                foreach (DataColumn column in _dtUsers.Columns)
                {
                    cbFilter.Items.Add(column.ColumnName.ToString());
                }
            }

            cbFilter.SelectedIndex = 0;
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtUsers = clsUser.GetAllUsers();
            _FillComboBox();
            dgvListUsers.DataSource = _dtUsers;

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void b_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvListUsers.CurrentRow.Cells[0].Value);
            frmAddEditUser frm = new frmAddEditUser(UserID);
            frm.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string FilterColumn = cbFilter.Text.Trim();

                if (txtSearch.Text.Trim() == "" || txtSearch.Text.Trim() == "لاشيء")
                {
                    _dtUsers.DefaultView.RowFilter = "";
                    return;
                }
                if (FilterColumn.Equals("معرف المستخدم"))
                {
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
                    return;
                }

                else
                {

                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text.Equals("نوع المستخدم"))
            {
                txtSearch.Visible = false;
                cbIsManager.Visible = true;
                cbIsManager.Focus();
                cbIsManager.SelectedIndex = 0;

            }

            else
            {
                txtSearch.Visible = (cbFilter.Text.Trim() != "لاشيء");
                cbIsManager.Visible = false;
                if (cbFilter.Text.Trim() == "لاشيء")
                {
                    txtSearch.Enabled = false;
                    _dtUsers.DefaultView.RowFilter = "";
                }
                else
                    txtSearch.Enabled = true;

                txtSearch.Text = "";
                cbFilter.Focus();



            }


        }

        private void cbIsManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbIsManager.Text.Trim() == "الكل")

                    _dtUsers.DefaultView.RowFilter = "";

                else

                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cbFilter.Text.Trim(), cbIsManager.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }
    }
}
