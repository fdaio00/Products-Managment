using Product_Managment_BusniessLayer;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Products_Managment.User
{
    public partial class frmAddEditUser : Form
    {

        int ?_UserID  = -1;

        enum enMode { AddNew= 0 , Update = 1 };
        private enMode _Mode = enMode.Update; 
        clsUser _User;
        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew; 
            _User = new clsUser();

        }
          public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("يجب عليك ملء جميع الخانات المطلوبة", "تعذر الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            _User.Password = txtPassword.Text.Trim();
            _User.UserName = txtUserName.Text.Trim();
            _User.IsManager =(cbIsManager.SelectedIndex == 1);
            _User.Name = txtName.Text.Trim(); 

            if (_User.Save())
            {
                MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show("فشل الحفظ", "لم يتم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void _GetThemAll()
        {

        }

        void _LoadUserInfo()
        {
            _User = clsUser.FindUserByUserID(_UserID);
            if(_User == null)
            {
                MessageBox.Show("لم يتم ايجاد المتسخدم المحدد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return; 
            }

            txtName.Text = _User.Name;
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfitmPassword.Text = _User.Password;
            if(_User.IsManager)
            {
                cbIsManager.SelectedIndex = 1;
            }
            else
            {
                cbIsManager.SelectedIndex =0;

            }
        }
        private void textBox_Validating(object sender , CancelEventArgs e )
        {
            TextBox temp = (TextBox)sender; 
            if(string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "يجب عليك ملء هذه الخانة");

            }
            else
                errorProvider1.SetError(temp, null);

        }
       void _ResetDefaultValues()
        {
            if(_Mode == enMode.AddNew)
            {
                this.Text = "اضافة مستخدم جديد";
                btnSave.Text = "اضافة";
            }

            else
            {
                this.Text = "تعديل مستخدم ";
                btnSave.Text = "تعديل";
            }

            txtUserName.Clear();
            txtName.Clear();
            txtPassword.Clear();
            txtConfitmPassword.Clear();
            cbIsManager.SelectedIndex =0 ;

        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadUserInfo();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "يجب عليك ملء هذه الخانة");

            }
            else if(clsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "يوجد بالفعل مستخدم بهذا الاسم");

            }
            else
                errorProvider1.SetError(txtUserName, null);

        }
    }
}
