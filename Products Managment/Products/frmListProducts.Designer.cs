namespace Products_Managment
{
    partial class frmListProducts
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListProducts = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnShowProductDetails = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnPrintAllProducts = new System.Windows.Forms.Button();
            this.btnPrintProduct = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveInExcle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProducts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "قم بادخال الكلمة المراد البحث عنها:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(357, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(418, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "لائحة المنتجات";
            // 
            // dgvListProducts
            // 
            this.dgvListProducts.AllowUserToAddRows = false;
            this.dgvListProducts.AllowUserToDeleteRows = false;
            this.dgvListProducts.AllowUserToOrderColumns = true;
            this.dgvListProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvListProducts.Location = new System.Drawing.Point(15, 104);
            this.dgvListProducts.Name = "dgvListProducts";
            this.dgvListProducts.ReadOnly = true;
            this.dgvListProducts.RowHeadersWidth = 51;
            this.dgvListProducts.RowTemplate.Height = 24;
            this.dgvListProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListProducts.Size = new System.Drawing.Size(1051, 341);
            this.dgvListProducts.TabIndex = 3;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProduct.Location = new System.Drawing.Point(859, 37);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(178, 32);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "إضافة منتج جديد ";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteProduct.Location = new System.Drawing.Point(648, 37);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(178, 32);
            this.btnDeleteProduct.TabIndex = 2;
            this.btnDeleteProduct.Text = "حذف المنتج المحدد";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnShowProductDetails
            // 
            this.btnShowProductDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowProductDetails.Location = new System.Drawing.Point(216, 37);
            this.btnShowProductDetails.Name = "btnShowProductDetails";
            this.btnShowProductDetails.Size = new System.Drawing.Size(178, 32);
            this.btnShowProductDetails.TabIndex = 4;
            this.btnShowProductDetails.Text = "عرض صورة المنتج ";
            this.btnShowProductDetails.UseVisualStyleBackColor = true;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditProduct.Location = new System.Drawing.Point(431, 37);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(178, 32);
            this.btnEditProduct.TabIndex = 3;
            this.btnEditProduct.Text = "تعديل بيانات المنتج المحدد";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnPrintAllProducts
            // 
            this.btnPrintAllProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintAllProducts.Location = new System.Drawing.Point(680, 97);
            this.btnPrintAllProducts.Name = "btnPrintAllProducts";
            this.btnPrintAllProducts.Size = new System.Drawing.Size(178, 32);
            this.btnPrintAllProducts.TabIndex = 6;
            this.btnPrintAllProducts.Text = "طباعة كل المنتجات";
            this.btnPrintAllProducts.UseVisualStyleBackColor = true;
            this.btnPrintAllProducts.Click += new System.EventHandler(this.btnPrintAllProducts_Click);
            // 
            // btnPrintProduct
            // 
            this.btnPrintProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintProduct.Location = new System.Drawing.Point(16, 37);
            this.btnPrintProduct.Name = "btnPrintProduct";
            this.btnPrintProduct.Size = new System.Drawing.Size(178, 32);
            this.btnPrintProduct.TabIndex = 5;
            this.btnPrintProduct.Text = "طباعة المنتج المحدد ";
            this.btnPrintProduct.UseVisualStyleBackColor = true;
            this.btnPrintProduct.Click += new System.EventHandler(this.btnPrintProduct_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(178, 97);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 32);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveInExcle
            // 
            this.btnSaveInExcle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveInExcle.Location = new System.Drawing.Point(392, 97);
            this.btnSaveInExcle.Name = "btnSaveInExcle";
            this.btnSaveInExcle.Size = new System.Drawing.Size(254, 32);
            this.btnSaveInExcle.TabIndex = 7;
            this.btnSaveInExcle.Text = "حفظ الائحة في ملف اكسل";
            this.btnSaveInExcle.UseVisualStyleBackColor = true;
            this.btnSaveInExcle.Click += new System.EventHandler(this.btnSaveInExcle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrintAllProducts);
            this.groupBox1.Controls.Add(this.btnAddProduct);
            this.groupBox1.Controls.Add(this.btnPrintProduct);
            this.groupBox1.Controls.Add(this.btnDeleteProduct);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnEditProduct);
            this.groupBox1.Controls.Add(this.btnSaveInExcle);
            this.groupBox1.Controls.Add(this.btnShowProductDetails);
            this.groupBox1.Location = new System.Drawing.Point(12, 469);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1054, 147);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "العمليات على اللائحة";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(795, 21);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(157, 24);
            this.cbFilter.TabIndex = 13;
            // 
            // frmListProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1078, 628);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.dgvListProducts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListProducts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة المنتجات";
            this.Load += new System.EventHandler(this.frmManageProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProducts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnShowProductDetails;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnPrintAllProducts;
        private System.Windows.Forms.Button btnPrintProduct;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveInExcle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbFilter;
    }
}