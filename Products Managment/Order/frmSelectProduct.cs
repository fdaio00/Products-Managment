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

namespace Products_Managment.Order
{
    public partial class frmSelectProduct : Form
    {

        private DataTable _dtAllProducts; 

        public delegate void GetProductID(object sender, int ProductID);

        public GetProductID SendProductIDBack; 
        public frmSelectProduct()
        {
            InitializeComponent();
        }

        private void frmSelectProduct_Load(object sender, EventArgs e)
        {
            //_dtAllProducts = clsProduct.GetValidProducts();
            //dgvListProducts.DataSource = _dtAllProducts;
        }

        private void dgvListProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ProductID = (int)(long)dgvListProducts.CurrentRow.Cells[0].Value;

            SendProductIDBack?.Invoke(this, ProductID);
            this.Close();
        }
    }
}
