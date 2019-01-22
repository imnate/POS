namespace Kudy
{
    partial class index_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(index_Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_clock = new System.Windows.Forms.Label();
            this.information = new System.Windows.Forms.Button();
            this.Audit_work_button = new System.Windows.Forms.Button();
            this.Punch = new System.Windows.Forms.Button();
            this.Customer_System = new System.Windows.Forms.Button();
            this.timer_clock = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_clock);
            this.panel1.Controls.Add(this.information);
            this.panel1.Controls.Add(this.Audit_work_button);
            this.panel1.Controls.Add(this.Punch);
            this.panel1.Controls.Add(this.Customer_System);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1348, 1021);
            this.panel1.TabIndex = 0;
            // 
            // label_clock
            // 
            this.label_clock.AutoSize = true;
            this.label_clock.Font = new System.Drawing.Font("Segoe Marker", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_clock.Location = new System.Drawing.Point(406, 23);
            this.label_clock.Name = "label_clock";
            this.label_clock.Size = new System.Drawing.Size(127, 61);
            this.label_clock.TabIndex = 4;
            this.label_clock.Text = "clock";
            // 
            // information
            // 
            this.information.Font = new System.Drawing.Font("微軟正黑體", 19.875F, System.Drawing.FontStyle.Bold);
            this.information.Location = new System.Drawing.Point(683, 118);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(412, 408);
            this.information.TabIndex = 3;
            this.information.Text = "上班資料";
            this.information.UseVisualStyleBackColor = true;
            this.information.Click += new System.EventHandler(this.information_Click);
            // 
            // Audit_work_button
            // 
            this.Audit_work_button.Font = new System.Drawing.Font("微軟正黑體", 19.875F, System.Drawing.FontStyle.Bold);
            this.Audit_work_button.Location = new System.Drawing.Point(683, 548);
            this.Audit_work_button.Name = "Audit_work_button";
            this.Audit_work_button.Size = new System.Drawing.Size(412, 408);
            this.Audit_work_button.TabIndex = 2;
            this.Audit_work_button.Text = "管理";
            this.Audit_work_button.UseVisualStyleBackColor = true;
            this.Audit_work_button.Click += new System.EventHandler(this.Audit_work_button_Click);
            // 
            // Punch
            // 
            this.Punch.Font = new System.Drawing.Font("微軟正黑體", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Punch.Location = new System.Drawing.Point(248, 118);
            this.Punch.Name = "Punch";
            this.Punch.Size = new System.Drawing.Size(412, 408);
            this.Punch.TabIndex = 1;
            this.Punch.Text = "打卡";
            this.Punch.UseVisualStyleBackColor = true;
            this.Punch.Click += new System.EventHandler(this.Punch_Click);
            // 
            // Customer_System
            // 
            this.Customer_System.Font = new System.Drawing.Font("微軟正黑體", 19.875F, System.Drawing.FontStyle.Bold);
            this.Customer_System.Location = new System.Drawing.Point(248, 548);
            this.Customer_System.Name = "Customer_System";
            this.Customer_System.Size = new System.Drawing.Size(412, 408);
            this.Customer_System.TabIndex = 0;
            this.Customer_System.Text = "顧客系統";
            this.Customer_System.UseVisualStyleBackColor = true;
            this.Customer_System.Click += new System.EventHandler(this.Customer_System_Click);
            // 
            // timer_clock
            // 
            this.timer_clock.Tick += new System.EventHandler(this.timer_clock_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 963);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // index_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1348, 1021);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "index_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "古弟私廚 系統首頁";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.index_Form_FormClosing);
            this.Load += new System.EventHandler(this.index_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button information;
        private System.Windows.Forms.Button Audit_work_button;
        private System.Windows.Forms.Button Punch;
        private System.Windows.Forms.Button Customer_System;
        private System.Windows.Forms.Timer timer_clock;
        private System.Windows.Forms.Label label_clock;
        private System.Windows.Forms.Label label1;
    }
}