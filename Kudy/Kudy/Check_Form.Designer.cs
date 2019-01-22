namespace Kudy
{
    partial class Check_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Check_Form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.權限管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.備份資料庫ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.輸出當月員工時數表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_check = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_check = new System.Windows.Forms.DataGridView();
            this.Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_onduty_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ondutytime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1_offdutytime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage_lose_puch = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label_year = new System.Windows.Forms.Label();
            this.checkBox_check_all = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.checkBox_last_year = new System.Windows.Forms.CheckBox();
            this.comboBox_Employee = new System.Windows.Forms.ComboBox();
            this.tabPage_insert_work = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Off_Min = new System.Windows.Forms.TextBox();
            this.textBox_Off_Hour = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_On_Min = new System.Windows.Forms.TextBox();
            this.textBox_On_Hour = new System.Windows.Forms.TextBox();
            this.dateTimePicker_lose_punch = new System.Windows.Forms.DateTimePicker();
            this.button_new_punch = new System.Windows.Forms.Button();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_check.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_check)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage_lose_puch.SuspendLayout();
            this.tabPage_insert_work.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("細明體-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.權限管理ToolStripMenuItem,
            this.備份資料庫ToolStripMenuItem,
            this.輸出當月員工時數表ToolStripMenuItem,
            this.說明ToolStripMenuItem,
            this.離開ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2334, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 權限管理ToolStripMenuItem
            // 
            this.權限管理ToolStripMenuItem.Name = "權限管理ToolStripMenuItem";
            this.權限管理ToolStripMenuItem.Size = new System.Drawing.Size(118, 38);
            this.權限管理ToolStripMenuItem.Text = "權限管理";
            this.權限管理ToolStripMenuItem.Click += new System.EventHandler(this.權限管理ToolStripMenuItem_Click);
            // 
            // 備份資料庫ToolStripMenuItem
            // 
            this.備份資料庫ToolStripMenuItem.Enabled = false;
            this.備份資料庫ToolStripMenuItem.Name = "備份資料庫ToolStripMenuItem";
            this.備份資料庫ToolStripMenuItem.Size = new System.Drawing.Size(142, 38);
            this.備份資料庫ToolStripMenuItem.Text = "備份資料庫";
            // 
            // 輸出當月員工時數表ToolStripMenuItem
            // 
            this.輸出當月員工時數表ToolStripMenuItem.Font = new System.Drawing.Font("細明體-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.輸出當月員工時數表ToolStripMenuItem.Name = "輸出當月員工時數表ToolStripMenuItem";
            this.輸出當月員工時數表ToolStripMenuItem.Size = new System.Drawing.Size(262, 38);
            this.輸出當月員工時數表ToolStripMenuItem.Text = "輸出上個月班表(全體)";
            this.輸出當月員工時數表ToolStripMenuItem.Click += new System.EventHandler(this.輸出當月員工時數表ToolStripMenuItem_Click);
            // 
            // 離開ToolStripMenuItem
            // 
            this.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
            this.離開ToolStripMenuItem.Size = new System.Drawing.Size(70, 38);
            this.離開ToolStripMenuItem.Text = "離開";
            this.離開ToolStripMenuItem.Click += new System.EventHandler(this.離開ToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2334, 1382);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_check);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2334, 1382);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage_check
            // 
            this.tabPage_check.Controls.Add(this.panel2);
            this.tabPage_check.Controls.Add(this.panel3);
            this.tabPage_check.Location = new System.Drawing.Point(8, 54);
            this.tabPage_check.Name = "tabPage_check";
            this.tabPage_check.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_check.Size = new System.Drawing.Size(2318, 1320);
            this.tabPage_check.TabIndex = 0;
            this.tabPage_check.Text = "管理";
            this.tabPage_check.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_check);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(622, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1693, 1314);
            this.panel2.TabIndex = 7;
            // 
            // dataGridView_check
            // 
            this.dataGridView_check.AllowUserToAddRows = false;
            this.dataGridView_check.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_check.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_check.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_check.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_name,
            this.Column_onduty_date,
            this.Column_ondutytime,
            this.Column1_offdutytime,
            this.Column_total,
            this.Column_check,
            this.Column_remark});
            this.dataGridView_check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_check.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_check.Name = "dataGridView_check";
            this.dataGridView_check.RowTemplate.Height = 38;
            this.dataGridView_check.Size = new System.Drawing.Size(1693, 1314);
            this.dataGridView_check.TabIndex = 0;
            this.dataGridView_check.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_check_CellClick);
            this.dataGridView_check.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_check_CellDoubleClick);
            this.dataGridView_check.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_check_CellEndEdit);
            this.dataGridView_check.Click += new System.EventHandler(this.dataGridView_check_Click);
            // 
            // Column_name
            // 
            this.Column_name.HeaderText = "員工姓名";
            this.Column_name.Name = "Column_name";
            this.Column_name.ReadOnly = true;
            this.Column_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_onduty_date
            // 
            this.Column_onduty_date.HeaderText = "上班日期";
            this.Column_onduty_date.Name = "Column_onduty_date";
            this.Column_onduty_date.ReadOnly = true;
            // 
            // Column_ondutytime
            // 
            this.Column_ondutytime.HeaderText = "上班時間";
            this.Column_ondutytime.Name = "Column_ondutytime";
            this.Column_ondutytime.ReadOnly = true;
            // 
            // Column1_offdutytime
            // 
            this.Column1_offdutytime.HeaderText = "下班時間";
            this.Column1_offdutytime.Name = "Column1_offdutytime";
            this.Column1_offdutytime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_total
            // 
            this.Column_total.HeaderText = "單日上班時數(分鐘)";
            this.Column_total.Name = "Column_total";
            this.Column_total.ReadOnly = true;
            this.Column_total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_check
            // 
            this.Column_check.HeaderText = "審查";
            this.Column_check.Name = "Column_check";
            this.Column_check.ReadOnly = true;
            this.Column_check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_remark
            // 
            this.Column_remark.HeaderText = "備註";
            this.Column_remark.Name = "Column_remark";
            this.Column_remark.ReadOnly = true;
            this.Column_remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 1314);
            this.panel3.TabIndex = 6;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage_lose_puch);
            this.tabControl2.Controls.Add(this.tabPage_insert_work);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(619, 1314);
            this.tabControl2.TabIndex = 2;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            this.tabControl2.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl2_Selected);
            // 
            // tabPage_lose_puch
            // 
            this.tabPage_lose_puch.Controls.Add(this.button1);
            this.tabPage_lose_puch.Controls.Add(this.label_year);
            this.tabPage_lose_puch.Controls.Add(this.checkBox_check_all);
            this.tabPage_lose_puch.Controls.Add(this.label4);
            this.tabPage_lose_puch.Controls.Add(this.label3);
            this.tabPage_lose_puch.Controls.Add(this.label2);
            this.tabPage_lose_puch.Controls.Add(this.label1);
            this.tabPage_lose_puch.Controls.Add(this.comboBox_month);
            this.tabPage_lose_puch.Controls.Add(this.checkBox_last_year);
            this.tabPage_lose_puch.Controls.Add(this.comboBox_Employee);
            this.tabPage_lose_puch.Location = new System.Drawing.Point(8, 54);
            this.tabPage_lose_puch.Name = "tabPage_lose_puch";
            this.tabPage_lose_puch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_lose_puch.Size = new System.Drawing.Size(603, 1252);
            this.tabPage_lose_puch.TabIndex = 0;
            this.tabPage_lose_puch.Text = "審核";
            this.tabPage_lose_puch.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 52);
            this.button1.TabIndex = 10;
            this.button1.Text = "輸出EXCEL報表";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.Font = new System.Drawing.Font("微軟正黑體", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_year.Location = new System.Drawing.Point(62, 45);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(73, 36);
            this.label_year.TabIndex = 9;
            this.label_year.Text = "日期";
            // 
            // checkBox_check_all
            // 
            this.checkBox_check_all.AutoSize = true;
            this.checkBox_check_all.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Bold);
            this.checkBox_check_all.Location = new System.Drawing.Point(230, 355);
            this.checkBox_check_all.Name = "checkBox_check_all";
            this.checkBox_check_all.Size = new System.Drawing.Size(101, 39);
            this.checkBox_check_all.TabIndex = 8;
            this.checkBox_check_all.Text = "全選";
            this.checkBox_check_all.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(64, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "查詢年份 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 10.125F);
            this.label3.Location = new System.Drawing.Point(64, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "全部審查 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 10.125F);
            this.label2.Location = new System.Drawing.Point(118, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "員工 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(118, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "月份 :";
            // 
            // comboBox_month
            // 
            this.comboBox_month.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_month.Location = new System.Drawing.Point(230, 186);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(132, 48);
            this.comboBox_month.TabIndex = 0;
            this.comboBox_month.SelectionChangeCommitted += new System.EventHandler(this.comboBox_month_SelectionChangeCommitted);
            // 
            // checkBox_last_year
            // 
            this.checkBox_last_year.AutoSize = true;
            this.checkBox_last_year.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_last_year.Location = new System.Drawing.Point(230, 109);
            this.checkBox_last_year.Name = "checkBox_last_year";
            this.checkBox_last_year.Size = new System.Drawing.Size(101, 39);
            this.checkBox_last_year.TabIndex = 2;
            this.checkBox_last_year.Text = "去年";
            this.checkBox_last_year.UseVisualStyleBackColor = true;
            // 
            // comboBox_Employee
            // 
            this.comboBox_Employee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_Employee.FormattingEnabled = true;
            this.comboBox_Employee.Location = new System.Drawing.Point(230, 266);
            this.comboBox_Employee.Name = "comboBox_Employee";
            this.comboBox_Employee.Size = new System.Drawing.Size(256, 48);
            this.comboBox_Employee.TabIndex = 1;
            this.comboBox_Employee.Text = "選擇員工";
            this.comboBox_Employee.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Employee_SelectionChangeCommitted);
            // 
            // tabPage_insert_work
            // 
            this.tabPage_insert_work.Controls.Add(this.textBox1);
            this.tabPage_insert_work.Controls.Add(this.label13);
            this.tabPage_insert_work.Controls.Add(this.label12);
            this.tabPage_insert_work.Controls.Add(this.label11);
            this.tabPage_insert_work.Controls.Add(this.label8);
            this.tabPage_insert_work.Controls.Add(this.label9);
            this.tabPage_insert_work.Controls.Add(this.label10);
            this.tabPage_insert_work.Controls.Add(this.textBox_Off_Min);
            this.tabPage_insert_work.Controls.Add(this.textBox_Off_Hour);
            this.tabPage_insert_work.Controls.Add(this.label7);
            this.tabPage_insert_work.Controls.Add(this.label6);
            this.tabPage_insert_work.Controls.Add(this.label5);
            this.tabPage_insert_work.Controls.Add(this.textBox_On_Min);
            this.tabPage_insert_work.Controls.Add(this.textBox_On_Hour);
            this.tabPage_insert_work.Controls.Add(this.dateTimePicker_lose_punch);
            this.tabPage_insert_work.Controls.Add(this.button_new_punch);
            this.tabPage_insert_work.Location = new System.Drawing.Point(8, 54);
            this.tabPage_insert_work.Name = "tabPage_insert_work";
            this.tabPage_insert_work.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_insert_work.Size = new System.Drawing.Size(603, 1242);
            this.tabPage_insert_work.TabIndex = 1;
            this.tabPage_insert_work.Text = "補打卡";
            this.tabPage_insert_work.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 690);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(552, 459);
            this.textBox1.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("細明體-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(56, 421);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 24);
            this.label13.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(37, 366);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 35);
            this.label12.TabIndex = 14;
            this.label12.Text = "下班時間 :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(37, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 35);
            this.label11.TabIndex = 13;
            this.label11.Text = "上班時間 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(383, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 40);
            this.label8.TabIndex = 12;
            this.label8.Text = "分";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 40);
            this.label9.TabIndex = 11;
            this.label9.Text = "時";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(319, 361);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 40);
            this.label10.TabIndex = 10;
            this.label10.Text = ":";
            // 
            // textBox_Off_Min
            // 
            this.textBox_Off_Min.Location = new System.Drawing.Point(357, 358);
            this.textBox_Off_Min.Name = "textBox_Off_Min";
            this.textBox_Off_Min.Size = new System.Drawing.Size(100, 50);
            this.textBox_Off_Min.TabIndex = 9;
            // 
            // textBox_Off_Hour
            // 
            this.textBox_Off_Hour.Location = new System.Drawing.Point(201, 358);
            this.textBox_Off_Hour.Name = "textBox_Off_Hour";
            this.textBox_Off_Hour.Size = new System.Drawing.Size(100, 50);
            this.textBox_Off_Hour.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(383, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 40);
            this.label7.TabIndex = 7;
            this.label7.Text = "分";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 40);
            this.label6.TabIndex = 6;
            this.label6.Text = "時";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 40);
            this.label5.TabIndex = 5;
            this.label5.Text = ":";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox_On_Min
            // 
            this.textBox_On_Min.Location = new System.Drawing.Point(357, 226);
            this.textBox_On_Min.Name = "textBox_On_Min";
            this.textBox_On_Min.Size = new System.Drawing.Size(100, 50);
            this.textBox_On_Min.TabIndex = 4;
            this.textBox_On_Min.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox_On_Hour
            // 
            this.textBox_On_Hour.Location = new System.Drawing.Point(201, 226);
            this.textBox_On_Hour.Name = "textBox_On_Hour";
            this.textBox_On_Hour.Size = new System.Drawing.Size(100, 50);
            this.textBox_On_Hour.TabIndex = 3;
            this.textBox_On_Hour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // dateTimePicker_lose_punch
            // 
            this.dateTimePicker_lose_punch.Location = new System.Drawing.Point(127, 78);
            this.dateTimePicker_lose_punch.Name = "dateTimePicker_lose_punch";
            this.dateTimePicker_lose_punch.Size = new System.Drawing.Size(338, 50);
            this.dateTimePicker_lose_punch.TabIndex = 2;
            // 
            // button_new_punch
            // 
            this.button_new_punch.Enabled = false;
            this.button_new_punch.Location = new System.Drawing.Point(252, 511);
            this.button_new_punch.Name = "button_new_punch";
            this.button_new_punch.Size = new System.Drawing.Size(143, 50);
            this.button_new_punch.TabIndex = 0;
            this.button_new_punch.Text = "新增";
            this.button_new_punch.UseVisualStyleBackColor = true;
            this.button_new_punch.Click += new System.EventHandler(this.button_new_punch_Click);
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(70, 38);
            this.說明ToolStripMenuItem.Text = "說明";
            this.說明ToolStripMenuItem.Click += new System.EventHandler(this.說明ToolStripMenuItem_Click);
            // 
            // Check_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2334, 1414);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Check_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "古弟私廚 員工管理系統";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Check_Form_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_check.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_check)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage_lose_puch.ResumeLayout(false);
            this.tabPage_lose_puch.PerformLayout();
            this.tabPage_insert_work.ResumeLayout(false);
            this.tabPage_insert_work.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 離開ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 權限管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 備份資料庫ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 輸出當月員工時數表ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_check;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_check;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage_lose_puch;
        private System.Windows.Forms.Label label_year;
        private System.Windows.Forms.CheckBox checkBox_check_all;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.CheckBox checkBox_last_year;
        private System.Windows.Forms.ComboBox comboBox_Employee;
        private System.Windows.Forms.TabPage tabPage_insert_work;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Off_Min;
        private System.Windows.Forms.TextBox textBox_Off_Hour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_On_Min;
        private System.Windows.Forms.TextBox textBox_On_Hour;
        private System.Windows.Forms.DateTimePicker dateTimePicker_lose_punch;
        private System.Windows.Forms.Button button_new_punch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_onduty_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ondutytime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_offdutytime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_remark;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
    }
}