using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;
using excel = Microsoft.Office.Interop.Excel;
 




namespace Kudy
{
    public partial class Check_Form : Form
    {

            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader dr;
            Form_Login FL_OLE = new Form_Login();
            int Current_number;
            ArrayList name = new ArrayList();
            ArrayList OnDutyDate = new ArrayList();
            ArrayList OnDutyTime = new ArrayList();
            ArrayList OffDutyTime = new ArrayList();
            ArrayList Single_total = new ArrayList();
            ArrayList Check = new ArrayList();
            ArrayList Input_Employee_2combo = new ArrayList();
            List<int> YYYYMMDD = new List<int>();

        public Check_Form()
        {
            
            InitializeComponent();
            Load_Employee();
            comboBox_month.Text = DateTime.Now.Month.ToString();
            label_year.Text = "今年是民國 " + (DateTime.Now.Year - 1911).ToString()+"年";
            checkBox_check_all.Enabled = false;
            dateTimePicker_lose_punch.CustomFormat = "yyyy/ MM/ dd";
            label13.Text = "※注意 :　時間格式為 HH:MM \r\n 隔日就打 0:MM 或是 24:MM";
            
            
        }
        private void 離開ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
        private void Load_Employee()
        {
            Select_All_Load_Employee();

        }
        private void Select_All_Load_Employee()
        {
            Input_Employee_2combo.Clear();
           
            String SQL_CMD = "Select name From staff_account" ;
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Input_Employee_2combo.Add(dr[0]);
                comboBox_Employee.Items.Add(dr[0]);

            }
            FL_OLE.conn.Close();

            
        }
        private void set_DGV_check(ArrayList check)
        { 
            
        }

        private void comboBox_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }
        private void Show_DGV(String Date)
        {
            DataGridViewRowCollection DGVC = dataGridView_check.Rows;
            DGVC.Clear();
            String SQL_CMD = "Select name,OnDutyDate,OnDutyTime,OffDutyTime,Single_total,Check,Remark From " + comboBox_Employee.SelectedItem + " WHERE OnDutyDate LIKE '" + Date + comboBox_month.SelectedItem + "/%'";
            ArrayList Remark = new ArrayList();
            name.Clear();
            OnDutyDate.Clear();
            OnDutyTime.Clear();
            OffDutyTime.Clear();
            Single_total.Clear();
            Check.Clear();

            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_CMD;
            
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr[0]);
                OnDutyDate.Add(dr[1]);
                OnDutyTime.Add(dr[2]);
                OffDutyTime.Add(dr[3]);
                Single_total.Add(dr[4]);
                Check.Add(dr[5]);
                Remark.Add(dr[6]);
                //DGVC.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }
            FL_OLE.conn.Close();
            for (int i = 0; i < Check.Count; i++)
            {
                if (Check[i].ToString() == "未審核上班" || Check[i].ToString() == "")
                {
                    DGVC.Add(name[i], OnDutyDate[i], OnDutyTime[i], OffDutyTime[i], Single_total[i], "未審核上班",Remark[i].ToString());
                }
                else if (Check[i].ToString() == "審核通過")
                {
                    DGVC.Add(name[i], OnDutyDate[i], OnDutyTime[i], OffDutyTime[i], Single_total[i], "審核通過",Remark[i].ToString());
                }
            }
        }

        private void comboBox_Employee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (checkBox_last_year.Checked == true)//去年
            {               
                String Date_send = (DateTime.Now.Year - 1912).ToString() + "/";
                Show_DGV(Date_send);
                dataGridView_check.Enabled = true;
            }
            else //今年
            {
                String Date_send = (DateTime.Now.Year - 1911).ToString() + "/";
                Show_DGV(Date_send);
                button_new_punch.Enabled = true ;//新增打卡按鈕
                checkBox_check_all.Enabled = true;
                tabControl2.TabPages[1].Text = comboBox_Employee.SelectedItem + " 補打卡";
                dataGridView_check.Enabled = true;
                
            }
        }

        private void comboBox_month_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_Employee.Text == "選擇員工")
            {
                MessageBox.Show("未選擇員工，選擇員工", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            else
            {
                 if (checkBox_last_year.Checked == true)//去年
                {

                    String Date_send = (DateTime.Now.Year - 1912).ToString() + "/";
                    Show_DGV(Date_send);
                }
                else //今年
                {
                    String Date_send = (DateTime.Now.Year - 1911).ToString() + "/";
                    Show_DGV(Date_send);
                }
            }


        }
        

        private void sql_update(String Table, String OffD_time, int S_Total, String OnDutyDate, String OnDutyTime)
        {
            String SQL_upphone = "UPDATE " + Table + " SET OffDutyTime = '" + OffD_time + "', Single_total = '"
                                           + S_Total.ToString() + "', [Check] = '" + "未審核上班" + "'" 
                                           + " WHERE OnDutyDate = '" + OnDutyDate + "' AND OnDutyTime = '" + OnDutyTime + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_upphone;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();

        }

        private void dataGridView_check_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            

            int R = e.RowIndex;;
            int C = e.ColumnIndex;
            textBox1.Text += "直向 : " + R.ToString() + " 橫向 : " + C.ToString() + " 輸入 : " + dataGridView_check.CurrentCell.Value + "\r\n";

            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dataGridView_check.Rows[R].Cells[C+2];//動態抓儲存格的值

            String Data = cell.Value.ToString();
            textBox1.Text = Data+"  Test"+R+" "+C;

            if (C == 3)
            {
                try
                {
                    int total = FL_OLE.Check_punch_time(OnDutyTime[R].ToString(), dataGridView_check.CurrentCell.Value.ToString());
                    if (total==0)
                    {
                        sql_update_offDuty_check(name[R].ToString(),
                                            dataGridView_check.CurrentCell.Value.ToString(),
                                            total,
                                            OnDutyDate[R].ToString(), OnDutyTime[R].ToString(), "未審核上班");//cell.Value.ToString()
                    }
                    else if (total>0)
                    {
                        sql_update_offDuty_check(name[R].ToString(),
                                            dataGridView_check.CurrentCell.Value.ToString(),
                                            total,
                                            OnDutyDate[R].ToString(), OnDutyTime[R].ToString(), "審核通過");//cell.Value.ToString()
                    }

                }
                catch (Exception ex)
                {
                    sql_update_simple(name[R].ToString(), OnDutyDate[R].ToString(), OnDutyTime[R].ToString(), "未審核上班");
                    MessageBox.Show("1. 請輸入時間 時間格式 時:分 (請用半形)\r\n2. 請確認是否有輸入其他不合法符號", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            try
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    textBox1.Text += tabControl2.SelectedIndex; 
                    Refresh_DGV(comboBox_month.SelectedItem.ToString());
                }
                else if (tabControl2.SelectedIndex == 1)
                {
                    textBox1.Text += tabControl2.SelectedIndex; 
                    Refresh_DGV(YYYYMMDD[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("輸入完資料請按 鍵盤 Enter ", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            //編輯完之後 update 然後重新刷新 查詢條件代入
            //中間要穿插 計算 分鐘數 然後刷新 單日時數資料欄位
            //然後審查也是要寫
            // ArrayList OnDutyDate = new ArrayList();
            //ArrayList OnDutyTime = new ArrayList();
            //ArrayList OffDutyTime = new ArrayList();
            //ArrayList Single_total = new ArrayList();
            //ArrayList Check = new ArrayList();
        }
        private void Refresh_DGV(String Month)
        {
            
            DataGridViewRowCollection DGVC1 = dataGridView_check.Rows;
            DGVC1.Clear();
                if (checkBox_last_year.Checked == true)//去年
                {
                    String Date_send = (DateTime.Now.Year - 1912).ToString() + "/";
                    String SQL_CMD = "Select name,OnDutyDate,OnDutyTime,OffDutyTime,Single_total,Check,Remark From " + comboBox_Employee.SelectedItem + " WHERE OnDutyDate LIKE '" + Date_send + comboBox_month.SelectedItem + "/%'";//Month
                    
                    FL_OLE.conn.Open();
                    cmd.Connection = FL_OLE.conn;
                    cmd.CommandText = SQL_CMD;

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DGVC1.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5],dr[6]);
                    }
                    FL_OLE.conn.Close();
                    
                }
                else //今年
                {
                    String Date_send = (DateTime.Now.Year - 1911).ToString() + "/";
                    String SQL_CMD = "Select name,OnDutyDate,OnDutyTime,OffDutyTime,Single_total,Check,Remark From " + comboBox_Employee.SelectedItem + " WHERE OnDutyDate LIKE '" + Date_send + comboBox_month.SelectedItem + "/%'";

                    FL_OLE.conn.Open();
                    cmd.Connection = FL_OLE.conn;
                    cmd.CommandText = SQL_CMD;

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DGVC1.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5],dr[6]);
                    }
                    FL_OLE.conn.Close();
                                      
                }
        }

        
        private void sql_update_offDuty_check(String Table, String OffD_time, int S_Total, String OnDutyDate, String OnDutyTime,String Check)
        {
            String SQL_upphone = "UPDATE " + Table + " SET OffDutyTime = '" + OffD_time + "', Single_total = '"
                                           + S_Total.ToString() + "', [Check] = '" + Check + "'"
                                           + " WHERE OnDutyDate = '" + OnDutyDate + "' AND OnDutyTime = '" + OnDutyTime + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_upphone;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();

        }
        private void sql_update_simple(String Table, String OnDutyDate, String OnDutyTime, String Check)//專門更新審核表格
        {

            String SQL_upphone = "UPDATE " + Table + " SET [Check] = '" + Check + "'"
                                           + " WHERE OnDutyDate = '" + OnDutyDate +"'"
                                           + " AND OnDutyTime = '" + OnDutyTime + "'";
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            cmd.CommandText = SQL_upphone;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();

        }

        private void dataGridView_check_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Current_number = dataGridView_check.CurrentRow.Index;
            //textBox1.Text += Current_number.ToString() + "\r\n";
            //button_update.Enabled = true;
            //dataGridView_check.CurrentCell.Value =

            

            if (e.ColumnIndex == 5)
            {
                int R = e.RowIndex;
                int C = e.ColumnIndex;
                DataGridViewTextBoxCell OnDutyDate_cell = (DataGridViewTextBoxCell)dataGridView_check.Rows[R].Cells[1];//動態抓儲存格的值
                DataGridViewTextBoxCell OnDutyTime_cell = (DataGridViewTextBoxCell)dataGridView_check.Rows[R].Cells[2];//動態抓儲存格的值

                switch (dataGridView_check.CurrentCell.Value.ToString())
                {
                    case "未審核上班":
                        textBox1.Text = "審核通過";
                        dataGridView_check.CurrentCell.Value = "審核通過";
                        textBox1.Text = OnDutyDate_cell.Value.ToString() + OnDutyTime_cell.Value.ToString() + " " + R + " , " + C;
                        sql_update_simple(comboBox_Employee.SelectedItem.ToString(), OnDutyDate_cell.Value.ToString(), OnDutyTime_cell.Value.ToString(), "審核通過");

                        break;
                    case "審核通過":
                         dataGridView_check.CurrentCell.Value = "未審核上班";
                         textBox1.Text = OnDutyDate_cell.Value.ToString() + OnDutyTime_cell.Value.ToString() + " " + R + " , " + C;
                         sql_update_simple(comboBox_Employee.SelectedItem.ToString(), OnDutyDate_cell.Value.ToString(), OnDutyTime_cell.Value.ToString(), "未審核上班");

                        break;
                }
            } 

        }

        private void dataGridView_check_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void button_new_punch_Click(object sender, EventArgs e)
        {
            YYYYMMDD.Clear();
            String[] split = new string[]{"年","月","日"};
            String[] split_DateTime = dateTimePicker_lose_punch.Text.Split(split,StringSplitOptions.RemoveEmptyEntries);           
            foreach (String s in split_DateTime)
            {
                YYYYMMDD.Add(Int32.Parse(s));              
            }
            int con_Y = YYYYMMDD[0] - 1911;
            String YYYMMDD = con_Y.ToString() + "/" + YYYYMMDD[1].ToString() +"/"+ YYYYMMDD[2].ToString();

            

            //要加入檢查單日的打卡次數
           
                DialogResult DR = MessageBox.Show("確定新增?\r\n" + YYYMMDD + "　　姓名: " + comboBox_Employee.SelectedItem.ToString(), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (DR == DialogResult.OK)
                {
                    if (textBox_On_Hour.Text.Length != 0 && textBox_On_Min.Text.Length != 0 && textBox_Off_Hour.Text.Length == 0 && textBox_Off_Min.Text.Length == 0)//檢查空格
                    {
                        String merge_On_duty = textBox_On_Hour.Text + ":" + textBox_On_Min.Text;
                        insert_SQL(comboBox_Employee.SelectedItem.ToString(), YYYMMDD, merge_On_duty, "", "", "未審核上班");
                        MessageBox.Show("　　姓名: " + comboBox_Employee.SelectedItem.ToString() + "\r\n　　日期: " + YYYMMDD + "\r\n上班時間: " + merge_On_duty + "\r\n下班時間: 尚未打卡下班", "新增成功", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        Refresh_losePunch(YYYMMDD, merge_On_duty);
                    }
                    else if (textBox_On_Hour.Text.Length != 0 && textBox_On_Min.Text.Length != 0 && textBox_Off_Hour.Text.Length != 0 && textBox_Off_Min.Text.Length != 0)
                    {

                        //Check_punch_time(String On_duty, String Off_duty)

                        String merge_On_duty = textBox_On_Hour.Text + ":" + textBox_On_Min.Text;
                        String merge_Off_duty = textBox_Off_Hour.Text + ":" + textBox_Off_Min.Text;

                        int total = FL_OLE.Check_punch_time(merge_On_duty, merge_Off_duty);
                        textBox1.Text = total.ToString();
                        insert_SQL(comboBox_Employee.SelectedItem.ToString(), YYYMMDD, merge_On_duty, merge_Off_duty, total.ToString(), "審核通過");
                        MessageBox.Show("　　姓名: " + comboBox_Employee.SelectedItem.ToString() + "\r\n　　日期: "
                                                 + YYYMMDD + "\r\n上班時間: " + merge_On_duty + "\r\n下班時間: " + merge_Off_duty + "\r\n單筆時數: " + FL_OLE.change2Hour(total), "新增成功", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                        Refresh_losePunch(YYYMMDD, merge_On_duty);
                    }
                    else
                    {

                    }
                }
            

        }
        private void insert_SQL(String table,String Date,String On_Duty,String Off_Duty,String Total,String Check)
        {
            FL_OLE.conn.Open();
            cmd.Connection = FL_OLE.conn;
            String insert_meal_newC = "INSERT INTO " + table + " (name,OnDutyDate,OnDutyTime,OffDutyTime,Single_total,[Check],Remark) VALUES('" + table + "','" + Date + "','" + On_Duty + "','" + Off_Duty + "','" + Total + "','" + Check + "','補打卡" + "')";
            cmd.CommandText = insert_meal_newC;
            cmd.ExecuteNonQuery();
            FL_OLE.conn.Close();
        }
        private void Refresh_losePunch(String Date, String OndutyTime)
        {
            //ArrayList name = new ArrayList();
            //ArrayList OnDutyDate = new ArrayList();
            //ArrayList OnDutyTime = new ArrayList();
            //ArrayList OffDutyTime = new ArrayList();
            //ArrayList Single_total = new ArrayList();
            //ArrayList Check = new ArrayList();
            ArrayList remark = new ArrayList();
            name.Clear();
            OnDutyDate.Clear();
            OnDutyTime.Clear();
            OffDutyTime.Clear();
            Single_total.Clear();
            Check.Clear();
            remark.Clear();
           

              DataGridViewRowCollection DGVC = dataGridView_check.Rows;
              DGVC.Clear();
              
              String SQL_CMD = "Select name,OnDutyDate,OnDutyTime,OffDutyTime,Single_total,[Check],Remark From " + comboBox_Employee.SelectedItem + " WHERE OnDutyDate LIKE '" + Date + "' AND OnDutyTime='" + OndutyTime + "'";
                    
              FL_OLE.conn.Open();
              cmd.Connection = FL_OLE.conn;
              cmd.CommandText = SQL_CMD;

              dr = cmd.ExecuteReader();
              while (dr.Read())
              {
                  textBox1.Text = dr[6].ToString();
                  name.Add(dr[0]);
                  OnDutyDate.Add(dr[1]);
                  OnDutyTime.Add(dr[2]);
                  OffDutyTime.Add(dr[3]);
                  Single_total.Add(dr[4]);
                  Check.Add(dr[5]);
                  remark.Add(dr[6]);
                  DGVC.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
              }
                FL_OLE.conn.Close();

        }
        private void 切換到顧客系統ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_check_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1)
            {
                MessageBox.Show("禁止在 補打卡頁面編輯", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = tabControl2.SelectedIndex.ToString();
            //textBox1.Text = tabControl2.TabIndex.ToString();
            if (tabControl2.TabIndex == 1)
            {
                dataGridView_check.Enabled = false;
            }
            else if (tabControl2.TabIndex == 0)
            {
                dataGridView_check.Enabled = true;
            }
        }

        private void 輸出當月員工時數表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("是否要輸出上個月員工時數表 ?", "詢問", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Dr.Equals(DialogResult.OK))
            {
                SaveFileDialog saveDia = new SaveFileDialog();
                saveDia.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveDia.FileName = (DateTime.Now.Month - 1).ToString() + "月員工薪資與上班報表";
                saveDia.Filter = "*.xlsx|*.xlsx";
                if (saveDia.ShowDialog() != DialogResult.OK) return;
                excel.Application xls = null;
                try
                {
                    xls = new excel.Application();
                    excel.Workbook book = xls.Workbooks.Add();
                    excel.Worksheet sheet = (excel.Worksheet)book.Worksheets.Item[1];
                    DataGridViewRowCollection DGVC = dataGridView_check.Rows;
                    DGVC.Clear();
                    search_single_staff(sheet);//搜尋人
                    book.SaveAs(saveDia.FileName);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    dataGridView_check.Enabled = false;
                    comboBox_Employee.Text = "選擇員工";
                    xls.Quit();
                }







                //這邊近來Input_Employee_2combo 不用清掉 因為就是要上面Form inital的值
              
                //搜尋當年當月的所以上班時數
                //計算小時
                //存入EXCEL
                //
            }
        }
        private void search_single_staff(excel.Worksheet sheet)
        {
            DataGridViewRowCollection DGVC = dataGridView_check.Rows;
            ArrayList staff_name = new ArrayList();
            ArrayList staff_OnDuty_Date = new ArrayList();
            ArrayList staff_OnDuty_Time = new ArrayList();
            ArrayList staff_OffDuty_Time = new ArrayList();
            ArrayList staff_check = new ArrayList();
            ArrayList staff_remark = new ArrayList();
            ArrayList staff_single = new ArrayList();
            ArrayList all_time = new ArrayList();
            ArrayList all_name = new ArrayList();
            for (int i = 0; i < Input_Employee_2combo.Count; i++)
            {
                staff_single.Clear();
                String SQL_CMD = "Select * From " + Input_Employee_2combo[i].ToString()+ " WHERE OnDutyDate LIKE '" + (DateTime.Now.Year-1911).ToString()+"/"
                                                                                                                    + (DateTime.Now.Month-1) + "/%'";
                List<int> count_time = new List<int>();
                int total_single = 0;
                FL_OLE.conn.Open();
                cmd.Connection = FL_OLE.conn;
                cmd.CommandText = SQL_CMD;

                dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {                    
                    staff_name.Add(dr[1]);
                    staff_OnDuty_Date.Add(dr[2]);
                    staff_OnDuty_Time.Add(dr[3]);
                    staff_OffDuty_Time.Add(dr[4]);
                    staff_single.Add(dr[5]);
                    staff_check.Add(dr[6]);
                    staff_remark.Add(dr[7]);

                 // DGVC.Add(Input_Employee_2combo[i].ToString(), "當月無上班資料", "當月無上班資料", "當月無上班資料", "當月無上班資料", "當月無上班資料", "當月無上班資料");

                    DGVC.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }
                FL_OLE.conn.Close();
          
                    for (int j = 0; j < staff_single.Count; j++)
                    {
                        if (staff_single[j].ToString() == "")
                        {
                            count_time.Add(0);
                        }
                        else
                        {
                            count_time.Add(Int32.Parse(staff_single[j].ToString()));
                        }
                    }
                    for (int k = 0; k < count_time.Count; k++)
                    {
                        if (staff_check[k].ToString() != "未審核上班")
                        {
                            total_single += count_time[k];
                        }
                    }
                    all_name.Add(Input_Employee_2combo[i].ToString());
                    all_time.Add("[" + (DateTime.Now.Month - 1) + "月] 時數 : " + FL_OLE.change2Hour(total_single));
                    //DGVC.Add("", "", "", "", "", "" ,Input_Employee_2combo[i].ToString() +"[" +(DateTime.Now.Month - 1) + "月] 時數 = "+FL_OLE.change2Hour(total_single));
                   


                    
              }
            //DGVC.Add("", "", "", "員工名字", "總時數統計", "", "");

            sheet.Cells[1, 9] = "員工名字";
            sheet.Cells[1, 10] = "總時數統計";

            for (int i = 0; i < all_time.Count; i++)
            {
                sheet.Cells[i + 2, 9] = all_name[i].ToString();
                sheet.Cells[i + 2, 10] = all_time[i].ToString();
                //DGVC.Add("", "", "", all_name[i].ToString(), all_time[i].ToString(), "", "");
            }
            sheet.Cells[all_time.Count + 2, 10] = "※注意 顯示未審核上班 不列入總時數統計";
            //DGVC.Add("", "", "", "", "※注意 顯示未審核上班 不列入總時數統計", "", "");

            sheet.Cells[1, 1] = "姓名";
            sheet.Cells[1, 2] = "上班日期";
            sheet.Cells[1, 3] = "上班時間";
            sheet.Cells[1, 4] = "下班時間";
            sheet.Cells[1, 5] = "單日上班時數(分鐘)";
            sheet.Cells[1, 6] = "上班審核";
            sheet.Cells[1, 7] = "備註";

            for (int l = 0; l < DGVC.Count; l++)
            {
                for (int j = 0; j < dataGridView_check.Columns.Count; j++)
                {
                    string value = dataGridView_check[j, l].Value.ToString();
                    sheet.Cells[l + 2, j + 1] = value;
                }
            }

            sheet.Columns.EntireColumn.AutoFit();
            
              
        }

        private void Check_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }

        private void 權限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            permission PS = new permission();
            PS.Show();
            PS.TopMost = true;
        }

        private void 說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" 員工班卡管理頁面說明:\r\n\r\n"
                                                      + "1.幫員工補打卡上班或是打卡下班\r\n\r\n"
                                                      + "2.審核是每個月要發薪水時審核員工班表 點擊審查 可以更改員工單日\r\n"
                                                      + "　上班狀態請務必確實審查 因為未審核上班最後計算時數會 不列入計算!\r\n\r\n"
                                                      + "3.補打卡頁面的格子 數字請打半形123 請勿打全形數字 １２３\r\n\r\n"
                                                      + "4.輸出班表前 請先確認每個員工的 班表是不是都是正確審核\r\n"
                                                      + "　請在每個月的1號在輸出因為設計是自動偵測前一個月，所以要輸出\r\n"
                                                      + "　一月請在二月一號輸出，不然會顯示去年十二月班表統計。"
                                                      , "授權管理 說明", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}