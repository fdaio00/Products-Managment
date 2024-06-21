namespace Products_Managment
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ملفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تسجيلالدخولToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.انشاءنسخةاحتياطيةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.استعادةنسخةمحفوظةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تسجلالخروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المنتجاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إضافةمنتججديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إدارةالمنتجاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.إدارةالأصنافToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.العملاءToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إضافةعميلجديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إدارةالعملاءToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.إضافةعمليةبيToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إدارةالمبيعاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المتسخدمينToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إضافةمستخدمجديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إدارةالمستخدمينToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ملفToolStripMenuItem,
            this.المنتجاتToolStripMenuItem,
            this.العملاءToolStripMenuItem,
            this.المتسخدمينToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ملفToolStripMenuItem
            // 
            this.ملفToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تسجيلالدخولToolStripMenuItem,
            this.انشاءنسخةاحتياطيةToolStripMenuItem,
            this.استعادةنسخةمحفوظةToolStripMenuItem,
            this.تسجلالخروجToolStripMenuItem});
            this.ملفToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.list;
            this.ملفToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ملفToolStripMenuItem.Name = "ملفToolStripMenuItem";
            this.ملفToolStripMenuItem.Size = new System.Drawing.Size(84, 36);
            this.ملفToolStripMenuItem.Text = "ملف";
            // 
            // تسجيلالدخولToolStripMenuItem
            // 
            this.تسجيلالدخولToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.administrator;
            this.تسجيلالدخولToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.تسجيلالدخولToolStripMenuItem.Name = "تسجيلالدخولToolStripMenuItem";
            this.تسجيلالدخولToolStripMenuItem.Size = new System.Drawing.Size(253, 38);
            this.تسجيلالدخولToolStripMenuItem.Text = "تسجيل الدخول";
            this.تسجيلالدخولToolStripMenuItem.Click += new System.EventHandler(this.تسجيلالدخولToolStripMenuItem_Click);
            // 
            // انشاءنسخةاحتياطيةToolStripMenuItem
            // 
            this.انشاءنسخةاحتياطيةToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.copy2;
            this.انشاءنسخةاحتياطيةToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.انشاءنسخةاحتياطيةToolStripMenuItem.Name = "انشاءنسخةاحتياطيةToolStripMenuItem";
            this.انشاءنسخةاحتياطيةToolStripMenuItem.Size = new System.Drawing.Size(253, 38);
            this.انشاءنسخةاحتياطيةToolStripMenuItem.Text = "انشاء نسخة احتياطية";
            // 
            // استعادةنسخةمحفوظةToolStripMenuItem
            // 
            this.استعادةنسخةمحفوظةToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.download2;
            this.استعادةنسخةمحفوظةToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.استعادةنسخةمحفوظةToolStripMenuItem.Name = "استعادةنسخةمحفوظةToolStripMenuItem";
            this.استعادةنسخةمحفوظةToolStripMenuItem.Size = new System.Drawing.Size(253, 38);
            this.استعادةنسخةمحفوظةToolStripMenuItem.Text = "استعادة نسخة محفوظة";
            // 
            // تسجلالخروجToolStripMenuItem
            // 
            this.تسجلالخروجToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.cancel1;
            this.تسجلالخروجToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.تسجلالخروجToolStripMenuItem.Name = "تسجلالخروجToolStripMenuItem";
            this.تسجلالخروجToolStripMenuItem.Size = new System.Drawing.Size(253, 38);
            this.تسجلالخروجToolStripMenuItem.Text = "تسجل الخروج ";
            this.تسجلالخروجToolStripMenuItem.Click += new System.EventHandler(this.تسجلالخروجToolStripMenuItem_Click);
            // 
            // المنتجاتToolStripMenuItem
            // 
            this.المنتجاتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةمنتججديدToolStripMenuItem,
            this.إدارةالمنتجاتToolStripMenuItem,
            this.toolStripSeparator1,
            this.إدارةالأصنافToolStripMenuItem});
            this.المنتجاتToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.dish;
            this.المنتجاتToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.المنتجاتToolStripMenuItem.Name = "المنتجاتToolStripMenuItem";
            this.المنتجاتToolStripMenuItem.Size = new System.Drawing.Size(110, 36);
            this.المنتجاتToolStripMenuItem.Text = "المنتجات";
            // 
            // إضافةمنتججديدToolStripMenuItem
            // 
            this.إضافةمنتججديدToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.add;
            this.إضافةمنتججديدToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.إضافةمنتججديدToolStripMenuItem.Name = "إضافةمنتججديدToolStripMenuItem";
            this.إضافةمنتججديدToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.إضافةمنتججديدToolStripMenuItem.Text = "إضافة منتج جديد";
            this.إضافةمنتججديدToolStripMenuItem.Click += new System.EventHandler(this.إضافةمنتججديدToolStripMenuItem_Click);
            // 
            // إدارةالمنتجاتToolStripMenuItem
            // 
            this.إدارةالمنتجاتToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.list1;
            this.إدارةالمنتجاتToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.إدارةالمنتجاتToolStripMenuItem.Name = "إدارةالمنتجاتToolStripMenuItem";
            this.إدارةالمنتجاتToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.إدارةالمنتجاتToolStripMenuItem.Text = "إدارة المنتجات";
            this.إدارةالمنتجاتToolStripMenuItem.Click += new System.EventHandler(this.إدارةالمنتجاتToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // إدارةالأصنافToolStripMenuItem
            // 
            this.إدارةالأصنافToolStripMenuItem.Name = "إدارةالأصنافToolStripMenuItem";
            this.إدارةالأصنافToolStripMenuItem.Size = new System.Drawing.Size(209, 38);
            this.إدارةالأصنافToolStripMenuItem.Text = "إدارة الأصناف";
            this.إدارةالأصنافToolStripMenuItem.Click += new System.EventHandler(this.إدارةالأصنافToolStripMenuItem_Click);
            // 
            // العملاءToolStripMenuItem
            // 
            this.العملاءToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةعميلجديدToolStripMenuItem,
            this.إدارةالعملاءToolStripMenuItem,
            this.toolStripMenuItem1,
            this.إضافةعمليةبيToolStripMenuItem,
            this.إدارةالمبيعاتToolStripMenuItem});
            this.العملاءToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.user;
            this.العملاءToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.العملاءToolStripMenuItem.Name = "العملاءToolStripMenuItem";
            this.العملاءToolStripMenuItem.Size = new System.Drawing.Size(97, 36);
            this.العملاءToolStripMenuItem.Text = "العملاء";
            // 
            // إضافةعميلجديدToolStripMenuItem
            // 
            this.إضافةعميلجديدToolStripMenuItem.Name = "إضافةعميلجديدToolStripMenuItem";
            this.إضافةعميلجديدToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.إضافةعميلجديدToolStripMenuItem.Text = "إضافة عميل جديد";
            // 
            // إدارةالعملاءToolStripMenuItem
            // 
            this.إدارةالعملاءToolStripMenuItem.Name = "إدارةالعملاءToolStripMenuItem";
            this.إدارةالعملاءToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.إدارةالعملاءToolStripMenuItem.Text = "إدارة العملاء";
            this.إدارةالعملاءToolStripMenuItem.Click += new System.EventHandler(this.إدارةالعملاءToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(233, 6);
            // 
            // إضافةعمليةبيToolStripMenuItem
            // 
            this.إضافةعمليةبيToolStripMenuItem.Name = "إضافةعمليةبيToolStripMenuItem";
            this.إضافةعمليةبيToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.إضافةعمليةبيToolStripMenuItem.Text = "إضافة عملية بيع جديدة";
            this.إضافةعمليةبيToolStripMenuItem.Click += new System.EventHandler(this.إضافةعمليةبيToolStripMenuItem_Click);
            // 
            // إدارةالمبيعاتToolStripMenuItem
            // 
            this.إدارةالمبيعاتToolStripMenuItem.Name = "إدارةالمبيعاتToolStripMenuItem";
            this.إدارةالمبيعاتToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.إدارةالمبيعاتToolStripMenuItem.Text = "إدارة المبيعات";
            this.إدارةالمبيعاتToolStripMenuItem.Click += new System.EventHandler(this.إدارةالمبيعاتToolStripMenuItem_Click);
            // 
            // المتسخدمينToolStripMenuItem
            // 
            this.المتسخدمينToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إضافةمستخدمجديدToolStripMenuItem,
            this.إدارةالمستخدمينToolStripMenuItem});
            this.المتسخدمينToolStripMenuItem.Image = global::Products_Managment.Properties.Resources.administrator1;
            this.المتسخدمينToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.المتسخدمينToolStripMenuItem.Name = "المتسخدمينToolStripMenuItem";
            this.المتسخدمينToolStripMenuItem.Size = new System.Drawing.Size(132, 36);
            this.المتسخدمينToolStripMenuItem.Text = "المتسخدمين";
            // 
            // إضافةمستخدمجديدToolStripMenuItem
            // 
            this.إضافةمستخدمجديدToolStripMenuItem.Name = "إضافةمستخدمجديدToolStripMenuItem";
            this.إضافةمستخدمجديدToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.إضافةمستخدمجديدToolStripMenuItem.Text = "إضافة مستخدم جديد";
            this.إضافةمستخدمجديدToolStripMenuItem.Click += new System.EventHandler(this.إضافةمستخدمجديدToolStripMenuItem_Click);
            // 
            // إدارةالمستخدمينToolStripMenuItem
            // 
            this.إدارةالمستخدمينToolStripMenuItem.Name = "إدارةالمستخدمينToolStripMenuItem";
            this.إدارةالمستخدمينToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.إدارةالمستخدمينToolStripMenuItem.Text = "إدارة المستخدمين";
            this.إدارةالمستخدمينToolStripMenuItem.Click += new System.EventHandler(this.إدارةالمستخدمينToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(703, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "المستخدم: ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.SystemColors.Window;
            this.lblName.Location = new System.Drawing.Point(765, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 16);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "hggg";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 274);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "برنامج إدارة المبيعات (نسخة تجريبية)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ملفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تسجيلالدخولToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem انشاءنسخةاحتياطيةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem استعادةنسخةمحفوظةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تسجلالخروجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem المنتجاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إضافةمنتججديدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إدارةالمنتجاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem إدارةالأصنافToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem العملاءToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إضافةعميلجديدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إدارةالعملاءToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem إضافةعمليةبيToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إدارةالمبيعاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إضافةمستخدمجديدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إدارةالمستخدمينToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.ToolStripMenuItem المتسخدمينToolStripMenuItem;
    }
}