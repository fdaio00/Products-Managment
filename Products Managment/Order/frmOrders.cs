using Product_Managment_BusniessLayer;
using Products_Managment.OrderDetails;
using Products_Managment.OrderDetails.Reports;
using Products_Managment.Properties;
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
    public partial class frmOrders : Form
    {
        DataTable _dtListOrders = new DataTable();


        clsOrder _Order; 
        int _CustomerID;
        int _ProductID;
        clsCustomer _Customer; 
        clsProduct _Product; 
       
        public frmOrders()
        {
            InitializeComponent();
            
        }
           
        private void _CreateDataTable()
        {
            _dtListOrders.Columns.Add("معرف المنتج");
            _dtListOrders.Columns.Add("اسم المنتج");
            _dtListOrders.Columns.Add("الثمن");
            _dtListOrders.Columns.Add("الكمية");
            _dtListOrders.Columns.Add("السعر");
            _dtListOrders.Columns.Add("الخصم");
            _dtListOrders.Columns.Add("الاجمالي");
            dgvOrders.DataSource = _dtListOrders; 
            RizeRowsInDataGridView(); 
        }
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {


            if(!this.ValidateChildren())
            {
                return; 

            }

            if(_Customer==null)
            {
                MessageBox.Show("يحب عليك اختيار عميل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; 
            }

            if(dgvOrders.Rows.Count<2)
            {
                MessageBox.Show("يجب عليك ادخال منتج واحد على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            _Order.OrderID = Convert.ToInt32(txtOrderID.Text);
            _Order.OrderDescription = txtOrderDescription.Text.Trim();
            _Order.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Order.OrderDate = dtpOrderDate.Value;
            _Order.CustomerID = _Customer.CustomerID; 


           if(!_Order.Save())
            {
                MessageBox.Show("لم يتم الحفظ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

           else
            {

                for (int i = 0; i < dgvOrders.Rows.Count - 1; i++)
                {

                    clsOrderDetail orderDetail = new clsOrderDetail();

                    orderDetail.ProductID = Convert.ToInt32( dgvOrders.Rows[i].Cells[0].Value);
                    orderDetail.OrderID    = _Order.OrderID;
                    orderDetail.Price      = Convert.ToSingle(dgvOrders.Rows[i].Cells[2].Value);
                    orderDetail.Quantity   = Convert.ToInt32(dgvOrders.Rows[i].Cells[3].Value);
                    orderDetail.Sum        = Convert.ToSingle(dgvOrders.Rows[i].Cells[4].Value);
                    orderDetail.Discount   = Convert.ToSingle(dgvOrders.Rows[i].Cells[5].Value);
                    orderDetail.Total      = Convert.ToSingle(dgvOrders.Rows[i].Cells[6].Value);
                    if(!orderDetail.Save())
                    {
                        MessageBox.Show($" جدث خطا ما في حفظ المنتج رقم :  {Convert.ToInt32(dgvOrders.Rows[i].Cells[0].Value)}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }

                }

                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPrintOrder.Enabled = true;
                btnSelectCustomer.Enabled = false;
                btnSelectProduct.Enabled = false;
                btnSaveOrder.Enabled = false;
                btnNewOrder.Enabled = true; 

            }


        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            _dtListOrders.Clear();
            dgvOrders.Refresh();
            _CalculateFinalTotal();
            txtOrderID.Text = clsOrder.GetNewOrderNumber().ToString();
            txtOrderDescription.Text = $"فاتورة رقم {txtOrderID.Text}";
            txtCreatedByUserID.Text = clsGlobal.CurrentUser.Name;
            btnNewOrder.Enabled = false;
            btnSaveOrder.Enabled = true;
            btnSelectProduct.Enabled = true;
            btnSelectCustomer.Enabled = true;
            _Order = new clsOrder();
        }
          void _LaodCustomerInfo()
        {
            txtCustomerID.Text = _Customer.CustomerID.ToString(); 
            txtEmail.Text = _Customer.Email.ToString(); 
            txtPhone.Text = _Customer.Phone.ToString(); 
            txtFirstName.Text = _Customer.FirstName.ToString(); 
            txtLastName.Text = _Customer.LastName.ToString();
            if (_Customer.ImagePath != "")
                pbCustomerImage.Load(_Customer.ImagePath);
            else
                pbCustomerImage.Image = Resources.Male_512;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            frmSelectCustomer frm = new frmSelectCustomer();
            frm.SendCustomerBack += SendCustomerBack;
            frm.ShowDialog(); 
        }

        private void SendCustomerBack(object sender , int CustomerID)
        {
            _CustomerID = CustomerID;   
            _Customer = clsCustomer.FindCustomerByCustomerID(CustomerID);

            _LaodCustomerInfo(); 
        }


        private void RizeRowsInDataGridView()
        {
            //dgvOrders.RowHeadersWidth = 75;
            //dgvOrders.Columns[0].Width = 140;
            //dgvOrders.Columns[1].Width = 296;
            //dgvOrders.Columns[2].Width = 127;
            //dgvOrders.Columns[3].Width = 130;
            //dgvOrders.Columns[4].Width = 103;
            //dgvOrders.Columns[5].Width = 170;
            //dgvOrders.Columns[6].Width = 168;




            dgvOrders.RowHeadersWidth = 80;
            dgvOrders.Columns[0].Width = 127;
            dgvOrders.Columns[1].Width = 276;
            dgvOrders.Columns[2].Width = 112;
            dgvOrders.Columns[3].Width = 115;
            dgvOrders.Columns[4].Width = 88;
            dgvOrders.Columns[5].Width = 130;
            dgvOrders.Columns[6].Width = 158;
        }
        private void frmOrders_Load(object sender, EventArgs e)
        {
            pbCustomerImage.Image = Resources.Male_512;
            _CreateDataTable(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            repPrintOrderDetails MyReport = new repPrintOrderDetails();
            frmPrintOrderDetails frm = new frmPrintOrderDetails();
            MyReport.SetParameterValue("@OrderID", _Order.OrderID);
            frm.crystalReportViewer1.ReportSource = MyReport;
            frm.ShowDialog();
        }

        private void _CalculatePrice()
        {
            double Discout = 0;
            double TotalAfterDiscount = 0;
            int Quantity = 0;
            double Sum = 0;
            double Price = 0; 
            if (txtPrice.Text!="")
              Price= Convert.ToDouble(txtPrice.Text);
            if (txtTotalAfterDiscount.Text != "")
                 TotalAfterDiscount = Convert.ToDouble(txtTotalAfterDiscount.Text);
            if (txtQuantity.Text != "")
             Quantity= Convert.ToInt32(txtQuantity.Text);
            if (txtDiscount.Text != "")
                Discout = Convert.ToDouble(txtDiscount.Text.Trim());


            Sum = Price * Quantity;
            txtSum.Text = Sum.ToString();

            TotalAfterDiscount = (Sum - (Sum * (Discout / 100)));

            txtTotalAfterDiscount.Text = TotalAfterDiscount.ToString(); 
           
        }
        private void btnChooceProduct_Click(object sender, EventArgs e)
        {
            _Clear(); 
            frmSelectProduct frm = new frmSelectProduct();
            frm.SendProductIDBack += SendProductBack;
            frm.ShowDialog();
            txtQuantity.Focus();
            txtDiscount.Text = "0"; 
            txtSum.Clear(); 
            txtTotalAfterDiscount.Clear();
            DataRow row = _dtListOrders.NewRow();



            txtQuantity.Text = "1";
            row[0] = txtProductID.Text;
            row[1] = txtProductName.Text;
            row[2] = txtPrice.Text;
            row[3] = txtQuantity.Text;
            row[4] = txtSum.Text;
            row[5] = txtDiscount.Text;
            row[6] = txtTotalAfterDiscount.Text;

            _dtListOrders.Rows.Add(row);
            _Clear();
            _CalculateFinalTotal();
            btnSelectProduct.Focus();

        }


        private void SendProductBack(object sender , int ProductID)
        {
            _ProductID = ProductID;

            _LoadProductInfo(); 
        }

        private void _Clear()
        {

            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtSum.Clear();
            txtDiscount.Clear();
            txtTotalAfterDiscount.Clear();
           
        }

        private void _LoadProductInfo()
        {
            _Product = clsProduct.FindProductByID(_ProductID);

            txtProductID.Text = _Product.ProductID.ToString(); 
            txtProductName.Text = _Product.ProductName.ToString(); 
            txtPrice.Text = _Product.Price.ToString();
            txtDiscount.Text = "0";
            txtQuantity.Focus();
            
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {

            
            if (e.KeyCode ==  Keys.Enter)
            {

                int QuantityLeft = clsProduct.GetProductQuantity(Convert.ToInt32(txtProductID.Text));
                if (Convert.ToInt32(txtQuantity.Text) > QuantityLeft)
                {
                    MessageBox.Show($"الكمية المطلوبة أكبر من الكمية المتاحة \nالكمية المتاحة هي {QuantityLeft}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantity.Focus();
                    return;
                }
                txtDiscount.Focus(); 
            }

            
           
            //_CalculatePrice();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {

        }




        //private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
            
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar == (char)13)
            //    e.Handled = true;
            //if (e.KeyChar == (char)13)
            //    e.Handled = true; 
        //    //if()
        //    //{
        //    //    DataRow row = _dtListOrders.NewRow();
        //    //    row[0] = txtProductID.Text;
        //    //    row[1] = txtProductName.Text;
        //    //    row[2] = txtPrice.Text;
        //    //    row[3] = txtQuantity.Text;
        //    //    row[4] = txtSum.Text;
        //    //    row[5] = txtDiscount.Text;
        //    //    row[6] = txtTotalAfterDiscount.Text;

        //    //    _dtListOrders.Rows.Add(row);
        //    //    _Clear();
        //    //}
        //}

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            _CalculatePrice();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            _CalculatePrice(); 
        }

        private void _CalculateFinalTotal()
        {

            txtTotal.Text = (from DataGridViewRow row in dgvOrders.Rows
                             where row.Cells[6].FormattedValue.ToString() != String.Empty
                             select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString(); 
           
            
        }

        private void txtDiscount_KeyDown_1(object sender, KeyEventArgs e)
        
        {
            if (e.KeyCode == Keys.Enter)
            {


                for(int i =0; i < dgvOrders.Rows.Count-1; i++)
                {
                    if (dgvOrders.Rows[i].Cells[0].Value.ToString() == txtProductID.Text)
                    {
                        MessageBox.Show("هذا المنتج قد تم ادخاله بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return; 
                    }
                }

                
                DataRow row = _dtListOrders.NewRow();
                row[0] = txtProductID.Text;
                row[1] = txtProductName.Text;
                row[2] = txtPrice.Text;
                row[3] = txtQuantity.Text;
                row[4] = txtSum.Text;
                row[5] = txtDiscount.Text;
                row[6] = txtTotalAfterDiscount.Text;

                _dtListOrders.Rows.Add(row);
                _Clear();
                _CalculateFinalTotal(); 
                btnSelectProduct.Focus();
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = dgvOrders.CurrentRow.Cells[0].Value.ToString(); 
            txtProductName.Text = dgvOrders.CurrentRow.Cells[1].Value.ToString(); 
            txtPrice .Text = dgvOrders.CurrentRow.Cells[2].Value.ToString(); 
            txtQuantity.Text = dgvOrders.CurrentRow.Cells[3].Value.ToString(); 
            txtSum.Text = dgvOrders.CurrentRow.Cells[4].Value.ToString(); 
            txtDiscount.Text = dgvOrders.CurrentRow.Cells[5].Value.ToString(); 
            txtTotalAfterDiscount.Text = dgvOrders.CurrentRow.Cells[6].Value.ToString();

            dgvOrders.Rows.RemoveAt(dgvOrders.CurrentRow.Index);
            txtQuantity.Focus();
            _CalculateFinalTotal(); 
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtProductID.Text = dgvOrders.CurrentRow.Cells[0].Value.ToString();
            txtProductName.Text = dgvOrders.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dgvOrders.CurrentRow.Cells[2].Value.ToString();
            txtQuantity.Text = dgvOrders.CurrentRow.Cells[3].Value.ToString();
            txtSum.Text = dgvOrders.CurrentRow.Cells[4].Value.ToString();
            txtDiscount.Text = dgvOrders.CurrentRow.Cells[5].Value.ToString();
            txtTotalAfterDiscount.Text = dgvOrders.CurrentRow.Cells[6].Value.ToString();

            dgvOrders.Rows.RemoveAt(dgvOrders.CurrentRow.Index);
            txtQuantity.Focus();
            _CalculateFinalTotal();
        }

        private void حذفالسطرالمحددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvOrders.Rows.RemoveAt(dgvOrders.CurrentRow.Index);
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtListOrders.Clear();
            dgvOrders.Refresh();
            _CalculateFinalTotal(); 
        }

        private void dgvOrders_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            _CalculateFinalTotal(); 
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)13)
                e.Handled = true;
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == (char)13)
                e.Handled = true;
        }
    }
}
