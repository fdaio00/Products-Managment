namespace Products_Managment
{
    partial class frmAddEditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditProduct));
            this.gbAddEditProduct = new System.Windows.Forms.GroupBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lklRemoveImage = new System.Windows.Forms.LinkLabel();
            this.lklAddImage = new System.Windows.Forms.LinkLabel();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.cbProductCat = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbAddEditProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAddEditProduct
            // 
            resources.ApplyResources(this.gbAddEditProduct, "gbAddEditProduct");
            this.gbAddEditProduct.Controls.Add(this.btnCancle);
            this.gbAddEditProduct.Controls.Add(this.btnSave);
            this.gbAddEditProduct.Controls.Add(this.lklRemoveImage);
            this.gbAddEditProduct.Controls.Add(this.lklAddImage);
            this.gbAddEditProduct.Controls.Add(this.pbProductImage);
            this.gbAddEditProduct.Controls.Add(this.label7);
            this.gbAddEditProduct.Controls.Add(this.lblProductID);
            this.gbAddEditProduct.Controls.Add(this.cbProductCat);
            this.gbAddEditProduct.Controls.Add(this.txtPrice);
            this.gbAddEditProduct.Controls.Add(this.label4);
            this.gbAddEditProduct.Controls.Add(this.txtQuantity);
            this.gbAddEditProduct.Controls.Add(this.label5);
            this.gbAddEditProduct.Controls.Add(this.txtProductDescription);
            this.gbAddEditProduct.Controls.Add(this.label3);
            this.gbAddEditProduct.Controls.Add(this.label2);
            this.gbAddEditProduct.Controls.Add(this.label1);
            this.gbAddEditProduct.Name = "gbAddEditProduct";
            this.gbAddEditProduct.TabStop = false;
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancle, "btnCancle");
            this.btnCancle.Image = global::Products_Managment.Properties.Resources.cross;
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::Products_Managment.Properties.Resources.check_mark__2_;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lklRemoveImage
            // 
            resources.ApplyResources(this.lklRemoveImage, "lklRemoveImage");
            this.lklRemoveImage.Name = "lklRemoveImage";
            this.lklRemoveImage.TabStop = true;
            this.lklRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklRemoveImage_LinkClicked);
            // 
            // lklAddImage
            // 
            resources.ApplyResources(this.lklAddImage, "lklAddImage");
            this.lklAddImage.Name = "lklAddImage";
            this.lklAddImage.TabStop = true;
            this.lklAddImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklAddImage_LinkClicked);
            // 
            // pbProductImage
            // 
            this.pbProductImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pbProductImage, "pbProductImage");
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblProductID
            // 
            resources.ApplyResources(this.lblProductID, "lblProductID");
            this.lblProductID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductID.Name = "lblProductID";
            // 
            // cbProductCat
            // 
            this.cbProductCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductCat.FormattingEnabled = true;
            resources.ApplyResources(this.cbProductCat, "cbProductCat");
            this.cbProductCat.Name = "cbProductCat";
            // 
            // txtPrice
            // 
            resources.ApplyResources(this.txtPrice, "txtPrice");
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrice_Validating);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtQuantity
            // 
            resources.ApplyResources(this.txtQuantity, "txtQuantity");
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtProductDescription
            // 
            resources.ApplyResources(this.txtProductDescription, "txtProductDescription");
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateTextBox);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditProduct
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gbAddEditProduct);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditProduct";
            this.Load += new System.EventHandler(this.frmAddEditProduct_Load);
            this.gbAddEditProduct.ResumeLayout(false);
            this.gbAddEditProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddEditProduct;
        private System.Windows.Forms.LinkLabel lklRemoveImage;
        private System.Windows.Forms.LinkLabel lklAddImage;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.ComboBox cbProductCat;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}