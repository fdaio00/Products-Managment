using Product_Managment_BusniessLayer;
using Products_Managment.OrderDetails;
using Products_Managment.OrderDetails.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Managment.Order
{
    public partial class frmOrderManagment : Form
    {

        private DataTable _dtListOrders; 
        public frmOrderManagment()
        {
            InitializeComponent();
        }

        private void frmOrderManagment_Load(object sender, EventArgs e)
        {
            _dtListOrders = clsOrder.GetAllOrders();
            dgvListOrders.DataSource = _dtListOrders; 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int OrderID = Convert.ToInt32(dgvListOrders.CurrentRow.Cells[0].Value);
            repPrintOrderDetails rep = new repPrintOrderDetails(); 
            frmPrintOrderDetails frm = new frmPrintOrderDetails();
            rep.SetParameterValue("@OrderID", OrderID);
            frm.crystalReportViewer1.ReportSource = rep;
            frm.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
