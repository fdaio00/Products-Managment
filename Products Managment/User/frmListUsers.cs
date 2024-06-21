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

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtUsers = clsUser.GetAllUsers();
            dgvListUsers.DataSource = _dtUsers; 
            if(dgvListUsers.Rows.Count>0)
            {
                dgvListUsers.Columns[1].HeaderText = "معرف المستخدم";
                dgvListUsers.Columns[2].HeaderText = "الاسم الكامل";
                dgvListUsers.Columns[3].HeaderText = "اسم المستخدم";
                dgvListUsers.Columns[4].HeaderText = "نوع المستخدم";
            }
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
    }
}
