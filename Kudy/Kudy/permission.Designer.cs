namespace Kudy
{
    partial class permission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(permission));
            this.dataGridView_show_permission = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_paw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_customerSysPermission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_boss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回管理頁面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show_permission)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_show_permission
            // 
            this.dataGridView_show_permission.AllowUserToAddRows = false;
            this.dataGridView_show_permission.AllowUserToDeleteRows = false;
            this.dataGridView_show_permission.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_show_permission.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_show_permission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_show_permission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_account,
            this.Column_paw,
            this.Column_customerSysPermission,
            this.Column_boss});
            this.dataGridView_show_permission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_show_permission.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_show_permission.Name = "dataGridView_show_permission";
            this.dataGridView_show_permission.RowTemplate.Height = 38;
            this.dataGridView_show_permission.Size = new System.Drawing.Size(1723, 970);
            this.dataGridView_show_permission.TabIndex = 0;
            this.dataGridView_show_permission.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_show_permission_CellClick);
            this.dataGridView_show_permission.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_show_permission_CellContentClick);
            this.dataGridView_show_permission.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_show_permission_CellEndEdit);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1745, 47);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1745, 1023);
            this.panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1144, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(579, 354);
            this.textBox1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1745, 1023);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_show_permission);
            this.tabPage1.Font = new System.Drawing.Font("新細明體", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1729, 976);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "帳號密碼管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1729, 923);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "授予管理權限";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Column_name
            // 
            this.Column_name.HeaderText = "員工姓名";
            this.Column_name.Name = "Column_name";
            this.Column_name.ReadOnly = true;
            // 
            // Column_account
            // 
            this.Column_account.HeaderText = "帳號";
            this.Column_account.Name = "Column_account";
            this.Column_account.ReadOnly = true;
            // 
            // Column_paw
            // 
            this.Column_paw.HeaderText = "密碼";
            this.Column_paw.Name = "Column_paw";
            // 
            // Column_customerSysPermission
            // 
            this.Column_customerSysPermission.HeaderText = "顧客系統新增權限";
            this.Column_customerSysPermission.Name = "Column_customerSysPermission";
            this.Column_customerSysPermission.ReadOnly = true;
            // 
            // Column_boss
            // 
            this.Column_boss.HeaderText = "授予管理(boss)權限";
            this.Column_boss.Name = "Column_boss";
            this.Column_boss.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem,
            this.返回管理頁面ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1745, 47);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(73, 38);
            this.說明ToolStripMenuItem.Text = "說明";
            this.說明ToolStripMenuItem.Click += new System.EventHandler(this.說明ToolStripMenuItem_Click);
            // 
            // 返回管理頁面ToolStripMenuItem
            // 
            this.返回管理頁面ToolStripMenuItem.Name = "返回管理頁面ToolStripMenuItem";
            this.返回管理頁面ToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.返回管理頁面ToolStripMenuItem.Text = "返回管理頁面";
            this.返回管理頁面ToolStripMenuItem.Click += new System.EventHandler(this.返回管理頁面ToolStripMenuItem_Click);
            // 
            // permission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 1070);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "permission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "premission";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show_permission)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_show_permission;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_account;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_paw;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_customerSysPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_boss;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 返回管理頁面ToolStripMenuItem;
    }
}