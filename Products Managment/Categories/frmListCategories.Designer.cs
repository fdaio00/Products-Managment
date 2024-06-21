namespace Products_Managment.Categories
{
    partial class frmListCategories
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListCategories = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveCatProductsInPDF = new System.Windows.Forms.Button();
            this.btnCurrentCat = new System.Windows.Forms.Button();
            this.btnPrintAllCat = new System.Windows.Forms.Button();
            this.btnSaveCatListInExcle = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCategories)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListCategories);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.btnFirst);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnLast);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1032, 335);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات الصنف";
            // 
            // dgvListCategories
            // 
            this.dgvListCategories.AllowUserToAddRows = false;
            this.dgvListCategories.AllowUserToDeleteRows = false;
            this.dgvListCategories.AllowUserToOrderColumns = true;
            this.dgvListCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCategories.Location = new System.Drawing.Point(16, 20);
            this.dgvListCategories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListCategories.Name = "dgvListCategories";
            this.dgvListCategories.ReadOnly = true;
            this.dgvListCategories.RowHeadersWidth = 62;
            this.dgvListCategories.RowTemplate.Height = 28;
            this.dgvListCategories.Size = new System.Drawing.Size(1000, 244);
            this.dgvListCategories.TabIndex = 9;
            this.dgvListCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListCategories_CellClick);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(477, 293);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(66, 16);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "وصف الصنف";
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(312, 287);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(67, 30);
            this.btnFirst.TabIndex = 6;
            this.btnFirst.Text = ">>||";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(396, 287);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(67, 30);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "|";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(571, 287);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(67, 30);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "<<";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(658, 287);
            this.btnLast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(67, 30);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = "||<<";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Location = new System.Drawing.Point(858, 36);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(145, 34);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "جديد ";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSaveCatProductsInPDF);
            this.groupBox2.Controls.Add(this.btnCurrentCat);
            this.groupBox2.Controls.Add(this.btnPrintAllCat);
            this.groupBox2.Controls.Add(this.btnSaveCatListInExcle);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Location = new System.Drawing.Point(11, 349);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1032, 151);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "العمليات المتاحة";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(172, 92);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(145, 34);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "خروج ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button13_Click);
            // 
            // btnSaveCatProductsInPDF
            // 
            this.btnSaveCatProductsInPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveCatProductsInPDF.Location = new System.Drawing.Point(367, 92);
            this.btnSaveCatProductsInPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveCatProductsInPDF.Name = "btnSaveCatProductsInPDF";
            this.btnSaveCatProductsInPDF.Size = new System.Drawing.Size(222, 34);
            this.btnSaveCatProductsInPDF.TabIndex = 8;
            this.btnSaveCatProductsInPDF.Text = "حفظ الصنف الحالي بمنتجاته في ملف pdf ";
            this.btnSaveCatProductsInPDF.UseVisualStyleBackColor = true;
            // 
            // btnCurrentCat
            // 
            this.btnCurrentCat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCurrentCat.Location = new System.Drawing.Point(16, 36);
            this.btnCurrentCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCurrentCat.Name = "btnCurrentCat";
            this.btnCurrentCat.Size = new System.Drawing.Size(172, 34);
            this.btnCurrentCat.TabIndex = 7;
            this.btnCurrentCat.Text = "طباعة الصنف الحالي ";
            this.btnCurrentCat.UseVisualStyleBackColor = true;
            this.btnCurrentCat.Click += new System.EventHandler(this.btnCurrentCat_Click);
            // 
            // btnPrintAllCat
            // 
            this.btnPrintAllCat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintAllCat.Location = new System.Drawing.Point(225, 36);
            this.btnPrintAllCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintAllCat.Name = "btnPrintAllCat";
            this.btnPrintAllCat.Size = new System.Drawing.Size(176, 34);
            this.btnPrintAllCat.TabIndex = 6;
            this.btnPrintAllCat.Text = "طباعة كل الأصناف";
            this.btnPrintAllCat.UseVisualStyleBackColor = true;
            this.btnPrintAllCat.Click += new System.EventHandler(this.btnPrintAllCat_Click);
            // 
            // btnSaveCatListInExcle
            // 
            this.btnSaveCatListInExcle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveCatListInExcle.Location = new System.Drawing.Point(638, 92);
            this.btnSaveCatListInExcle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveCatListInExcle.Name = "btnSaveCatListInExcle";
            this.btnSaveCatListInExcle.Size = new System.Drawing.Size(245, 34);
            this.btnSaveCatListInExcle.TabIndex = 5;
            this.btnSaveCatListInExcle.Text = "حفظ لائحة الأصناف في ملف Excle ";
            this.btnSaveCatListInExcle.UseVisualStyleBackColor = true;
            this.btnSaveCatListInExcle.Click += new System.EventHandler(this.btnSaveCatListInPDF_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Location = new System.Drawing.Point(664, 36);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(145, 34);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(444, 36);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 34);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "حذف ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmListCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListCategories";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة الأصناف";
            this.Load += new System.EventHandler(this.frmListCategories_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCategories)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveCatProductsInPDF;
        private System.Windows.Forms.Button btnCurrentCat;
        private System.Windows.Forms.Button btnPrintAllCat;
        private System.Windows.Forms.Button btnSaveCatListInExcle;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvListCategories;
    }
}