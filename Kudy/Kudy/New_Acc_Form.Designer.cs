namespace Kudy
{
    partial class New_Acc_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_Acc_Form));
            this.Acc_label = new System.Windows.Forms.Label();
            this.textBox_acc = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.name_label = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.leave_button = new System.Windows.Forms.Button();
            this.panel_PSWandNAME = new System.Windows.Forms.Panel();
            this.textBox_PSW = new System.Windows.Forms.TextBox();
            this.PSW_label = new System.Windows.Forms.Label();
            this.confirm_button = new System.Windows.Forms.Button();
            this.check_unique_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel_PSWandNAME.SuspendLayout();
            this.SuspendLayout();
            // 
            // Acc_label
            // 
            this.Acc_label.AutoSize = true;
            this.Acc_label.Font = new System.Drawing.Font("Buxton Sketch", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Acc_label.Location = new System.Drawing.Point(243, 137);
            this.Acc_label.Name = "Acc_label";
            this.Acc_label.Size = new System.Drawing.Size(96, 39);
            this.Acc_label.TabIndex = 0;
            this.Acc_label.Text = "帳號 :";
            // 
            // textBox_acc
            // 
            this.textBox_acc.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_acc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox_acc.Location = new System.Drawing.Point(359, 134);
            this.textBox_acc.Name = "textBox_acc";
            this.textBox_acc.Size = new System.Drawing.Size(238, 43);
            this.textBox_acc.TabIndex = 1;
            this.textBox_acc.TextChanged += new System.EventHandler(this.acc_textBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.name_label);
            this.panel1.Controls.Add(this.textBox_name);
            this.panel1.Controls.Add(this.leave_button);
            this.panel1.Controls.Add(this.panel_PSWandNAME);
            this.panel1.Controls.Add(this.check_unique_button);
            this.panel1.Controls.Add(this.Acc_label);
            this.panel1.Controls.Add(this.textBox_acc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 510);
            this.panel1.TabIndex = 2;
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Buxton Sketch", 12F);
            this.name_label.Location = new System.Drawing.Point(243, 71);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(103, 39);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "姓名 : ";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("微軟正黑體", 10.125F);
            this.textBox_name.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox_name.Location = new System.Drawing.Point(359, 67);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(238, 43);
            this.textBox_name.TabIndex = 3;
            // 
            // leave_button
            // 
            this.leave_button.Location = new System.Drawing.Point(371, 402);
            this.leave_button.Name = "leave_button";
            this.leave_button.Size = new System.Drawing.Size(217, 57);
            this.leave_button.TabIndex = 5;
            this.leave_button.Text = "返回登入畫面";
            this.leave_button.UseVisualStyleBackColor = true;
            this.leave_button.Click += new System.EventHandler(this.leave_button_Click);
            // 
            // panel_PSWandNAME
            // 
            this.panel_PSWandNAME.Controls.Add(this.textBox_PSW);
            this.panel_PSWandNAME.Controls.Add(this.PSW_label);
            this.panel_PSWandNAME.Controls.Add(this.confirm_button);
            this.panel_PSWandNAME.Location = new System.Drawing.Point(189, 199);
            this.panel_PSWandNAME.Name = "panel_PSWandNAME";
            this.panel_PSWandNAME.Size = new System.Drawing.Size(586, 197);
            this.panel_PSWandNAME.TabIndex = 3;
            // 
            // textBox_PSW
            // 
            this.textBox_PSW.Font = new System.Drawing.Font("微軟正黑體", 10.125F);
            this.textBox_PSW.Location = new System.Drawing.Point(170, 14);
            this.textBox_PSW.Name = "textBox_PSW";
            this.textBox_PSW.PasswordChar = '＊';
            this.textBox_PSW.Size = new System.Drawing.Size(238, 43);
            this.textBox_PSW.TabIndex = 1;
            // 
            // PSW_label
            // 
            this.PSW_label.AutoSize = true;
            this.PSW_label.Font = new System.Drawing.Font("Buxton Sketch", 12F);
            this.PSW_label.Location = new System.Drawing.Point(54, 14);
            this.PSW_label.Name = "PSW_label";
            this.PSW_label.Size = new System.Drawing.Size(103, 39);
            this.PSW_label.TabIndex = 0;
            this.PSW_label.Text = "密碼 : ";
            // 
            // confirm_button
            // 
            this.confirm_button.Location = new System.Drawing.Point(242, 99);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(98, 57);
            this.confirm_button.TabIndex = 4;
            this.confirm_button.Text = "確定";
            this.confirm_button.UseVisualStyleBackColor = true;
            this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
            // 
            // check_unique_button
            // 
            this.check_unique_button.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.check_unique_button.Location = new System.Drawing.Point(614, 126);
            this.check_unique_button.Name = "check_unique_button";
            this.check_unique_button.Size = new System.Drawing.Size(184, 59);
            this.check_unique_button.TabIndex = 2;
            this.check_unique_button.Text = "檢查可用";
            this.check_unique_button.UseVisualStyleBackColor = true;
            this.check_unique_button.Click += new System.EventHandler(this.check_unique_button_Click);
            // 
            // New_Acc_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(983, 510);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "New_Acc_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "古弟私廚 新增員工帳戶";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.New_Acc_Form_FormClosing);
            this.Load += new System.EventHandler(this.New_Acc_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_PSWandNAME.ResumeLayout(false);
            this.panel_PSWandNAME.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Acc_label;
        private System.Windows.Forms.TextBox textBox_acc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button check_unique_button;
        private System.Windows.Forms.Panel panel_PSWandNAME;
        private System.Windows.Forms.TextBox textBox_PSW;
        private System.Windows.Forms.Label PSW_label;
        private System.Windows.Forms.Button leave_button;
        private System.Windows.Forms.Button confirm_button;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label name_label;
    }
}