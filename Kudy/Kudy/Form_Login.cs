using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;

/*
 版本管理 (出版).(幾個Form).(第幾次面談)
 */

namespace Kudy
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }
        //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ImNaTE\Desktop\kudydb.accdb;");
        ////new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ImNaTE\Desktop\kudydb.accdb;");
        //OleDbCommand cmd = new OleDbCommand();
        //OleDbDataReader dr;
      
        public  OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\gogx1\Desktop\Github\POS_KudyRestaurant\kudydb.accdb;");//本機端
        //public OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\kudydb.accdb;");//古弟私廚路徑
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList name = new ArrayList();
            ArrayList account = new ArrayList();
            ArrayList psw = new ArrayList();
            ArrayList readwrite = new ArrayList();
            ArrayList engineer = new ArrayList();
            ArrayList boss = new ArrayList();

            //this.Close();           
           // F1.Show();
            if (textBox_account.Text.Length == 0 || textBox_psw.Text.Length == 0)
            {
                MessageBox.Show(" 請輸入帳號或密碼", "登入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                String check_psd = "SELECT * FROM staff_account WHERE account LIKE '" + textBox_account.Text + "'";
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = check_psd;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    name.Add(dr[1]);
                    account.Add(dr[2]);
                    psw.Add(dr[3]);
                    readwrite.Add(dr[4]);                  
                    engineer.Add(dr[5]);
                    boss.Add(dr[6]);

                }    
                
                conn.Close();

                if (account.Count > 0 ||  psw.Count > 0)
                {
                    if (account[0].ToString()==textBox_account.Text.ToString() && psw[0].ToString()== textBox_psw.Text.ToString())
                    {
                        index_Form IF = new index_Form(readwrite[0].ToString(), engineer[0].ToString(), boss[0].ToString(), name[0].ToString());
                        this.Hide();
                        IF.Show(this);
                        


                        //Customer_Form CF = new Customer_Form(readwrite[0].ToString(), engineer[0].ToString(), boss[0].ToString(),name[0].ToString());
                        //this.Hide();
                        //CF.Show(this);
                        //CF.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show(" 帳號或密碼錯誤", "登入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show(" 帳號或密碼錯誤", "登入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void textBox_account_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_account.Text = "";
            textBox_account.ForeColor = Color.Black;
        }

        private void textBox_psw_MouseDown(object sender, MouseEventArgs e)
        {
            
            textBox_psw.Text = "";
            textBox_psw.ForeColor = Color.Black;
            textBox_psw.PasswordChar = '．';
        }

        private void textBox_psw_Enter(object sender, EventArgs e)
        {

            textBox_psw.Text = "";
            textBox_psw.ForeColor = Color.Black;
            textBox_psw.PasswordChar = '．';
        }

        private void textBox_psw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Login.Focus();
                button1_Click(sender, e);


            }
        }

        private void new_Acc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            New_Acc_Form MCF = new New_Acc_Form();
            this.Hide();
            MCF.Show();
        }
        public String change2Hour(int Total_time)
        {
            String Hour = (Total_time / 60).ToString();
            String Min = (Total_time % 60).ToString();
            return Hour + "小時" + Min + "分鐘";
        }
        public int Check_punch_time(String On_duty, String Off_duty)
        {
            String[] On_duty_split = On_duty.Split(':');
            String[] Off_Duty_splot = Off_duty.Split(':');
            List<int> On_duty_int = new List<int>();
            List<int> Off_Duty_int = new List<int>();
            int Hour = 0;
            int Min = 0;
            int total = 0;


            if (Off_duty.Length > 5)
            {
                MessageBox.Show("時間格式錯誤", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
               
                foreach (String On in On_duty_split)
                {
                    On_duty_int.Add(Int32.Parse(On));
                }

                foreach (String Off in Off_Duty_splot)
                {
                    Off_Duty_int.Add(Int32.Parse(Off));
                }

                //if (Hour == 0)
                //{
                //    total = (24 + Hour) * 60 + Min;
                //}
                //else if (Hour == 0)
                //{
                //    total = (25 + Hour) * 60 + Min;
                //}
                //else
                //{
                //    total = Hour * 60 + Min;
                //}
                for (int i = 0; i < On_duty_int.Count; i++)
                {
                    if (i == 0)
                    {
                        if (Off_Duty_int[i] == 0)
                        {
                            Off_Duty_int[i] += 24;
                            if (On_duty_int[i] > Off_Duty_int[i])
                            {
                                Hour = On_duty_int[i] - Off_Duty_int[i];
                            }
                            else if (On_duty_int[i] < Off_Duty_int[i])
                            {
                                Hour = Off_Duty_int[i] - On_duty_int[i];
                            }
                        }
                        else if (Off_Duty_int[i] == 1)
                        {
                            Off_Duty_int[i] += 25;
                            if (On_duty_int[i] > Off_Duty_int[i])
                            {
                                Hour = On_duty_int[i] - Off_Duty_int[i];
                            }
                            else if (On_duty_int[i] < Off_Duty_int[i])
                            {
                                Hour = Off_Duty_int[i] - On_duty_int[i];
                            }
                        }
                        else
                        {
                            if (On_duty_int[i] > Off_Duty_int[i])
                            {
                                Hour = On_duty_int[i] - Off_Duty_int[i];
                            }
                            else if (On_duty_int[i] < Off_Duty_int[i])
                            {
                                Hour = Off_Duty_int[i] - On_duty_int[i];
                            }
                        }

                    }
                    else if (i == 1)
                    {
                        if (On_duty_int[i] > Off_Duty_int[i])
                        {
                            Min = On_duty_int[i] - Off_Duty_int[i];
                        }
                        else if (On_duty_int[i] < Off_Duty_int[i])
                        {
                            Min = Off_Duty_int[i] - On_duty_int[i];
                        }

                    }

                }
                total = (Hour * 60) + Min;

                return total;
            }
            return 0;
        }

        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
      
    }
}
