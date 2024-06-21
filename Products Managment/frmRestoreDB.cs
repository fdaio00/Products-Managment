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

namespace Products_Managment
{
    public partial class frmRestoreDB : Form
    {

        string _FilePath;
        public frmRestoreDB()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                _FilePath = openFileDialog1.FileName;
                btnRestore.Enabled = true; 
                txtPath.Text = _FilePath;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != null)
            {
                if (clsDBSetteings.RestoreDatabase(_FilePath))
                {
                    MessageBox.Show("تم استعادة قاعدة البيانات بنجاح", "تمت الاستعادة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("حدث خطا ما", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            else
            {
                MessageBox.Show("يجب عليك ادخال مسار قاعدة البانات المراد نسخها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnChoose.Focus();
            
            }
        }
    }
}
