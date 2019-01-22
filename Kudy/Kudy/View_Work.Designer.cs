namespace Kudy
{
    partial class View_Work
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Work));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl_showinfo = new System.Windows.Forms.TabControl();
            this.tabPage_work = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_workinfo = new System.Windows.Forms.DataGridView();
            this.Column_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OnDutyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OffDutyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SingleDuty_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_sum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.checkBox_Two_Year_Ago = new System.Windows.Forms.CheckBox();
            this.comboBox_date = new System.Windows.Forms.ComboBox();
            this.checkBox_this_year = new System.Windows.Forms.CheckBox();
            this.checkBox_last_year = new System.Windows.Forms.CheckBox();
            this.tabPage_基本資料 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl_showinfo.SuspendLayout();
            this.tabPage_work.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_workinfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage_基本資料.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl_showinfo);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2320, 1209);
            this.panel1.TabIndex = 0;
            // 
            // tabControl_showinfo
            // 
            this.tabControl_showinfo.Controls.Add(this.tabPage_work);
            this.tabControl_showinfo.Controls.Add(this.tabPage_基本資料);
            this.tabControl_showinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_showinfo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl_showinfo.Location = new System.Drawing.Point(0, 37);
            this.tabControl_showinfo.Name = "tabControl_showinfo";
            this.tabControl_showinfo.SelectedIndex = 0;
            this.tabControl_showinfo.Size = new System.Drawing.Size(2320, 1172);
            this.tabControl_showinfo.TabIndex = 1;
            // 
            // tabPage_work
            // 
            this.tabPage_work.Controls.Add(this.panel3);
            this.tabPage_work.Controls.Add(this.panel2);
            this.tabPage_work.Location = new System.Drawing.Point(8, 54);
            this.tabPage_work.Name = "tabPage_work";
            this.tabPage_work.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_work.Size = new System.Drawing.Size(2304, 1110);
            this.tabPage_work.TabIndex = 0;
            this.tabPage_work.Text = "上班資料";
            this.tabPage_work.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_workinfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2298, 989);
            this.panel3.TabIndex = 6;
            // 
            // dataGridView_workinfo
            // 
            this.dataGridView_workinfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_workinfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_workinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_workinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Date,
            this.Column_OnDutyTime,
            this.Column_OffDutyTime,
            this.Column_SingleDuty_Total,
            this.Column_check});
            this.dataGridView_workinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_workinfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_workinfo.Name = "dataGridView_workinfo";
            this.dataGridView_workinfo.RowTemplate.Height = 38;
            this.dataGridView_workinfo.Size = new System.Drawing.Size(2298, 989);
            this.dataGridView_workinfo.TabIndex = 0;
            // 
            // Column_Date
            // 
            this.Column_Date.HeaderText = "上班日期";
            this.Column_Date.Name = "Column_Date";
            this.Column_Date.ReadOnly = true;
            // 
            // Column_OnDutyTime
            // 
            this.Column_OnDutyTime.HeaderText = "上班時間";
            this.Column_OnDutyTime.Name = "Column_OnDutyTime";
            this.Column_OnDutyTime.ReadOnly = true;
            // 
            // Column_OffDutyTime
            // 
            this.Column_OffDutyTime.HeaderText = "下班時間";
            this.Column_OffDutyTime.Name = "Column_OffDutyTime";
            this.Column_OffDutyTime.ReadOnly = true;
            // 
            // Column_SingleDuty_Total
            // 
            this.Column_SingleDuty_Total.HeaderText = "單日上班總數";
            this.Column_SingleDuty_Total.Name = "Column_SingleDuty_Total";
            this.Column_SingleDuty_Total.ReadOnly = true;
            // 
            // Column_check
            // 
            this.Column_check.HeaderText = "審查";
            this.Column_check.Name = "Column_check";
            this.Column_check.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_sum);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button_search);
            this.panel2.Controls.Add(this.checkBox_Two_Year_Ago);
            this.panel2.Controls.Add(this.comboBox_date);
            this.panel2.Controls.Add(this.checkBox_this_year);
            this.panel2.Controls.Add(this.checkBox_last_year);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2298, 115);
            this.panel2.TabIndex = 5;
            // 
            // label_sum
            // 
            this.label_sum.AutoSize = true;
            this.label_sum.Location = new System.Drawing.Point(1603, 33);
            this.label_sum.Name = "label_sum";
            this.label_sum.Size = new System.Drawing.Size(145, 40);
            this.label_sum.TabIndex = 7;
            this.label_sum.Text = "上班時數";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(735, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "月份";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(848, 21);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(251, 59);
            this.button_search.TabIndex = 5;
            this.button_search.Text = "檢視上班";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // checkBox_Two_Year_Ago
            // 
            this.checkBox_Two_Year_Ago.AutoSize = true;
            this.checkBox_Two_Year_Ago.Location = new System.Drawing.Point(45, 30);
            this.checkBox_Two_Year_Ago.Name = "checkBox_Two_Year_Ago";
            this.checkBox_Two_Year_Ago.Size = new System.Drawing.Size(113, 44);
            this.checkBox_Two_Year_Ago.TabIndex = 3;
            this.checkBox_Two_Year_Ago.Text = "前年";
            this.checkBox_Two_Year_Ago.UseVisualStyleBackColor = true;
            this.checkBox_Two_Year_Ago.Click += new System.EventHandler(this.checkBox_Two_Year_Ago_Click);
            // 
            // comboBox_date
            // 
            this.comboBox_date.FormattingEnabled = true;
            this.comboBox_date.Items.AddRange(new object[] {
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
            this.comboBox_date.Location = new System.Drawing.Point(627, 25);
            this.comboBox_date.Name = "comboBox_date";
            this.comboBox_date.Size = new System.Drawing.Size(102, 48);
            this.comboBox_date.TabIndex = 4;
            this.comboBox_date.Text = "請選擇月份";
            // 
            // checkBox_this_year
            // 
            this.checkBox_this_year.AutoSize = true;
            this.checkBox_this_year.Location = new System.Drawing.Point(422, 29);
            this.checkBox_this_year.Name = "checkBox_this_year";
            this.checkBox_this_year.Size = new System.Drawing.Size(113, 44);
            this.checkBox_this_year.TabIndex = 1;
            this.checkBox_this_year.Text = "今年";
            this.checkBox_this_year.UseVisualStyleBackColor = true;
            this.checkBox_this_year.Click += new System.EventHandler(this.checkBox_this_year_Click);
            // 
            // checkBox_last_year
            // 
            this.checkBox_last_year.AutoSize = true;
            this.checkBox_last_year.Location = new System.Drawing.Point(232, 30);
            this.checkBox_last_year.Name = "checkBox_last_year";
            this.checkBox_last_year.Size = new System.Drawing.Size(113, 44);
            this.checkBox_last_year.TabIndex = 2;
            this.checkBox_last_year.Text = "去年";
            this.checkBox_last_year.UseVisualStyleBackColor = true;
            this.checkBox_last_year.Click += new System.EventHandler(this.checkBox_last_year_Click);
            // 
            // tabPage_基本資料
            // 
            this.tabPage_基本資料.Controls.Add(this.textBox1);
            this.tabPage_基本資料.Location = new System.Drawing.Point(8, 54);
            this.tabPage_基本資料.Name = "tabPage_基本資料";
            this.tabPage_基本資料.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_基本資料.Size = new System.Drawing.Size(2304, 1110);
            this.tabPage_基本資料.TabIndex = 1;
            this.tabPage_基本資料.Text = "基本資料";
            this.tabPage_基本資料.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(468, 98);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(842, 709);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("細明體", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem,
            this.離開ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2320, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(85, 33);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 離開ToolStripMenuItem
            // 
            this.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
            this.離開ToolStripMenuItem.Size = new System.Drawing.Size(85, 33);
            this.離開ToolStripMenuItem.Text = "離開";
            this.離開ToolStripMenuItem.Click += new System.EventHandler(this.離開ToolStripMenuItem_Click);
            // 
            // View_Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2320, 1209);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "View_Work";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "古弟私廚  檢視上班系統";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.View_Work_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl_showinfo.ResumeLayout(false);
            this.tabPage_work.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_workinfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage_基本資料.ResumeLayout(false);
            this.tabPage_基本資料.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 離開ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl_showinfo;
        private System.Windows.Forms.TabPage tabPage_work;
        private System.Windows.Forms.TabPage tabPage_基本資料;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_workinfo;
        private System.Windows.Forms.ComboBox comboBox_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OnDutyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OffDutyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SingleDuty_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_check;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.CheckBox checkBox_Two_Year_Ago;
        private System.Windows.Forms.CheckBox checkBox_this_year;
        private System.Windows.Forms.CheckBox checkBox_last_year;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_sum;
    }
}