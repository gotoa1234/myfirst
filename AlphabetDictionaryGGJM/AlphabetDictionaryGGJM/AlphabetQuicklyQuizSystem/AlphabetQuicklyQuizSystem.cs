using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlphabetDictionaryGGJM.SqliteClass;

namespace AlphabetDictionaryGGJM.AlphabetQuicklyQuizSystem
{
    public partial class AlphabetQuicklyQuizSystem : Form
    {
        public AlphabetQuicklyQuizSystem()
        {
            InitializeComponent();
        }
        AlphabetDictionaryMain MainForm;//主視窗
        AlphabetDictionaryGGJM.Speech.Speech SpeakClass = new Speech.Speech();//語音功能  
        SqliteDB SQLMyDB = new SqliteDB();//SqlDB
        List<AlphaBetTable> QuizDB = new List<AlphaBetTable>();
        int Max_Time = 5000;//----剛開始最大秒數為5秒
        int Min_Time = 2000;//----秒數最少2秒
        Random Topic_Random = new Random();//--出題的變數
        List<AlphaBetTable> Title_List = new List<AlphaBetTable>();//--題目的List 將要考試的單字全部放入 每次會有20個
        int right = 0;//正確答案
        int Now_Title = 0;//現在題目
        Timer Reciprocal = new Timer();//---倒數使用
        private delegate void MyDelegate(int volumn,int rate,string voice,string eng);//-------讓程式念完使用
        MyDelegate Call_speech;
        int Quiz_Finish = 0;//已測驗數
        int Quiz_Right = 0;//正確數
        float Quiz_RightRate = 0;//正確率
        int total = 0;//---------本次題目總數 -通常20題 最後一項可能會比較少
        /// <summary>
        /// 給Form存放控制權
        /// </summary>
        /// <param name="ResourceForm"></param>
        public void Get_Form(AlphabetDictionaryMain ResourceForm)
        {
            this.MainForm = ResourceForm;
        }

        private void AlphabetQuicklyQuizSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            MainForm.Show();
        }

        /// <summary>
        /// 進入時撈取資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlphabetQuicklyQuizSystem_Load(object sender, EventArgs e)
        {
            //速率初始化
            string[] rate_range = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "-1", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9", "-10" };
            comboBox_Rate.Items.AddRange(rate_range);
            comboBox_Rate.SelectedIndex = 0;

            //音量初始化
            for (int i = 100; i >= 0; i -= 5)
                comboBox_volumn.Items.Add(i.ToString());
            comboBox_volumn.SelectedIndex = 0;

            //語音初始化
            List<string> Get = SpeakClass.Get_ComputerInstallVoice();
            if (Get.Count == 0)
                combobox_Voice.Items.Add("沒有內建語音");
            else
            {
                combobox_Voice.Items.Add("關閉");
                foreach (string get in Get)
                    combobox_Voice.Items.Add(get);

            }
            combobox_Voice.SelectedIndex = 0;

            //讀取資料表SqliteDB 
            comboBox_Table.DataSource = SQLMyDB.Get_Table_Index();

            //將讀到的表做分割
            Split_word();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Play_Click(object sender, EventArgs e)
        {
            try
            {
                //初始化
                label_ResponseUser.TextAlign = ContentAlignment.MiddleCenter;
                Now_Title = 0;//--題目從0開始
                Quiz_Finish = 0;
                Quiz_Right = 0;//正確題數
                Quiz_RightRate = 0;//正確率
                right = 0;
                
                //
                Reciprocal = new Timer();
                Reciprocal.Interval = 10;//--50ms做一次
                Reciprocal.Tick += Reciprocal_Work;
                progressBar1.Maximum = Max_Time;
                progressBar1.Value = 0;
                Title_List = new List<AlphaBetTable>();
                Quiz_Title();//建構題目
                comboBox_wrongList.Items.Clear();
                if (total - comboBox_list.SelectedIndex * 20 > 4)
                {

                    Quiz_Varible();//出題囉
                    button_A.Enabled = true;
                    button_B.Enabled = true;
                    button_C.Enabled = true;
                    button_D.Enabled = true;

                    Reciprocal.Start();
                }
                else
                {
                    label_ResponseUser.Text = "抱歉本題目不到4題，無法建立";
                    
                }
            }
            catch (Exception ex)
            { 
            }

        }

        /// <summary>
        /// 回答A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_A_Click(object sender, EventArgs e)
        {
            Response_Answer(0);
        }
        /// <summary>
        /// 回答B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_B_Click(object sender, EventArgs e)
        {
            Response_Answer(1);
        }
        /// <summary>
        /// 回答C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_C_Click(object sender, EventArgs e)
        {
            Response_Answer(2);
        }
        /// <summary>
        /// 回答D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_D_Click(object sender, EventArgs e)
        {
            Response_Answer(3);
        }
        //=== function

        /// <summary>
        /// 切割文字數量使用
        /// </summary>
        public void Split_word()
        {
            try
            {
                QuizDB.Clear();
                comboBox_list.Items.Clear();
                QuizDB = SQLMyDB.Get_SelectTable(comboBox_Table.SelectedItem.ToString());//讀進

                //看有幾個
                int QuizCount = QuizDB.Count / 20;

                if (QuizCount != 0)
                {

                    for (int i = 0; i < QuizCount; i++)
                    {
                        comboBox_list.Items.Add("第" + ((i * 20) + 1) + "~" + (i + 1) * 20 + "個單字");
                    }

                    //有餘數
                    if (QuizCount % 20 != 0)
                        QuizCount++;

                    comboBox_list.Items.Add("第" + (((QuizCount - 1) * 20) + 1) + "~" + ((((QuizCount - 1) * 20) + 1) + (QuizDB.Count % 20) - 1) + "個單字");
                    comboBox_list.SelectedIndex = 0;
                }
                else
                {
                    comboBox_list.Items.Add("第" + 1 + "~" + QuizDB.Count + "個單字");
                    comboBox_list.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
            }
            
        }

        /// <summary>
        /// Timer 倒數工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reciprocal_Work(object sender, EventArgs e)
        {

            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += Reciprocal.Interval;
                label_Second.Text = ((Math.Round((float)progressBar1.Value / 1000, 2))).ToString("0.00");
            }
            else//視為答錯
            {
                Response_Answer(-1);
            }
        }

        /// <summary>
        /// 題目建構
        /// </summary>
        public void Quiz_Title()
        { 
            //取得當前comboxlist的selectindex 0=1~20 1=21~40 以此類推

            if ((comboBox_list.SelectedIndex+1) * 20 >= QuizDB.Count)
                total = QuizDB.Count;
            else
                total = (comboBox_list.SelectedIndex + 1) * 20;

            for (int count = 0, i = comboBox_list.SelectedIndex * 20; i < total; i++, count++)
            {
                Title_List.Add(QuizDB[i]);
            }
            AlphaBetTable temp = new AlphaBetTable();
            int select = 0;
            for (int i = 0; i < total - comboBox_list.SelectedIndex * 20; i++)
            {
                select = Topic_Random.Next(0, total - comboBox_list.SelectedIndex * 20);
                temp = Title_List[i];
                Title_List[i] = Title_List[select];
                Title_List[select] = temp;
            }


        }

        /// <summary>
        /// 題目變化
        /// </summary>
        public void Quiz_Varible()
        {

            try
            {
                int a = 0, b = 0, c = 0, d = 0;

                //問題
                textBox_English.Text = Title_List[Now_Title].English;
                if (combobox_Voice.Text != "關閉")
                {
                    Call_speech = new MyDelegate(Speech_timework);//建立delegate工作
                    Call_speech.BeginInvoke(int.Parse(comboBox_volumn.Text), int.Parse(comboBox_Rate.Text), combobox_Voice.Text, Title_List[Now_Title].English, null, null);
                }
                //先找出正確答案
                right = Topic_Random.Next(0, 4);//回傳0~3

                if (right == 0)
                {
                    button_A.Text = Title_List[Now_Title].Chinese;
                    a = Now_Title;
                }
                else if (right == 1)
                {
                    button_B.Text = Title_List[Now_Title].Chinese;
                    b = Now_Title;
                }
                else if (right == 2)
                {
                    button_C.Text = Title_List[Now_Title].Chinese;
                    c = Now_Title;
                }
                else if (right == 3)
                {
                    button_D.Text = Title_List[Now_Title].Chinese;
                    d = Now_Title;
                }

                int ran_max = (total - comboBox_list.SelectedIndex*20);
                while (!(a != b && a != c && a != d && b != c && b != d && c != d))
                {

                    if (right != 0)
                    {
                        a = Topic_Random.Next(0, ran_max);//回傳0~19
                        button_A.Text = Title_List[a].Chinese;
                    }
                    if (right != 1)
                    {
                        b = Topic_Random.Next(0, ran_max);//回傳0~19
                        button_B.Text = Title_List[b].Chinese;
                    }
                    if (right != 2)
                    {
                        c = Topic_Random.Next(0, ran_max);//回傳0~19
                        button_C.Text = Title_List[c].Chinese;
                    } if (right != 3)
                    {
                        d = Topic_Random.Next(0, ran_max);//回傳0~19
                        button_D.Text = Title_List[d].Chinese;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 回答答案
        /// </summary>
        /// <param name="answer">答案</param>
        public void Response_Answer(int answer)
        {
            

            //答對 秒數要稍微減少
            if (answer == right)
            {
                Quiz_Finish++;//已測驗數
                Quiz_Right++;//正確題數
                Quiz_RightRate = (float)(Quiz_Right) / (Quiz_Finish) * 100;//正確率
                label_Finish.Text = "已測驗數：" + Quiz_Finish.ToString();
                label_Right.Text = "正確題數：" + Quiz_Right.ToString();
                label_RightRate.Text = "正確率" + Quiz_RightRate.ToString("00.000");
                    

                //回應使用者是否正確
                label_ResponseUser.Text = "○ " + Title_List[Now_Title].Chinese ;

                //讀秒先停止
                Reciprocal.Stop();

                //秒數減少
                progressBar1.Maximum -= 500;
                if (progressBar1.Maximum < Min_Time)
                    progressBar1.Maximum = Min_Time;
                progressBar1.Value = 0;

                //呼叫中文
                //if (combobox_Voice.Text != "關閉")
                //{
                //    Call_speech = new MyDelegate(Speech_timework);//建立delegate工作
                //    Call_speech.BeginInvoke(int.Parse(comboBox_volumn.Text), int.Parse(comboBox_Rate.Text), combobox_Voice.Text, Title_List[Now_Title].English, null, null);
                //}
                //下一題
                Now_Title++;
                Quiz_Varible();


                if (Now_Title < (total -comboBox_list.SelectedIndex*20))
                    Reciprocal.Start();
                else
                {
                    button_A.Enabled = false;
                    button_B.Enabled = false;
                    button_C.Enabled = false;
                    button_D.Enabled = false;
                    label_ResponseUser.Text = "○ " + Title_List[Now_Title - 1].Chinese + " 已經結束";
                }

            }
            else//答錯 秒數要稍微提高
            {

                
                Quiz_Finish++;//已測驗數
                Quiz_RightRate = (float)(Quiz_Right) / (Quiz_Finish) * 100;//正確率
                label_Finish.Text = "已測驗數：" + Quiz_Finish.ToString();
                label_Right.Text = "正確題數：" + Quiz_Right.ToString();
                label_RightRate.Text = "正確率" + Quiz_RightRate.ToString("00.000");

                //回應使用者是否正確
                label_ResponseUser.Text = "Ｘ " + Title_List[Now_Title].Chinese;
                //錯誤表增加
                comboBox_wrongList.Items.Add(Title_List[Now_Title].Chinese + " § " + Title_List[Now_Title].English);
                comboBox_wrongList.SelectedIndex = comboBox_wrongList.Items.Count-1;
                //讀秒先停止
                Reciprocal.Stop();

                //秒數提高
                progressBar1.Maximum += 500;
                if (progressBar1.Maximum > Max_Time)
                    progressBar1.Maximum = Max_Time;
                progressBar1.Value = 0;

                //呼叫中文
                //if (combobox_Voice.Text != "關閉")
                //{
                //    Call_speech = new MyDelegate(Speech_timework);//建立delegate工作
                //    Call_speech.BeginInvoke(int.Parse(comboBox_volumn.Text), int.Parse(comboBox_Rate.Text), combobox_Voice.Text, Title_List[Now_Title].English, null, null);
                //}
                //下一題
                Now_Title++;
                Quiz_Varible();

                if (Now_Title < (total - comboBox_list.SelectedIndex*20))
                    Reciprocal.Start();
                else
                {
                    button_A.Enabled = false;
                    button_B.Enabled = false;
                    button_C.Enabled = false;
                    button_D.Enabled = false;
                    label_ResponseUser.Text = "Ｘ " + Title_List[Now_Title - 1].Chinese + " 已經結束";
                }
            }
        }


        /// <summary>
        /// 播放聲音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Speech_timework(int volumn, int rate , string voice, string eng)
        {

            SpeakClass.Set_volume(volumn);
            SpeakClass.Set_rate(rate);
            SpeakClass.Set_UseVoice(voice);
            SpeakClass.Speak(eng);
 
        }

        private void comboBox_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            //將讀到的表做分割
            Split_word();
        }


        // ======================   the end  =================
    }
}
