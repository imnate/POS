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
    public partial class index_Form : Form
    {
        public String readwrite;
        public String engineer;
        public String boss;
        public String USER_name;

        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        Form_Login FL_OLE = new Form_Login();

        ArrayList OnD_Date = new ArrayList();
        ArrayList OnD_Time = new ArrayList();
        ArrayList OffD_Time = new ArrayList();


        public index_Form(String readwrite, String engineer, String boss, String USER_name)
        {

            InitializeComponent();

            label1.Text = "RW " + readwrite + "Boss" + boss + "Enginner " + engineer;
            this.readwrite = readwrite;
            this.engineer = engineer;
            this.boss = boss;
            this.USER_name = USER_name;
            this.Text = "古弟私廚 資訊系統 首頁   [員工: " + USER_name + "] 權限:無";
            if (readwrite == "False" && engineer == "False" && boss == "False")//一般權限
            {
                Audit_work_button.Enabled = false;
                this.Text = "古弟私廚 資訊系統 首頁   [員工: " + USER_name + "] 權限:低";
            }
            else if (readwrite == "True")
            {
                Audit_work_button.Enabled = false;
                this.Text = "古弟私廚 資訊系統 首頁   [員工: " + USER_name + "] 權限:中";
            }
            else if (engineer == "True")//工程師權限
            {

                this.Text = "古弟私廚 資訊系統 首頁   －　工程人員模式 (非工程人員請勿使用)    [使用者: " + USER_name + "] 權限:最高";
            }
            else if (boss == "True")//老闆權限
            {

                this.Text = "古弟私廚 資訊系統 首頁   －　管理者模式 (非授權者請勿使用)    [使用者: " + USER_name + "] 權限:高"; ;

            }

            //String Today =  (DateTime.Now.Year - 1911).ToString()+"/"+DateTime.Now.Month+"/"+DateTime.Now.Day;
            //String Yesterday  = (DateTime.Now.Year - 1911).ToString() + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Day-1);
            //String Time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

              if (DateTime.Now.Hour == 0 || DateTime.Now.Hour == 1)
                {
                    Search_OnDuty(this.USER_name, (DateTime.Now.Year - 1911).ToString() + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Day-1)); //搜尋昨天
                    button_change((DateTime.Now.Year - 1911).ToString() + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Day-1),DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                }
                else
                {
                    Search_OnDuty(this.USER_name, (DateTime.Now.Year - 1911).ToString()+"/"+DateTime.Now.Month+"/"+DateTime.Now.Day); //搜尋今天
                    button_change((DateTime.Now.Year - 1911).ToString()+"/"+DateTime.Now.Month+"/"+DateTime.Now.Day,DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                }
            
        }
        private void button_change(String Date,String Clock)//上班按鈕提醒 這邊可以設定開三段班
        {
            switch (OnD_Date.Count)
                    {
                        case 0:
                            Punch.Text = "打卡上班";
                          
                            break;
                        case 1:
                            if (OnD_Time.Count == 1 && OffD_Time[0].ToString() == "")
                            {
                                Punch.Text = "打卡下班";
                               
                            }
                            else if (OnD_Time.Count == 1 && OffD_Time[0].ToString() != "")
                            {
                                Punch.Text = "打卡加班";
                            }
                            break;
                        case 2:
                            if (OnD_Time.Count == 2 && OffD_Time[1].ToString() == "")
                            {

                                Punch.Text = "打卡下班";
                            }
                            else if (OnD_Time.Count == 2 && OffD_Time[1].ToString() != "")
                            {
                                Punch.Text = "今日上班\r\n次數已滿";
                                Punch.Enabled = false;
                            }
                            break;
                        case 3: //目前設定是打開兩次
                          
                                Punch.Text = "今日上班\r\n次數已滿";
                                Punch.Enabled = false;
                                break;
                        case 4: 

                                Punch.Text = "今日上班\r\n次數已滿";
                                Punch.Enabled = false;
                                break;

                    }
        }

        private void Customer_System_Click(object sender, EventArgs e)
        {

            Customer_Form CF = new Customer_Form(this.readwrite, this.engineer, this.boss, this.USER_name);
            this.Hide();
            CF.Show(this);
            CF.BringToFront();

        }

        private void index_Form_Load(object sender, EventArgs e)
        {
            timer_clock.Interval = 100;
            timer_clock.Enabled = true;

        }

        private void timer_clock_Tick(object sender, EventArgs e)
        {
            label_clock.Text = DateTime.Now.ToString();
        }

        private void Punch_Click(object sender, EventArgs e)
        {
            /*
             隔夜的問題以解決 現在目前要把隔夜標籤加入 備註
             */
            String Today =  (DateTime.Now.Year - 1911).ToString()+"/"+DateTime.Now.Month+"/"+DateTime.Now.Day;
            String Yesterday  = (DateTime.Now.Year - 1911).ToString() + "/" + DateTime.Now.Month + "/" + (DateTime.Now.Day-1);
            String Time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

              

              

                if (DateTime.Now.Hour == 0 || DateTime.Now.Hour == 1)
                {
                    Search_OnDuty(this.USER_name, Yesterday); //搜尋昨天
                    Punch_YorT(Yesterday, Time);
                }
                else
                {
                    Search_OnDuty(this.USER_name, Today); //搜尋今天
                    Punch_YorT(Today, Time);
                }
                 




        }
        private void Punch_YorT(String Y_T_Day,String Time)
        {
             switch (OnD_Date.Count)
                    {
                        case 0:
                            Insert_punch(this.USER_name, Y_T_Day, Time);
                            MessageBox.Show("打卡上班成功" + "\r\n" + "上班時間 : " + Time, "成功訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Punch.Text = "打卡下班";
                            break;
                        case 1:
                            if (OnD_Time.Count == 1 && OffD_Time[0].ToString() == "")
                            {
                                Update_OffDuty_punch(this.USER_name, Time, Y_T_Day, OnD_Time[0].ToString(), Check_punch_time(OnD_Time[0].ToString(), Time));
                                MessageBox.Show("打卡下班成功" + "\r\n"
                                                + "下班時間 : " + Time + "\r\n"
                                                + "此區段上班時數為 : "
                                                + Transform_Min2Hour(Check_punch_time(OnD_Time[0].ToString(), Time)), "成功訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (OnD_Time.Count == 1 && OffD_Time[0].ToString() != "")
                            {
                                Insert_punch(this.USER_name, Y_T_Day, Time);
                                MessageBox.Show("打卡上班成功" + "\r\n" + "上班時間 : " + Time, "成功訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            Punch.Text = "打卡加班";
                            break;
                        case 2:
                            if (OnD_Time.Count == 2 && OffD_Time[1].ToString() == "")
                            {
                                Update_OffDuty_punch(this.USER_name, Time, Y_T_Day, OnD_Time[1].ToString(), Check_punch_time(OnD_Time[1].ToString(), Time));
                                MessageBox.Show("打卡下班成功" + "\r\n"
                                                + "下班時間 : " + Time + "\r\n"
                                                + "此區段上班時數為 : " + Transform_Min2Hour(Check_punch_time(OnD_Time[1].ToString(), Time)), "成功訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Punch.Text = "今日上班\r\n次數已滿";
                            }
                            else if (OnD_Time.Count == 2 && OffD_Time[1].ToString() != "")
                            {
                                Punch.Enabled = false;
                                MessageBox.Show("當日只能打卡兩次" + "\r\n\r\n今日上班時段已滿 : \r\n" + OnD_Time[0] + " ~ " + OffD_Time[0] + "\r\n"
                                                                                                   + OnD_Time[1] + " ~ " + OffD_Time[1] + "\r\n"
                                                                                           , "失敗訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            break;

                    }
        }
        public String Transform_Min2Hour(int Total)
        {
            String Transform = "";
            String Hour = "";
            String Min = "";        
            Hour = (Total / 60).ToString();
            Min = (Total % 60).ToString();
            Transform = Hour + "小時 " + Min + "分鐘";
            return Transform;
        }
        public int Check_punch_time(String On_duty,String Off_duty) 
        {
            String[] On_duty_split = On_duty.Split(':');
            String[] Off_Duty_splot = Off_duty.Split(':');
            List<int> On_duty_int = new List<int>();
            List<int> Off_Duty_int = new List<int>();
            int Hour=0;
            int Min=0;
            int total=0;

            foreach(String On  in On_duty_split)
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
            for(int i=0;i<On_duty_int.Count;i++)
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
        private void Insert_punch(String table,String date,String OnD_time) 
        {
            String insert_OnDutyTime = "INSERT INTO " + table + " (name,OnDutyDate,OnDutyTime,[Check]) VALUES('" + this.USER_name + "','" + date + "','" + OnD_time + "','未審核上班')";
            // String insert_kudydb_newAcc =  "INSERT INTO kudydb (name,phone,BD) VALUES('"+textBox_NewAcc_name.Text+"','"+textBox_NewAcc_phone.Text+"','"+textBox_NewAcc_BD.Text+"')";

            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = insert_OnDutyTime;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();


            //String insert_kudydb_newAcc = "INSERT INTO kudydb (name,phone,BD) VALUES('" + textBox_NewAcc_name.Text + "','" + textBox_NewAcc_phone.Text + "','" + textBox_NewAcc_BD.Text + "')";
            //conn.Open();
            //cmd.Connection = conn;
            //cmd.CommandText = insert_kudydb_newAcc;
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }
        private void Update_OffDuty_punch(String Table,String OffD_time,String OnDutyDate,String OnDutyTime,int S_Total)
        {
            String SQL_upphone = "UPDATE " + Table + " SET OffDutyTime = '" + OffD_time + "', Single_total = '" + S_Total.ToString() + "', [Check] = '" + "未審核上班" + "'" + " WHERE OnDutyDate = '" + OnDutyDate + "' AND OnDutyTime = '" + OnDutyTime + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_upphone;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();
        }      
        private void Search_OnDuty(String user,String Date)
        {
            OnD_Time.Clear();
            OffD_Time.Clear();
            OnD_Date.Clear();

            String SQL_CMD = "Select OnDutyDate,OnDutyTime,OffDutyTime From " + user + " WHERE OnDutyDate = '" + Date + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                OnD_Date.Add(dr[0]);
                OnD_Time.Add(dr[1]);
                OffD_Time.Add(dr[2]);
            }
            FL_OLE.conn.Close();

        }

        private void information_Click(object sender, EventArgs e)
        {
            View_Work VW = new View_Work(this.USER_name);
            this.Hide();
            VW.Show(this);
            VW.BringToFront();

        }

        private void Audit_work_button_Click(object sender, EventArgs e)
        {
            Check_Form CF = new Check_Form();
            this.Hide();
            CF.Show(this);
            CF.BringToFront();
        }

        private void index_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
    }
}
