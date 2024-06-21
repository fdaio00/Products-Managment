namespace Products_Managment.Order
{
    partial class frmSelectCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListCustomers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListCustomers
            // 
            this.dgvListCustomers.AllowUserToAddRows = false;
            this.dgvListCustomers.AllowUserToDeleteRows = false;
            this.dgvListCustomers.AllowUserToOrderColumns = true;
            this.dgvListCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCustomers.Location = new System.Drawing.Point(12, 93);
            this.dgvListCustomers.Name = "dgvListCustomers";
            this.dgvListCustomers.ReadOnly = true;
            this.dgvListCustomers.RowHeadersWidth = 51;
            this.dgvListCustomers.RowTemplate.Height = 24;
            this.dgvListCustomers.Size = new System.Drawing.Size(768, 478);
            this.dgvListCustomers.TabIndex = 0;
            this.dgvListCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListCustomers_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "قم بالضغط مرتين لاختيار العميل : ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(299, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(339, 22);
            this.txtSearch.TabIndex = 25;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "البحث بالاسم : ";
            // 
            // frmSelectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(791, 587);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListCustomers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectCustomer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اختيار عميل";
            this.Load += new System.EventHandler(this.frmSelectCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
    }
}