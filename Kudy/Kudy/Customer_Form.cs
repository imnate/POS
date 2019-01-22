using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kudy
{
    public partial class Customer_Form : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\gogx1\Desktop\Github\POS_KudyRestaurant\kudydb.accdb;");//本機端
        //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\kudydb.accdb;");//古弟私廚路徑
        //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Imnate\Desktop\kudydb.accdb;");
        //new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ImNaTE\Desktop\kudydb.accdb;");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet ds;

        String show_customer_LbSelected = "";
        ArrayList insert_newC_meal = new ArrayList();
        ArrayList phone = new ArrayList();//arraylist_phone
        ArrayList id = new ArrayList();//arraylist_id
        ArrayList meals = new ArrayList();//arraylist_meals
        ArrayList Date = new ArrayList();
        ArrayList nop = new ArrayList();
        ArrayList remark = new ArrayList();
        String path_ole = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\gogx1\Desktop\Github\POS_KudyRestaurant\kudydb.accdb;";//本機路徑
        //String path_ole = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\kudydb.accdb;";//古弟私廚路徑
        int count_down_time = 1;//計算備註換行次數
        String search_keyword = "";

        private String readwrite_R;
        private String engineer_R;
        private String boss_R;
        private String Acc_name_R;

        public Customer_Form(String readwrite ,String engineer,String boss,String Acc_name)
        {
            this.readwrite_R = readwrite;
            this.engineer_R = engineer;
            this.boss_R = boss;
            this.Acc_name_R = Acc_name;
            
            InitializeComponent();
            button1.Enabled = false;
            progressBar1.Visible = false;
            tabControl_Meal.Enabled = false;
            //////////權限設定/////////
            TabPage tb_newC = tabControl1.TabPages[1];
            TabPage tb_engineer = tabControl1.TabPages[2];            
            TabPage tb_test_textbox = tabControl_Meal.TabPages[0];          
            TabPage tb_new =  tabControl_Meal.TabPages[3];
           // textBox_search.Text = engineer;
            tabControl_Meal.TabPages.Remove(tb_test_textbox);
           


            if (readwrite == "False" && engineer == "False" && boss=="False")
            {
                tabControl1.TabPages.Remove(tb_engineer);
                tabControl1.TabPages.Remove(tb_newC);
                tabControl_Meal.TabPages.Remove(tb_new);
                //tabControl_Meal.TabPages.Remove(tb_text);
                this.Text = "古弟私廚 客戶系統  (一般) －　[使用者: " + Acc_name + "]"; 
            }
            else if (engineer == "True")
            {
                ToolStripMenuItem_toolBar.Visible = true;
                
                //tabControl_Meal.TabPages.Insert(3, tb_new);
                //tabControl_Meal.TabPages.Insert(1, tb_test_DGV);
                menuStrip_all.BackColor = Color.Red;

                this.Text = "古弟私廚 客戶系統   －　工程人員模式 (非工程人員請勿使用)    [使用者: " + Acc_name + "]"; 
            }
            else if (boss == "True")
            {
                //tabControl_Meal.TabPages.Remove(tb_text);
                tabControl1.TabPages.Remove(tb_engineer);
                this.Text = "古弟私廚 客戶系統   －　管理者模式 (非授權者請勿使用)    [使用者: " + Acc_name + "]"; ;

            }
            else if (readwrite =="True")
            {
                //tabControl_Meal.TabPages.Remove(tb_text);
                tabControl1.TabPages.Remove(tb_engineer);
            }
           
           

            //////////權限設定↑/////////


            //WindowState = FormWindowState.Maximized;
           
            
            textBox_Remark_remark.ImeMode = System.Windows.Forms.ImeMode.OnHalf;
            textBox_remark.ImeMode = System.Windows.Forms.ImeMode.OnHalf;
            textBox_search.ImeMode = System.Windows.Forms.ImeMode.OnHalf;
            textBox_new_meal.ImeMode = System.Windows.Forms.ImeMode.OnHalf;
           
            dataGridView_show_info.Rows.Clear();


            

        }
        private void Create_table(String table)//新增meal table
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "CREATE TABLE " + table +
                              "([ID] NUMBER NOT NULL," +
                              "[Meal] VARCHAR(100) NOT NULL," +
                              "[name] VARCHAR(40) NOT NULL," +
                              "[Date] VARCHAR(40) NOT NULL," +
                              "[System_Time] VARCHAR(100) NOT NULL," +
                              "[nop] VARCHAR(40) NOT NULL)";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void Create_staffinfo(String table_name) 
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "CREATE TABLE " + table_name +
                              "([EID] AUTOINCREMENT NULL," +
                              "[account] VARCHAR(40) NULL," +
                              "[name] VARCHAR(40) NULL," +
                              "[sex] VARCHAR(40) NULL," +
                              "[cellphone] VARCHAR(40) NULL," +
                              "[Bday] VARCHAR(40) NULL," +
                              "[school] VARCHAR(40) NULL," +
                              "[department] VARCHAR(40) NULL,"+
                              "[TakeOfficeDate] VARCHAR(40) NULL," +
                              "[LeaveOfficeDate] VARCHAR(40) NULL)" ;
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }
      

        private void 資料庫簡單化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

            Create_table("meal");//新增meal表單
            Create_staffinfo("staff_info");//員工資料

            progressBar1.Visible = true;

            textBox1.Text += "開始";

            //先建立好所有人的名字進入arraylist裡面
            String SQL_search_name = "SELECT name FROM kudydb;";
            ArrayList Auto_name = new ArrayList();//用來合併的名字

            OleDbDataReader dr1;

            //一開始表格
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = SQL_search_name;
            dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                Auto_name.Add(dr1[0].ToString());

            }
            conn.Close();

            //再來利用arraylist裡面名字來當合併的搜尋
            int c_del = 0;
            int c_insert = 0;
           
            progressBar1.Minimum = 1;
            
            progressBar1.Step = 1;
            for (int i = 0; i < Auto_name.Count; i++)
            {
                progressBar1.Maximum = Auto_name.Count;
                textBox1.Text = (i + 1).ToString() + " / " + Auto_name.Count.ToString() + " ";
                
                
                //progressBar1.Maximum = Auto_name.Count; //原廠bar
                
               
                OleDbDataReader dr2;
                ArrayList Auto_2meal_id = new ArrayList();
                ArrayList Auto_2meal_meal = new ArrayList();


                progressBar1.PerformStep();
                
                conn.Open();

               // String aa = "103/12/12";//之後要寫擷取日期機制             
                cmd.Connection = conn;
                String SQL_M = "SELECT ID,meal FROM kudydb WHERE name LIKE '" + Auto_name[i] + "'";

                cmd.CommandText = SQL_M;
                dr2 = cmd.ExecuteReader();

                while (dr2.Read())
                {
                    Auto_2meal_id.Add(dr2[0]);//存 kudydb id 到 list
                    Auto_2meal_meal.Add(dr2[1]);//存 kudydb name 到 list
                }
                conn.Close();
                conn.Open();
                cmd.Connection = conn;

                for (int j = 0; j < Auto_2meal_meal.Count; j++)
                {
                    //新增
                    c_insert++;
                    cmd.CommandText = "INSERT INTO meal VALUES('" + Auto_2meal_id[0] + "','" + 
                                        DelDate(Auto_2meal_meal[j].ToString()) 
                                        + "','" + Auto_name[i] 
                                        + "','" + getDate(Auto_2meal_meal[j].ToString()) 
                                        + "','" + DateTime.Now.ToString() 
                                        + "','" + "無資料" +"')";
                    cmd.ExecuteNonQuery();
                }

                if (Auto_2meal_meal.Count > 1)//一個以上進行刪除在kudydb裡面的重複資料
                {
                    for (int k = 1; k < Auto_2meal_meal.Count; k++)
                    {
                        //刪除
                        c_del++;
                        cmd.CommandText = "DELETE FROM kudydb WHERE ID = " + Auto_2meal_id[k];
                        cmd.ExecuteNonQuery();
                    }
                }
                //更新表格 
                conn.Close();
                Auto_name.Clear();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = SQL_search_name;
                dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    Auto_name.Add(dr1[0].ToString());

                }
                conn.Close();
            }

            textBox1.Text += "完成合併 合併了: " + c_del + " 筆資料, 在meal DB 新增了:" + c_insert + " 筆資料";
            progressBar1.Step = Auto_name.Count;
            progressBar1.Enabled = false;
            label_output.Text = "完成合併\r\n合併了: " + c_del + " 筆資料, 在meal DB 新增了:" + c_insert + " 筆資料";

            progressBar1.Value = Auto_name.Count;//原廠bar
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
        private void Search()
        { //之後可以改成inner join 寫法
            String searchName_sql = "SELECT name FROM kudydb WHERE name LIKE" + "'%" + textBox_search.Text + "%'";//This SQL command is search keyword by name
            String searchPhone_sql = "SELECT name FROM kudydb WHERE phone LIKE" + "'%" + textBox_search.Text + "%'";//This SQL command is search keyword by name by phone

            search_keyword = textBox_search.Text;
            int check_num = 0;
            int i = 0;
            bool checksearch_box = int.TryParse(textBox_search.Text, out check_num);//check is num or string 
            conn.Open();
            cmd.Connection = conn;
            //textBox_Consumer_times.Text = textBox_search.Text.Length.ToString();
            if (checksearch_box == true)//check texatbox is num or string
            {
                cmd.CommandText = searchPhone_sql;//search phone
                show_customer_listbox.Items.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    show_customer_listbox.Items.Add(dr[0].ToString());
                }
            }
            else if (checkBox_special_search.Checked == true)//special search
            {
                if (textBox_search.Text.Substring(1, 1) == ",")
                {
                    String dot1 = textBox_search.Text.Substring(0, 1);
                    String dot2 = textBox_search.Text.Substring(2);
                    String searchSoundName_sql = "SELECT name FROM kudydb WHERE name LIKE '%[" + dot1 + dot2 + "]%'";
                    cmd.CommandText = searchSoundName_sql;//dot search
                    show_customer_listbox.Items.Clear();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        i++;
                        show_customer_listbox.Items.Add(dr[0].ToString());
                    }
                }
                checkBox_special_search.Checked = false;

            }
            else
            {
                cmd.CommandText = searchName_sql;//search name
                show_customer_listbox.Items.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    show_customer_listbox.Items.Add(dr[0].ToString());
                }

            }

            label_output.Text = "關鍵字: " + search_keyword + " 搜尋到 " + i.ToString() + " 筆";
            conn.Close();             
        
        }
        private void Search_button_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            
            dataGridView_show_info.Update();
            
            textBox_ShowName.Clear();
            textBox_Show_ID.Clear();
            textBox_show_meal.Clear();
            textBox_Consumer_times.Clear();
            textBox_phone.Clear();

            String searchName_sql = "SELECT name FROM kudydb WHERE name LIKE" + "'%" + textBox_search.Text + "%'";//This SQL command is search keyword by name
            String searchPhone_sql = "SELECT name FROM kudydb WHERE phone LIKE" + "'%" + textBox_search.Text + "%'";//This SQL command is search keyword by name by phone

            search_keyword = textBox_search.Text;

            int check_num = 0;
            int i = 0;
            bool checksearch_box = int.TryParse(textBox_search.Text, out check_num);//check is num or string 
            conn.Open();
            cmd.Connection = conn;
            //textBox_Consumer_times.Text = textBox_search.Text.Length.ToString();

            if (checksearch_box == true)//check texatbox is num or string
            {
                    cmd.CommandText = searchPhone_sql;//search phone
                    show_customer_listbox.Items.Clear();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        i++;
                        show_customer_listbox.Items.Add(dr[0].ToString());
                    }
            }

            else if (checkBox_special_search.Checked == true)//special search
            {

                    //if (textBox_search.Text.Substring(1, 1) == ",")//||textBox_search.Text.IndexOf(",")!=-1 修改古弟所說的要求 卡門,林
                    if (textBox_search.Text.IndexOf(",") != -1 && Date_Search_checkBox.Checked == false)
                    {
                        int dot_pos = textBox_search.Text.IndexOf(",");
                        String dot1 = textBox_search.Text.Substring(0, dot_pos);
                        String dot2 = textBox_search.Text.Substring(2);
                        String searchSoundName_sql = "SELECT name FROM kudydb WHERE name LIKE '%[" + dot1 + dot2 + "]%'";
                        cmd.CommandText = searchSoundName_sql;//dot search
                        show_customer_listbox.Items.Clear();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            i++;
                            show_customer_listbox.Items.Add(dr[0].ToString());
                        }
                       
                    }
                    else if (textBox_search.Text.IndexOf(",") != -1 && Date_Search_checkBox.Checked == true)
                    {
                        String date = (date_search_dateTime.Value.Year - 1911)+ "/" 
                                    + date_search_dateTime.Value.Month
                                    + "/" + date_search_dateTime.Value.Day;

                        int dot_pos = textBox_search.Text.IndexOf(",");
                        String dot1 = textBox_search.Text.Substring(0, dot_pos);
                        String dot2 = textBox_search.Text.Substring(2);
                        String searchSoundName_sql = "SELECT name FROM meal WHERE name LIKE '%[" + dot1 + dot2 + "]%' AND Date ='" + date + "'";
                        cmd.CommandText = searchSoundName_sql;//dot search
                        show_customer_listbox.Items.Clear();
                        dr = cmd.ExecuteReader(); 
                        while (dr.Read())
                        {
                            i++;
                            show_customer_listbox.Items.Add(dr[0].ToString());
                        }
                      
                        if(i!=0)
                        {
                            Date_Search_checkBox.Checked = false;
                            date_search_dateTime.Visible = false;
                        }
                       
                    }
                    checkBox_special_search.Checked = false;

            }
            else if (Date_Search_checkBox.Checked == true)
            {

                String date = (date_search_dateTime.Value.Year - 1911) + "/"
                            + date_search_dateTime.Value.Month
                            + "/" + date_search_dateTime.Value.Day;
                String dateAndsearchName_sql = "SELECT name FROM meal WHERE name LIKE" + "'%" + textBox_search.Text + "%' AND Date = '" + date+"'";//This SQL command is search keyword by name

                cmd.CommandText = dateAndsearchName_sql;//search name
                show_customer_listbox.Items.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    show_customer_listbox.Items.Add(dr[0].ToString());
                }
                if (i != 0)
                {
                    Date_Search_checkBox.Checked = false;
                    date_search_dateTime.Visible = false;
                }
                
            }
            else
            {
                cmd.CommandText = searchName_sql;//search name
                show_customer_listbox.Items.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    show_customer_listbox.Items.Add(dr[0].ToString());
                }
               
            }

            label_output.Text = "關鍵字: " + search_keyword + "\r\n搜尋到 " + i.ToString() + " 筆";
            conn.Close();             
        }
        private void Thread_SQL()
        { 
        
        }
        DataGridViewRowCollection DGV_rows;

        private void show_customer_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //"SELECT COUNT(*) AS numberOfRows FROM kudydb WHERE name Like '"+show_customer_LBSELECTED+"'";
            
            DGV_rows = null;
            DGV_rows = dataGridView_show_info.Rows;
            dataGridView_show_info.Update();
            ds = new DataSet();
          //  DataGridViewRowCollection DGV_rows = dataGridView_show_info.Rows;
            
           // DGV_rows.Clear(); 
            //dataGridView_show_info.EnableHeadersVisualStyles = false;
            button1.Enabled = true;
            
            tabControl_Meal.Enabled = true;
            textBox_remark.Enabled = false;
            /////////// 清除部分 ///////////
            int c = 0;
            id.Clear();//Clear arraylist
            meals.Clear();
            Date.Clear();
            nop.Clear();
            phone.Clear();
            remark.Clear();
            DGV_rows.Clear();

            //dataGridView_show_info.Update();
            //Clear DataGrid_show_info
            //////////////////////////////


         //   String SQL_count = "SELECT COUNT(*) AS numberOfRows FROM kudydb WHERE name Like '" + show_customer_LbSelected + "'";

            
            show_customer_LbSelected = this.show_customer_listbox.SelectedItem.ToString();
        ////////////////////以下Thread_SQL()////////////////
            conn.Open();
           

           

            String SQL_kudydb_name = "SELECT ID,phone,remark FROM kudydb WHERE name LIKE" + "'" + show_customer_LbSelected + "'";
            String SQL_meal_name = "SELECT * FROM meal WHERE name LIKE" + "'" + show_customer_LbSelected + "'";

            String SQL_meal_name2 = "SELECT Meal,Date,nop FROM meal WHERE name LIKE" + "'" + show_customer_LbSelected + "'";
           
            
            cmd.Connection = conn;
            cmd.CommandText = SQL_meal_name;         
            dr = cmd.ExecuteReader();


            da = new OleDbDataAdapter(SQL_meal_name2, path_ole);
            da.Fill(ds);
            //dataGridView_show_info.DataSource = ds.Tables[0].DefaultView;
            
            while (dr.Read())
            {
        
                meals.Add(dr[1].ToString());
                Date.Add(dr[3].ToString());
                nop.Add(dr[5].ToString());
               
               DGV_rows.Add(dr[3].ToString(), dr[1].ToString(),dr[5].ToString());
               
                c++;
            }
            
           
            conn.Close();
            
            
          
            
            //dataGridView_show_info.Refresh();

            conn.Open();
            cmd.CommandText = SQL_kudydb_name;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id.Add(dr[0].ToString());
                phone.Add(dr[1].ToString());
                remark.Add(dr[2].ToString());
                
            }
            conn.Close();
            /////////////////以上測試//////////////////
            textBox_Consumer_times.Text = meals.Count.ToString() + " 次";
            textBox_Show_ID.Text = id[0].ToString();//選擇後show 出 ID

            textBox_remark.Clear();//清空備註欄
            if (remark[0].ToString().Trim().Length > 0)
            {
                textBox_remark.Text = remark[0].ToString();//選擇後show 出 備註
            }
            textBox_ShowName.Refresh();
            textBox_ShowName.Size = new Size(show_customer_LbSelected.Length * 25, 39);
            textBox_ShowName.Text = show_customer_LbSelected;

            tabControl_Meal.TabPages[0].Text = show_customer_LbSelected + "'s 用餐資料";
         
            if (phone[0].ToString() == "")
            {
                textBox_phone.Text = "沒有登記號碼";
            }
            else
            {
                textBox_phone.Text = "0"+phone[0].ToString();
            }

            textBox_show_meal.Clear();
            for (int i = 0; i < meals.Count; i++)
            {
                //DGV_rows.Add(meals[i], Date[i], nop[i]);
                textBox_show_meal.Text += Date[i].ToString() + "   " + meals[i].ToString() + "   " + nop[i].ToString() + "\r\n";
                
            }
            dataGridView_show_info.Update();
            //更新備註
            textBox_Remark_remark.Clear();
            textBox_Remark_remark.Text =  refresh_remark_to_db(id[0].ToString());

          
            button_Remark_changeR.Enabled = true;

            
            // set_DGV_size(meals, Date);
            //自己設定的DGV大小 後來用調整屬性 DOCK = Fill 用不到 ,

                

           
        }
        private void set_DGV_size(ArrayList DGV_meal,ArrayList DGV_Date)
        {
            //int wid = 0;

            //for (int i = 0; i < DGV_meal.Count; i++)
            //{

            //    if (DGV_meal[i].ToString().Length+DGV_Date[i].ToString().Length > wid)
            //    {
            //        wid = DGV_meal[i].ToString().Length;               
            //    }
              
            //}


            //if (wid >= 20 && wid <=30) //20~30
            //{
            //    dataGridView_show_info.Size = new Size(wid * 23, DGV_meal.Count + 2 * 100);
            //    textBox1.Text += "20~30 \r\n";
            //}
            //else if (wid >=15&&wid<=19) //15~19
            //{
            //    dataGridView_show_info.Size = new Size(wid * 27, DGV_meal.Count + 2 * 100);
            //    textBox1.Text += "15~19 \r\n";
            //}
            //else if (wid>=10&&wid<=14)//10~14
            //{
            //    dataGridView_show_info.Size = new Size(wid * 29, DGV_meal.Count + 2 * 100);
            //    textBox1.Text += "10~14 \r\n";
            
            //}
            //else if(wid <10)
            //{
            //    dataGridView_show_info.Size = new Size(wid * 50, DGV_meal.Count + 2 * 100);//寬,高
            //    textBox1.Text += "wid <10 \r\n";
            //}
            //dataGridView_show_info.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView_show_info.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //textBox1.Text += "W " + (wid * 23).ToString() + "   H " + ((DGV_meal.Count + 2 )* 100).ToString()  + "總字數 : " + wid.ToString()+"\r\n";

        
        }
        public void check_phone_number()
        {
            int cp = 0;

            for (int i = 0; i < phone.Count; i++)
            {
                if (phone[i].ToString() != "")
                {
                    cp = i;
                    textBox_phone.Text = "0" + phone[cp];
                    return;
                }
                else
                {
                    textBox_phone.Text = "No Phone Number";
                }
            }

        }
        private String getDate(String meal)
        {
            String Date = "";
            int end = 0;
            
            if (meal.Substring(0,1) == "(")
            {
                end = meal.IndexOf(")", 1);
                Date = meal.Substring(1, end-1);
            }

                return Date;
        }
        private String DelDate(String meal_to_Del)
        {
            String Del_meal = "";
            String Del_Date = "";
            int last = 0;
            if (meal_to_Del.Substring(0, 1) == "(")
            {
                last = meal_to_Del.IndexOf(")", 1);
                Del_Date = meal_to_Del.Substring(0, last+1);
                Del_meal = meal_to_Del.Replace(Del_Date,"");
                return Del_meal;
            }
            else 
            {
                return meal_to_Del;
            }

          
        
        
        }
        private void checkBox_special_search_CheckedChanged(object sender, EventArgs e)//special_search 按鈕
        {
            if (checkBox_special_search.Checked == true)
            {
                MessageBox.Show("使用 Special Search 功能" + "\r\n" + "\r\n" + " 需輸入格式如 鐘,鍾 或是 古,林 (姓,姓)", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //if (textBox_search.Text.Length > 3 || textBox_search.Text.Length < 3 || textBox_search.Text.Substring(1, 1) != ",")
                if (textBox_search.Text.IndexOf(",") == -1 || textBox_search.Text.Length < 3)
                {
                    MessageBox.Show(textBox_search.Text + " 不符合格式," + "請確認所要搜尋格式", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBox_special_search.Checked = false;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_phone.ReadOnly = false;
            button1.Enabled = false;
        }

        private void textBox_phone_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter )
            {
                if(textBox_phone.TextLength ==10)
                {
                    String phone = "";
                    String SQL_upphone = "UPDATE kudydb SET phone = " + textBox_phone.Text + " WHERE ID = " + id[0];
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = SQL_upphone;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    String SQL_review = "Select phone From kudydb Where ID = " + id[0];

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = SQL_review;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        phone = dr[0].ToString();

                    }
                    conn.Close();
                    textBox_phone.Text = "0" + phone;
                    button1.Enabled = true;
                    textBox_phone.ReadOnly = true;
                    button1.Focus();
                    textBox1.Text += SQL_upphone;
                }
                else
                {
                  MessageBox.Show("你所輸入的電話號碼有誤", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

            }
            
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            
            //Search();
        }


        private void button_preview_Click(object sender, EventArgs e)
        {
            if (textBox_new_meal.Text.Trim() == "")
            {
                textBox_new_preview.Clear();
                textBox_new_preview.Text = "請輸入餐點";
            }
            else
            {
                
                insert_newC_meal.Clear();
                String date_newC = (dateTime_new_meal.Value.Year - 1911) + "/" + dateTime_new_meal.Value.Month + "/" + dateTime_new_meal.Value.Day;
                String mop_newcC = comboBox_adult.Text.ToString() + " 大 " + comboBox_child.Text.ToString() + " 童 " + comboBox_baby.Text.ToString() + " 寶 ";
                String meal_newC = textBox_new_meal.Text.ToString();
                String remark_newC = textBox_remark.Text.ToString();
                button_preview.Enabled = false;
                if (textBox_remark.Text.Trim().Replace("\r\n", "").Length <= 2)
                {
                    remark_newC = "";
                }

                //label_preview_new_meal.Text = "客戶姓名 : " + show_customer_LbSelected+"\r\n"
                //                            + "客戶編號 : " + id[0].ToString()+"\r\n"
                //                            + "用餐日期 : " + date_newC + "\r\n"
                //                            + "用餐人數 : " + mop_newcC + "\r\n"
                //                            + "當日餐點 : " + meal_newC + "\r\n"
                //                            + "備　　註 : " + remark_newC;

                textBox_new_preview.Text = "客戶姓名 : " + show_customer_LbSelected + "\r\n"
                                            + "客戶編號 : " + id[0].ToString() + "\r\n"
                                            + "用餐日期 : " + date_newC + "\r\n"
                                            + "用餐人數 : " + mop_newcC + "\r\n"
                                            + "當日餐點 : " + meal_newC + "\r\n\r\n"
                                            + "備　　註 : " + "\r\n"+remark_newC.Trim();
                //關掉表格輸入//

                insert_newC_meal.Add(meal_newC);//當日餐點
                insert_newC_meal.Add(date_newC);//用餐日期
                insert_newC_meal.Add(mop_newcC);//用餐人數


                dateTime_new_meal.Enabled = false;
                textBox_new_meal.ReadOnly = false;
                comboBox_adult.Enabled = false;
                comboBox_child.Enabled = false;
                comboBox_baby.Enabled = false;
                textBox_new_meal.ReadOnly = true;
                textBox_remark.ReadOnly = true;
               
                button_newC_cannel.Visible = true;
                
                button_newC_correct.Visible = true;

                
               // textBox1.Text = textBox_remark.Text.Length.ToString();
            }
        }

        private void UpdateRemark(String Remark_text,String id_forRemark)
        {
            conn.Open();
            cmd.Connection = conn;
            String update_remarks = "UPDATE kudydb SET remark = '" + Remark_text + "' WHERE ID = " + id_forRemark;
            cmd.CommandText = update_remarks;
            cmd.ExecuteNonQuery();
            conn.Close();
        
        }
        private String refresh_remark_to_db(String id)
        { 
            String refresh_reamrk = "SELECT remark FROM kudydb WHERE ID = " + id;
            String remark = "";
           

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = refresh_reamrk;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                remark = dr[0].ToString();
            }
            conn.Close();
            return remark;
        }
        private void refresh_DGV() //讀取 DGV 資訊  可用在重新讀取
        {

            String SQL_meal_name2 = "SELECT Meal,Date,nop FROM meal WHERE name LIKE" + "'" + show_customer_LbSelected + "'";
            ///DGV接source方法///
            da = new OleDbDataAdapter(SQL_meal_name2, path_ole);
            da.Fill(ds);

            //dataGridView_show_info.DataSource = ds.Tables[0].DefaultView;

            textBox_show_meal.Text = ds.Tables[0].DefaultView.ToString();
            dataGridView_show_info.Update();

            ///text 顯示方法 ///
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = SQL_meal_name2;
            dr = cmd.ExecuteReader();

            meals.Clear();
            Date.Clear();
            nop.Clear();
            textBox_show_meal.Clear();

            while (dr.Read())
            {
                meals.Add(dr[0].ToString());
                Date.Add(dr[1].ToString());
                nop.Add(dr[2].ToString());  
            }
            conn.Close();
            DGV_rows.Clear();
            for (int i = 0; i < meals.Count; i++)
            {
                DGV_rows.Add(Date[i], meals[i],nop[i]);
                textBox_show_meal.Text += Date[i].ToString() + "   " + meals[i].ToString() + "   " + nop[i].ToString() + "\r\n";

            }
        
        }
        private void textBox_NewAcc_name_TextChanged(object sender, EventArgs e)
        {
            button_NewAcc_checkname.Enabled = true;
        }

        private void button_NewAcc_checkname_Click(object sender, EventArgs e)
        {
            String NewName = "";
            
            if (string.IsNullOrWhiteSpace(textBox_NewAcc_name.Text))
            {
                MessageBox.Show("空格裡不能為空白", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_NewAcc_name.Clear();
                textBox_NewAcc_name.Focus();
                button_NewAcc_checkname.Enabled = false;
            }
            else
            {
                ArrayList NewAcc_name = new ArrayList();

                NewName = textBox_NewAcc_name.Text.ToString();

                conn.Open();
                cmd.Connection = conn;
                String SQL_new_name = "Select name From kudydb WHERE name = '" + NewName +"'";
                cmd.CommandText = SQL_new_name;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    NewAcc_name.Add(dr[0]); 
                }
                conn.Close();
                if (NewAcc_name.Count > 0)
                {
                    MessageBox.Show("姓名有重複,請確認姓名正確性(唯一),或是利用中文+英文取名子", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    panel_NewAcc.Visible = true;
                    textBox_NewAcc_name.Enabled = false;
                    button_NewAcc_checkname.Enabled = false;
                }
               
            
            }
        }

        //private void textBox_remark_KeyDown(object sender, KeyEventArgs e)
        //{
        //    int a=2;
        //    for (int i = 1; i < a; i++)
        //    {
        //        if (textBox_remark.Text.IndexOf(i + ".") == -1)
        //        {
        //            count_down_time = i;
        //        }
        //        else
        //        {
        //            a++;
        //        }
        //    }
            
        //    if (e.KeyCode == Keys.Enter )
        //    {
                
        //        String rigster = textBox_remark.Text;
        //        textBox_remark.Clear();
        //        textBox_remark.Text = rigster.Trim()+"\r\n" + count_down_time + ". ";
        //        textBox_remark.SelectionStart = textBox_remark.Text.Length;
        //        textBox_remark.ScrollToCaret();
        //        textBox_remark.Focus();
        //    }
        //}

        private void button_Remark_changeR_Click(object sender, EventArgs e)
        {


            if (button_Remark_changeR.Text == "更改備註")
            {
                textBox_Remark_remark.ReadOnly = false;
                textBox_Remark_remark.Enabled = true ;
                button_Remark_changeR.Text = "確定";
            }
            
            else if (button_Remark_changeR.Text == "確定")
            {
                UpdateRemark(textBox_Remark_remark.Text, id[0].ToString());
                button_Remark_changeR.Text = "更改備註";
                textBox_Remark_remark.Clear();
                textBox_Remark_remark.Text=refresh_remark_to_db(id[0].ToString());
                textBox_remark.Text = refresh_remark_to_db(id[0].ToString());
                textBox_Remark_remark.ReadOnly = true;
                textBox_Remark_remark.Enabled = false;
            }

        }
        private void textBox_Remark_remark_KeyDown(object sender, KeyEventArgs e)
        {
            int a = 2;
            textBox_Remark_remark.ImeMode = System.Windows.Forms.ImeMode.OnHalf;
            for (int i = 1; i < a; i++)
            {
                if (textBox_Remark_remark.Text.IndexOf(i + ".") == -1)
                {
                    count_down_time = i;
                }
                else
                {
                    a++;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {

                String rigster = textBox_Remark_remark.Text;
                textBox_Remark_remark.Clear();
                textBox_Remark_remark.Text = rigster.Trim() + "\r\n" + count_down_time + ". ";
                textBox_Remark_remark.SelectionStart = textBox_Remark_remark.Text.Length;
                textBox_Remark_remark.ScrollToCaret();
                textBox_Remark_remark.Focus();
            }



        }

        private void button_newC_correct_Click(object sender, EventArgs e)
        {
            // insert_newC_meal.Add(meal_newC);//當日餐點
            // insert_newC_meal.Add(date_newC);//用餐日期
            // insert_newC_meal.Add(mop_newcC);//用餐人數

            conn.Open();
            cmd.Connection = conn;
            String insert_meal_newC = "INSERT INTO meal VALUES('" + id[0].ToString() + "','" + insert_newC_meal[0].ToString() + "','" + show_customer_LbSelected + "','" + insert_newC_meal[1].ToString() + "','" + DateTime.Now.ToString() + "','" + insert_newC_meal[2].ToString() + "')";
            cmd.CommandText = insert_meal_newC;
            cmd.ExecuteNonQuery();

            conn.Close();

            //"INSERT INTO meal VALUES('" + Auto_2meal_id[0] + "','" + DelDate(Auto_2meal_meal[j].ToString()) + "','" + Auto_name[i] + "','" + getDate(Auto_2meal_meal[j].ToString()) + "','" + DateTime.Now.ToString() + "')";



            UpdateRemark(textBox_remark.Text.ToString(), id[0].ToString());
            //conn.Open();
            //cmd.Connection = conn;
            //String update_remarks = "UPDATE kudydb SET remark = '" + textBox_remark.Text.ToString() + "' WHERE ID = " + id[0];           
            //cmd.CommandText = update_remarks;
            //cmd.ExecuteNonQuery();
            //conn.Close();




            textBox1.Text += insert_meal_newC + "\r\n";


            /////顯示在console
            for (int i = 0; i < insert_newC_meal.Count; i++)
            {
                textBox1.Text += insert_newC_meal[i].ToString() + "\r\n";
            }

            textBox_new_preview.Clear();
            dateTime_new_meal.Enabled = true;
            textBox_new_meal.ReadOnly = true;
            comboBox_adult.Enabled = true;
            comboBox_child.Enabled = true;
            comboBox_baby.Enabled = true;
            textBox_new_meal.ReadOnly = false;
            textBox_new_meal.Clear();
            textBox_remark.ReadOnly = false;
            textBox_remark.Clear();
            button_preview.Enabled = true;
            button_newC_cannel.Visible = false;
            button_newC_correct.Visible = false;

            ///再次更新 DGV 版面
            refresh_DGV();
            textBox_remark.Text = refresh_remark_to_db(id[0].ToString());
            ///更新備註版面
            textBox_Remark_remark.Clear();
            textBox_Remark_remark.Text = refresh_remark_to_db(id[0].ToString());
            //////////////////////
        }

        private void button_newC_cannel_Click(object sender, EventArgs e)
        {
            textBox_new_preview.Clear();
            dateTime_new_meal.Enabled = true;
            textBox_new_meal.ReadOnly = true;
            comboBox_adult.Enabled = true;
            comboBox_child.Enabled = true;
            comboBox_baby.Enabled = true;
            textBox_new_meal.ReadOnly = false;
            textBox_remark.ReadOnly = false;
            button_preview.Enabled = true;
            button_newC_cannel.Visible = false;
            button_newC_correct.Visible = false;
        }
        private void textBox_new_meal_KeyDown(object sender, KeyEventArgs e)
        {
            textBox_remark.Enabled = true;
        }

        private void textBox_remark_KeyDown(object sender, KeyEventArgs e)
        {
            int a = 2;
            for (int i = 1; i < a; i++)
            {
                if (textBox_remark.Text.IndexOf(i + ".") == -1)
                {
                    count_down_time = i;
                }
                else
                {
                    a++;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {

                String rigster = textBox_remark.Text;
                textBox_remark.Clear();
                textBox_remark.Text = rigster.Trim() + "\r\n" + count_down_time + ". ";
                textBox_remark.SelectionStart = textBox_remark.Text.Length;
                textBox_remark.ScrollToCaret();
                textBox_remark.Focus();
            }
        }

        private void tabControl_Meal__MouseDown(object sender, MouseEventArgs e)//新的
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {

                
                dataGridView_show_info.Refresh();
                this.Refresh();
            }
           
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                
            }
        }

        private void tabControl_Meal_MouseDown(object sender, MouseEventArgs e)
        {
            if (tabControl_Meal.SelectedTab == page_New_meal)
            {
                if (textBox_new_meal.Text.Trim() == null)
                {
                    textBox_remark.Enabled = false;
                }
            }
            else
            {
                textBox_remark.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_NewAcc_meal.Clear();
            textBox_NewAcc_BD.Clear();
            textBox_NewAcc_phone.Clear();
            panel_NewAcc.Visible = false;

            textBox_NewAcc_name.Clear();
            textBox_NewAcc_name.Enabled = true;
            button_NewAcc_checkname.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList id = new ArrayList();

            String insert_kudydb_newAcc =  "INSERT INTO kudydb (name,phone,BD) VALUES('"+textBox_NewAcc_name.Text+"','"+textBox_NewAcc_phone.Text+"','"+textBox_NewAcc_BD.Text+"')";
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = insert_kudydb_newAcc;
            cmd.ExecuteNonQuery();
            conn.Close();


            String search_newAcc = "Select id From kudydb Where name = '" + textBox_NewAcc_name.Text+"'";
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = search_newAcc;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id.Add(dr[0]);
            }
            conn.Close();

            String insert_meal_newAcc = "INSERT INTO meal VALUES('" + id[0] + "','" + textBox_NewAcc_meal.Text + "','" + textBox_NewAcc_name.Text + "','"
                + (dateTime_new_meal.Value.Year - 1911) + "/" + dateTime_new_meal.Value.Month + "/" + dateTime_new_meal.Value.Day + "','" + DateTime.Now.ToString() + "','"
                + comboBox_adult.Text.ToString() + " 大 " + comboBox_child.Text.ToString() + " 童 " + comboBox_baby.Text.ToString() + " 寶 ')";

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = insert_meal_newAcc;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(" 成功一名新客戶  "+textBox_NewAcc_name.Text, "新增成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox_NewAcc_meal.Clear();
            textBox_NewAcc_BD.Clear();
            textBox_NewAcc_phone.Clear();
            panel_NewAcc.Visible = false;

            textBox_NewAcc_name.Clear();
            textBox_NewAcc_name.Enabled = true;
            button_NewAcc_checkname.Enabled = true;

        }

        private void Date_check_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            date_search_dateTime.Visible = true;
        }
        private void 返回首頁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index_Form IF = new index_Form(this.readwrite_R, this.engineer_R, this.boss_R, this.Acc_name_R);//用上面傳進form的權限在傳出去
            this.Hide();
            IF.Show(this);
            IF.BringToFront();
        }

        private void toolStripMenuItem_exit_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Owner.Close();
            //this.Owner.Show();
            //this.Close();
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
    }
}
