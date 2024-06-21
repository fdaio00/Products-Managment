using System;
using System.Data;
using System.Windows.Forms;

namespace Products_Managment.Order
{
    public partial class frmSelectCustomer : Form
    {
        private DataTable _dtCustomers; 
        public delegate void SendCustomerID(object sender, int CustomerID);

        public SendCustomerID SendCustomerBack; 
        public frmSelectCustomer()
        {
            InitializeComponent();
        }

       
        private void frmSelectCustomer_Load(object sender, EventArgs e)
        {

            
            _dtCustomers = clsCustomer.GetAllCustomers();
            dgvListCustomers.DataSource = _dtCustomers;
            txtSearch.Focus();
            if (dgvListCustomers.Rows.Count > 0)
            {
               

                dgvListCustomers.Columns[0].Visible = false;
                dgvListCustomers.Columns[1].Visible = false;
                dgvListCustomers.Columns[2].Visible = false;
                dgvListCustomers.Columns[6].Visible = false;


                dgvListCustomers.Columns[3].HeaderText = "الاسم الكامل";
                dgvListCustomers.Columns[4].HeaderText = "البريد الاكتروني";
                dgvListCustomers.Columns[5].HeaderText = "رقم الهاتف";
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

     
        private void dgvListCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int CustomerID = (int)dgvListCustomers.CurrentRow.Cells[0].Value;

            SendCustomerBack?.Invoke(this, CustomerID);
            this.Close();
        }
    }
}
