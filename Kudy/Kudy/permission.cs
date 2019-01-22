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

namespace Kudy
{
    public partial class permission : Form
    {
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        Form_Login FL_OLE = new Form_Login();
        public permission()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            ArrayList name = new ArrayList();
            ArrayList acc = new ArrayList();
            ArrayList psw = new ArrayList();
            ArrayList customer_Permission = new ArrayList();
            ArrayList engineer_Permission = new ArrayList();
            ArrayList boss_Permission = new ArrayList();
            DataGridViewRowCollection DGVSP = dataGridView_show_permission.Rows; 

            String SQL_CMD = "Select * From staff_account";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr[1]);
                acc.Add(dr[2]);
                psw.Add(dr[3]);
                customer_Permission.Add(dr[4]);
                engineer_Permission.Add(dr[5]);
                boss_Permission.Add(dr[6]);
            }
            FL_OLE.conn.Close();

            for (int i = 0; i < name.Count; i++)
            {
                DGVSP.Add(name[i], acc[i], psw[i], customer_Permission[i]);
            }
        }

        private void dataGridView_show_permission_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text += "e :" + e.ColumnIndex + "," + e.RowIndex; //列 行
            if (e.ColumnIndex == 3)
            {
                textBox1.Text += dataGridView_show_permission.CurrentCell.Value.ToString();
                switch (dataGridView_show_permission.CurrentCell.Value.ToString())
                {
                    case "False":
                        dataGridView_show_permission.CurrentCell.Value = "True";
                        update_permission("readwrtie", "YES", dataGridView_show_permission[0, e.RowIndex].Value.ToString(), dataGridView_show_permission[1, e.RowIndex].Value.ToString());
                        break;
                    case "True":
                        dataGridView_show_permission.CurrentCell.Value = "False";
                        update_permission("readwrtie", "NO", dataGridView_show_permission[0, e.RowIndex].Value.ToString(), dataGridView_show_permission[1, e.RowIndex].Value.ToString());
                        break;
                }
            }

        }

        private void dataGridView_show_permission_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox1.Text += "姓名"+dataGridView_show_permission[0, e.RowIndex].Value+"\r\n帳號"+dataGridView_show_permission[1, e.RowIndex].Value+"\r\n密碼"+ dataGridView_show_permission.CurrentCell.Value.ToString();

            
            if (e.ColumnIndex == 2)
            {
                
                update_psw(dataGridView_show_permission[0, e.RowIndex].Value.ToString(), dataGridView_show_permission[1, e.RowIndex].Value.ToString(), dataGridView_show_permission.CurrentCell.Value.ToString());
            }
        }
        private void update_psw(String name, String acc,String psw)
        {
            String SQL_upphone = "UPDATE staff_account SET psw = '" + psw + "'"
                                           + " WHERE name = '" + name + "'"
                                           + " AND account = '" + acc + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_upphone;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();
        }
        private void update_permission(String SET,String permission,String name,String acc)
        {
            String SQL_upphone = "UPDATE staff_account SET ["+SET +"] = " + permission + ""
                                           + " WHERE name = '" + name + "'"
                                           + " AND account = '" + acc + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_upphone;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();
        
        }

        private void dataGridView_show_permission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 返回管理頁面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check_Form CF = new Check_Form();
            CF.Show();
            this.Hide();
        }

        private void 說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" 授權員工帳戶管理說明:\r\n\r\n" + "1.目前開放使用賦予員工 顧客系統權限(主要是給員工可以新增顧客)\r\n建議是給正職員工使用\r\n\r\n"
                                                       + "2.更改密碼禁止使用奇怪符號 例如(!@#$%^&*特殊字元)\r\n\r\n"
                                                       + "3.目前授予管理(boss)權限尚未開放 需要請聯絡工程人員\r\n\r\n"
                                                       , "授權管理 說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    }
   
}
