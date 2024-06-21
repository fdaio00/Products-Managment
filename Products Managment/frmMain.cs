using Products_Managment.Categories;
using Products_Managment.Customers;
using Products_Managment.Order;
using Products_Managment.User;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Products_Managment
{
    public partial class frmMain : Form
    {

        private static frmMain _frm;

        static void frm_Closed(object sender, FormClosedEventArgs e)
        {
            _frm = null;
        }

        public static frmMain MainForm
        {
            get
            {
                if (_frm == null)
                {
                    _frm = new frmMain();
                    _frm.FormClosed += new FormClosedEventHandler(frm_Closed);
                }
                return _frm;
            }

        }

        public frmMain()
        {
            InitializeComponent();
            if (_frm == null)
                _frm = this;
            _DisableMenueStrip();
        }

        private void _DisableMenueStrip()
        {
            this.العملاءToolStripMenuItem.Enabled = false;
            this.المتسخدمينToolStripMenuItem.Enabled = false;
            this.المنتجاتToolStripMenuItem.Enabled = false;
            this.استعادةنسخةمحفوظةToolStripMenuItem.Enabled = false;
            this.انشاءنسخةاحتياطيةToolStripMenuItem.Enabled = false;
            this.تسجلالخروجToolStripMenuItem.Enabled = false;
        }

        public void EnableMenueStrip()
        {
            this.العملاءToolStripMenuItem.Enabled = true;
            this.المتسخدمينToolStripMenuItem.Enabled = true;
            this.المنتجاتToolStripMenuItem.Enabled = true;
            this.استعادةنسخةمحفوظةToolStripMenuItem.Enabled = true;
            this.انشاءنسخةاحتياطيةToolStripMenuItem.Enabled = true;
            this.تسجلالخروجToolStripMenuItem.Enabled = true;

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser == null)
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                if(clsGlobal.CurrentUser!=null)
                lblName.Text = clsGlobal.CurrentUser.Name;
            
                
            }
            else
            {
                if (clsGlobal.CurrentUser != null)
                    lblName.Text = clsGlobal.CurrentUser.Name;
            }
            
            
           
            
        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            frmMain_Load(null, null);
        }

        private void تسجلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد انك تريد تسجيل الخروج ؟", "تسجيل خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                clsGlobal.CurrentUser = null;
                _DisableMenueStrip();
                lblName.Text = "";


            }

            frmMain_Load(null, null);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void إضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditProduct frm = new frmAddEditProduct();
            frm.ShowDialog();
        }

        private void احمدابوطالبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("حياك يا أحمد");
        }

        private void عمرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Application;

            notifyIcon1.BalloonTipText = "حياك يا خال";
            notifyIcon1.BalloonTipTitle = "خالي عمر";
            notifyIcon1.ShowBalloonTip(1000);


        }

        private void إضافةصنفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void إدارةالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListProducts frm = new frmListProducts();
            frm.ShowDialog();
        }

        private void إدارةالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCategories frm = new frmListCategories();
            frm.ShowDialog();
        }

        private void إضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
        }

        private void إدارةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCustomers frm = new frmListCustomers();
            frm.ShowDialog(); 
           
            
        }

        private void إضافةعمليةبيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrders frm = new frmOrders();
            frm.ShowDialog(); 
        }

        private void إدارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderManagment frm = new frmOrderManagment();
            frm.ShowDialog(); 
        }

        private void إدارةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog(); 
        }

        private void انشاءنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void استعادةنسخةمحفوظةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRestoreDB frm = new frmRestoreDB();
            frm.ShowDialog(); 
        }
    }
}
