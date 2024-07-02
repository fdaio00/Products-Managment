using Product_Managment_BusniessLayer;
using Products_Managment.GlobalClasses;
using System;
using System.Windows.Forms;


namespace Products_Managment
{
    public partial class frmLogin : Form
    {



        public frmLogin()
        {
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string Password = "";
            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                ckbRemeberPassword.Checked = true;
            }
            else
            {

                ckbRemeberPassword.Checked = false;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            //clsUser LoggedUser = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), clsUtil.Encrypt(txtPassword.Text.Trim()));
            clsUser LoggedUser = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), (txtPassword.Text.Trim()));

            if (LoggedUser != null)
            {

                

                if (ckbRemeberPassword.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }

                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");

                }

                clsGlobal.CurrentUser = LoggedUser;
                MessageBox.Show("تم تسجيل الدخول بنجاح");

                frmMain.MainForm.EnableMenueStrip();
                if (clsGlobal.CurrentUser.IsManager)
                    frmMain.MainForm.المتسخدمينToolStripMenuItem.Visible = true;
                else
                    frmMain.MainForm.المتسخدمينToolStripMenuItem.Visible = false;



                this.Close();

            }

            else
            {
                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "غير صحيح ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
        }
    }
}
