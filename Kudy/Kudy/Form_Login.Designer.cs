namespace Kudy
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox_account = new System.Windows.Forms.TextBox();
            this.textBox_psw = new System.Windows.Forms.TextBox();
            this.new_Acc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(244, 352);
            this.button_Login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(235, 46);
            this.button_Login.TabIndex = 0;
            this.button_Login.Text = "登入";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_account
            // 
            this.textBox_account.ForeColor = System.Drawing.Color.Silver;
            this.textBox_account.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox_account.Location = new System.Drawing.Point(233, 234);
            this.textBox_account.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_account.Name = "textBox_account";
            this.textBox_account.Size = new System.Drawing.Size(255, 36);
            this.textBox_account.TabIndex = 1;
            this.textBox_account.Text = "請輸入帳號";
            this.textBox_account.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_account_MouseDown);
            // 
            // textBox_psw
            // 
            this.textBox_psw.ForeColor = System.Drawing.Color.Silver;
            this.textBox_psw.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox_psw.Location = new System.Drawing.Point(233, 276);
            this.textBox_psw.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_psw.Name = "textBox_psw";
            this.textBox_psw.Size = new System.Drawing.Size(255, 36);
            this.textBox_psw.TabIndex = 2;
            this.textBox_psw.Text = "請輸入密碼";
            this.textBox_psw.Enter += new System.EventHandler(this.textBox_psw_Enter);
            this.textBox_psw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_psw_KeyDown);
            this.textBox_psw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_psw_MouseDown);
            // 
            // new_Acc_linkLabel
            // 
            this.new_Acc_linkLabel.AutoSize = true;
            this.new_Acc_linkLabel.Location = new System.Drawing.Point(283, 504);
            this.new_Acc_linkLabel.Name = "new_Acc_linkLabel";
            this.new_Acc_linkLabel.Size = new System.Drawing.Size(154, 24);
            this.new_Acc_linkLabel.TabIndex = 3;
            this.new_Acc_linkLabel.TabStop = true;
            this.new_Acc_linkLabel.Text = "新增員工帳號";
            this.new_Acc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.new_Acc_linkLabel_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.new_Acc_linkLabel);
            this.panel1.Controls.Add(this.textBox_psw);
            this.panel1.Controls.Add(this.textBox_account);
            this.panel1.Controls.Add(this.button_Login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 705);
            this.panel1.TabIndex = 1;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 705);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "古弟私廚 登入 (Beta 1.7.3)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Login_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TextBox textBox_account;
        private System.Windows.Forms.TextBox textBox_psw;
        private System.Windows.Forms.LinkLabel new_Acc_linkLabel;
        private System.Windows.Forms.Panel panel1;

    }
}