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
    public partial class View_Work : Form
    {
        String name;
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        Form_Login FL_OLE = new Form_Login();

        
        public View_Work(String name)
        {
            InitializeComponent();
            this.Text = "古弟私廚  檢視上班系統 - "+name;
            this.tabPage_work.Text = name + " 上班資料";
            this.name = name;
            comboBox_date.Text = DateTime.Now.Month.ToString();
            checkBox_this_year.Checked = true;
            TabPage TS = tabControl_showinfo.TabPages[1];
            tabControl_showinfo.TabPages.Remove(TS);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            String Date = "";
            label_sum.Text = "NULL";

            if (checkBox_Two_Year_Ago.Checked == true || checkBox_last_year.Checked == true || checkBox_this_year.Checked == true && comboBox_date.Text != "請選擇日期")
            {
                int witch_one=0;
                
                if (checkBox_Two_Year_Ago.Checked == true)
                {
                    Date = (DateTime.Now.Year - 1913).ToString() + "/" + comboBox_date.Text + "/";
                    witch_one = 1;//前年
                    textBox1.Text = "日期" + Date + "權限" + witch_one;
                }
                else if (checkBox_last_year.Checked == true)
                {
                    Date = (DateTime.Now.Year - 1912).ToString() + "/" + comboBox_date.Text + "/";
                    witch_one = 2;//去年
                    textBox1.Text = "日期" + Date + "權限" + witch_one;
                }
                else if (checkBox_this_year.Checked == true)
                {
                    Date = (DateTime.Now.Year - 1911).ToString() + "/" + comboBox_date.Text + "/";
                    witch_one = 3;//今年
                    textBox1.Text = "日期" + Date + "權限" + witch_one;
                }

               
                switch (witch_one)
                { 
                    case 1://前年
                        Get_Data(name,Date);//將資料先存進arraylist
                        textBox1.Text += "\r\n"  + "case " + witch_one;
                        break;
                    case 2://去年
                        Get_Data(name,Date);//將資料先存進arraylist
                        textBox1.Text += "\r\n"  + "case " + witch_one;
                        break;
                    case 3://今年
                        Get_Data(name,Date);//將資料先存進arraylist
                        textBox1.Text += "\r\n"  + "case " + witch_one;
                        break;
                }
            }
            else
            {
                //錯誤訊息
            }

            

                            //將資料顯示在DG裡面
        }
        private void Get_Data(String user_name,String Date)
        {
            DataGridViewRowCollection DGVR = dataGridView_workinfo.Rows;
            ArrayList OnDutyDate = new ArrayList();
            ArrayList OnDutyTime = new ArrayList();
            ArrayList OffDutyTime = new ArrayList();
            ArrayList Single_Total = new ArrayList();
            ArrayList Sum = new ArrayList();
            List<int> Total = new List<int>();
            ArrayList Check = new ArrayList();
            int Total_SUM = 0;
            DGVR.Clear();

            String SQL_CMD = "Select OnDutyDate,OnDutyTime,OffDutyTime,Single_total,Check From " + user_name + " WHERE OnDutyDate LIKE '" + Date + "%'";
            //"SELECT Meal,Date,nop FROM meal WHERE name LIKE" + "'" + show_customer_LbSelected + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD;

            dr = cmd.ExecuteReader();
           

                while (dr.Read())
                {
                    OnDutyDate.Add(dr[0]);
                    OnDutyTime.Add(dr[1]);
                    OffDutyTime.Add(dr[2]);
                    Single_Total.Add(dr[3]);
                    Check.Add(dr[4]);
                   // DGVR.Add(dr[0],dr[1], dr[2], dr[3],dr[4]);   
                }

                if (OnDutyDate.Count == 0 )
                {
                    DGVR.Add("無資料", "無資料", "無資料", "無資料", "無資料");
                }
                else
                { 
                    
                    //foreach (String all in Single_Total)//處理型態要轉換時間顯示
                    //{
             
                    //    Total.Add(Int32.Parse(all));
                    //}
                    for (int k = 0; k < Single_Total.Count; k++)
                    {
                        if (Single_Total[k].ToString() == "")
                        {
                            break;
                        }
                        else 
                        {
                            Total.Add(Int32.Parse(Single_Total[k].ToString()));
                        }
                        
                    }
                        for (int i = 0; i < Total.Count; i++)
                        {
                            Total_SUM += Total[i];
                            Sum.Add(change2Hour(Total[i]).ToString());
                            textBox1.Text += " 轉型態 : " + change2Hour(Total[i]).ToString();
                        }
                    textBox1.Text += OnDutyDate.Count + " " + OnDutyTime.Count + " " + OffDutyTime.Count + " " + Sum.Count + " " + Check.Count;
                    try
                    {

                        if (Sum.Count < OnDutyDate.Count)
                        {


                            for (int j = 0; j < OnDutyDate.Count; j++)
                            {

                                //55545問題解決
                                if (j == OnDutyDate.Count - 1)
                                {
                                    DGVR.Add(OnDutyDate[j], OnDutyTime[j], "尚未打卡下班", "無資料", "無資料");
                                    MessageBox.Show("缺少打卡下班\r\n請管理者補打下班卡\r\n", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                else
                                {
                                    DGVR.Add(OnDutyDate[j], OnDutyTime[j], OffDutyTime[j], Sum[j], Check[j]);
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < OnDutyDate.Count; j++)
                            {
                                DGVR.Add(OnDutyDate[j], OnDutyTime[j], OffDutyTime[j], Sum[j], Check[j]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("[ 缺少打卡下班 ]\r\n請老闆補打下班卡\r\n才會顯示之後打卡資料\r\n", "提醒訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);                   
                    }

                }
           
            FL_OLE.conn.Close();
            label_sum.Text = "總時數為 : " + change2Hour(Total_SUM);
            
            
            


        }
        private String change2Hour(int Total_time)
        {
            String Hour = (Total_time / 60).ToString();
            String Min = (Total_time % 60).ToString();
            return Hour + "小時" + Min + "分鐘";
        }

        private void checkBox_this_year_Click(object sender, EventArgs e)
        {
            checkBox_Two_Year_Ago.Checked = false;
            checkBox_last_year.Checked = false;
        }

        private void checkBox_last_year_Click(object sender, EventArgs e)
        {
            checkBox_this_year.Checked = false;
            checkBox_Two_Year_Ago.Checked = false;
        }

        private void checkBox_Two_Year_Ago_Click(object sender, EventArgs e)
        {
            checkBox_last_year.Checked = false;
            checkBox_this_year.Checked = false;
        }

        private void 離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }

        private void View_Work_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }

    }
}
