namespace Products_Managment.Categories
{
    partial class frmAddEditCat
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
            this.components = new System.ComponentModel.Container();
            this.gbAddEditCat = new System.Windows.Forms.GroupBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCatDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbAddEditCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAddEditCat
            // 
            this.gbAddEditCat.Controls.Add(this.btnCancle);
            this.gbAddEditCat.Controls.Add(this.btnSave);
            this.gbAddEditCat.Controls.Add(this.txtCatDescription);
            this.gbAddEditCat.Controls.Add(this.label1);
            this.gbAddEditCat.Location = new System.Drawing.Point(19, 12);
            this.gbAddEditCat.Name = "gbAddEditCat";
            this.gbAddEditCat.Size = new System.Drawing.Size(460, 202);
            this.gbAddEditCat.TabIndex = 2;
            this.gbAddEditCat.TabStop = false;
            this.gbAddEditCat.Text = "groupBox1";
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancle.Image = global::Products_Managment.Properties.Resources.cross;
            this.btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancle.Location = new System.Drawing.Point(104, 124);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(89, 46);
            this.btnCancle.TabIndex = 9;
            this.btnCancle.Text = "الغاء";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::Products_Managment.Properties.Resources.check_mark__2_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(225, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 46);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCatDescription
            // 
            this.txtCatDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCatDescription.Location = new System.Drawing.Point(47, 37);
            this.txtCatDescription.Multiline = true;
            this.txtCatDescription.Name = "txtCatDescription";
            this.txtCatDescription.Size = new System.Drawing.Size(296, 62);
            this.txtCatDescription.TabIndex = 3;
            this.txtCatDescription.Leave += new System.EventHandler(this.txtCatDescription_Leave);
            this.txtCatDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtCatDescription_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "وصف الصنف";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditCat
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(491, 233);
            this.Controls.Add(this.gbAddEditCat);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditCat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة صنف جديد ";
            this.Load += new System.EventHandler(this.frmAddCat_Load);
            this.gbAddEditCat.ResumeLayout(false);
            this.gbAddEditCat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddEditCat;
        private System.Windows.Forms.TextBox txtCatDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}