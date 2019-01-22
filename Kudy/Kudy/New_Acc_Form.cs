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
using System.Reflection;
using System.Text.RegularExpressions;

namespace Kudy
{
    public partial class New_Acc_Form : Form
    {
      
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        Form_Login FL_OLE = new Form_Login();
        ArrayList acc = new ArrayList();
        ArrayList name = new ArrayList();
        
        public New_Acc_Form()
        {
            InitializeComponent();
            check_unique_button.Enabled = false;
            panel_PSWandNAME.Visible = false;
        }

        private void New_Acc_Form_Load(object sender, EventArgs e)
        {

        }

        private void check_unique_button_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrWhiteSpace(textBox_acc.Text))//空白
            {
                MessageBox.Show("空格裡不能為空白", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_acc.Clear();
                textBox_acc.Focus();
                check_unique_button.Enabled = false;
            }
            else //不是空白
            {
                SEARCH_db_conn("account", "staff_account", textBox_acc.Text);
                SEARCH_db_conn_2("name", "staff_account",textBox_name.Text);

                if (acc.Count>0)
                {
                    message_box_warning("帳號重複");
                }
                else if(name.Count>0)
                {
                    message_box_warning("姓名重複");
                }
                else if (name.Count > 0 || acc.Count > 0)
                {
                    message_box_warning("此員工 已存在");              
                }
                else
                {

                    if (CheckAcc_legal(textBox_acc.Text, @"^([a-z0-9_\-\.]+)(\]?)$") && textBox_acc.Text.Length >= 6)
                    {

                        panel_PSWandNAME.Visible = true;
                        textBox_acc.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("帳號不合法(不能有符號),或是帳號數小於六", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
        }
        private void message_box_warning(String message) 
        {
            MessageBox.Show(message, "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox_acc.Clear();
            textBox_acc.Focus();
            check_unique_button.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private bool CheckAcc_legal(string text,String Acc)
        {
            Regex Regex1 = new Regex(Acc, RegexOptions.IgnoreCase);
            return Regex1.IsMatch(text);
            
        }
        private void SEARCH_db_conn(String Field,String Table,String Search) //接資料 
        {
            acc.Clear();
            String SQL_CMD = "Select " + Field + " From " + Table + " WHERE " + Field + " = '" + Search + "'";
           // String SQL_new_name = "Select name From kudydb WHERE name = '" + NewName + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                acc.Add(dr[0]);
            }
            FL_OLE.conn.Close();
           // acc_textBox.Text = SQL_CMD;
        }
        private void SEARCH_db_conn_2(String Field, String Table, String Search) //接資料 
        {
            name.Clear();
            String SQL_CMD = "Select " + Field + " From " + Table + " WHERE " + Field + " = '" + Search + "'";
            // String SQL_new_name = "Select name From kudydb WHERE name = '" + NewName + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr[0]);
            }
            FL_OLE.conn.Close();
            // acc_textBox.Text = SQL_CMD;
        }
        private void update_db_conn(String Table, String Field, String data1, String data2, String data3) //新增資料 
        {
            acc.Clear();
            String SQL_CMD_insert = "INSERT INTO " + Table + " (" + Field + ") VALUES('" + data1 + "','" + data2 + "','" + data3 + "')";
            //String insert_kudydb_newAcc =  "INSERT INTO kudydb (name,phone,BD) VALUES('"+textBox_NewAcc_name.Text+"','"+textBox_NewAcc_phone.Text+"','"+textBox_NewAcc_BD.Text+"')";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD_insert;    
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();
        }
        private void acc_textBox_TextChanged(object sender, EventArgs e)
        {
            check_unique_button.Enabled = true;
        }

        private void leave_button_Click(object sender, EventArgs e)
        {
            Form_Login FL = new Form_Login();
            FL.Show();
            this.Hide();
        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_PSW.Text) || string.IsNullOrWhiteSpace(textBox_name.Text))
            {
                MessageBox.Show("欄位空白", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Create_punch_table(textBox_name.Text.ToString());
                    update_db_conn("staff_account", "name,account,psw", textBox_name.Text.ToString(), textBox_acc.Text.ToString(), textBox_PSW.Text.ToString());
                    DialogResult DR = MessageBox.Show("新增帳號成功 :\r\n" + "帳號 : " + textBox_acc.Text.ToString() + "\r\n" + "密碼 : " + textBox_PSW.Text.ToString(), "成功訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (DR == DialogResult.OK)
                    {
                        Form_Login FL = new Form_Login();
                        FL.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("資料表重複導致新增失敗！！\r\n此狀態為例外條件(請通知工程人員 - Nate)！！\r\n" + "例外事件 : " + ex, "失敗訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
                }
            }
        }
        private void Create_punch_table(String table_name)
        {
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = "CREATE TABLE " + table_name + 
                              "([EID] AUTOINCREMENT NULL,"+
                              "[name] VARCHAR(40) NULL," +
                              "[OnDutyDate] VARCHAR(40) NULL," +
                              "[OnDutyTime] VARCHAR(40) NULL,"+
                              "[OffDutyTime] VARCHAR(40) NULL," +
                              "[Single_total] VARCHAR(40) NULL,"+
                              "[Check] VARCHAR(40) NULL,"+
                              "[Remark] VARCHAR(40) NULL)";
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();
//            cmd.CommandText = @"CREATE TABLE PersonalData (
//                                [DataID] AUTOINCREMENT NOT NULL PRIMARY KEY,
//                                [Type] VARCHAR(40) NOT NULL,
//                                [URL] VARCHAR(40) NOT NULL,
//                                [SoftwareName] VARCHAR(40) NOT NULL,
//                                [SerialCode] VARCHAR(40) NOT NULL,
//                                [UserName] VARCHAR(40) NOT NULL,
//                                [Password] VARCHAR(40) NOT NULL
//                                                               )";
            
           
        }

        private void New_Acc_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
    }
}
