using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlphabetDictionaryGGJM.SqliteClass;

namespace AlphabetDictionaryGGJM.AlphabetQuizSystem
{
    public partial class AlphabetQuizSystem : Form
    {
        public AlphabetQuizSystem()
        {
            InitializeComponent();
        }
        AlphabetDictionaryMain MainForm;//主視窗
        AlphabetDictionaryGGJM.Speech.Speech SpeakClass = new Speech.Speech();//語音功能  
        SqliteDB SQLMyDB = new SqliteDB();//SqlDB
        List<AlphaBetTable> QuizDB = new List<AlphaBetTable>();
        bool answer = false;//---答案公佈按鈕
        int Quiz_total = 0;
        int Quiz_Finish = 0;
        int Quiz_Right = 0;
        float Quiz_RightRate = 0;

        /// <summary>
        /// 給Form存放控制權
        /// </summary>
        /// <param name="ResourceForm"></param>
        public void Get_Form(AlphabetDictionaryMain ResourceForm)
        {
            this.MainForm = ResourceForm;
        }

        private void AlphabetQuizSystem_Load(object sender, EventArgs e)
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

            //播放模式
            string[] play_modeInitinal = { "英文輸入測驗" };
            comboBox_playmode.Items.AddRange(play_modeInitinal);
            comboBox_playmode.SelectedIndex = 0;

           

        }

        /// <summary>
        /// Form關閉時將權限返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlphabetQuizSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            MainForm.Show();
        }

        /// <summary>
        /// 當輸入中文時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Chinese_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void button_Play_Click(object sender, EventArgs e)
        {

            if (comboBox_playmode.Text == "英文輸入測驗" && button_Play.Text == "測驗")
            {
                button_Play.Text = "停止";
                label_Message.Text = "訊息";
                textBox_English.Clear();
                textBox_Chinese.Clear();

                textBox_English.ReadOnly = false;//--關閉英文輸入
                QuizDB.Clear();
                QuizDB = SQLMyDB.Get_SelectTable(comboBox_Table.SelectedItem.ToString());//讀進

                Quiz_total = QuizDB.Count;
                Quiz_Finish = 0;
                Quiz_Right = 0;
                Quiz_RightRate = 0;

                label_Total.Text = "測驗題目數：" + Quiz_total;//測驗題目總數
                label_Finish.Text = "已測驗數：" + Quiz_Finish;
                label_Right.Text = "正確題數：" + Quiz_Right;
                label_RightRate.Text = "正確率：" + Quiz_RightRate.ToString("00.000");

                textBox_Chinese.Text = QuizDB[0].Chinese;

            }
            else
            {
                button_Play.Text = "測驗";
                textBox_English.Clear();
                textBox_Chinese.Clear();
                label_Message.Text = "訊息";
                label_Total.Text = "測驗題目數：";//測驗題目總數
                label_Finish.Text = "已測驗數：";
                label_Right.Text = "正確題數：";
                label_RightRate.Text = "正確率：";
                textBox_English.ReadOnly = true;//--關閉英文輸入
            }
        }

        private void button_Play_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// 當按下中文時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Chinese_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox_English.ReadOnly == false)
            {
               
                if (textBox_English.Text == QuizDB[Quiz_Finish].English)
                {
                    label_Message.Text = "正確!!";

                    if (combobox_Voice.Text != "關閉")
                    {
                        SpeakClass.Set_volume(int.Parse(comboBox_volumn.Text));
                        SpeakClass.Set_rate(int.Parse(comboBox_Rate.Text));
                        SpeakClass.Set_UseVoice(combobox_Voice.Text);
                        SpeakClass.Speak(textBox_English.Text);
                    }

                    Quiz_Right++;
                    Quiz_Finish++;
                    Quiz_RightRate = (float)(Quiz_Right) / (Quiz_Finish) * 100;

                    if (Quiz_Finish == QuizDB.Count)
                    {
                        label_Message.Text = "測驗結束!!";
                        textBox_English.ReadOnly = true;//--開啟中文輸入
                    }
                    else
                    {
                        textBox_Chinese.Text = QuizDB[Quiz_Finish].Chinese;
                        textBox_English.Clear();
                    }

                    label_Finish.Text = "已測驗數：" + Quiz_Finish;
                    label_Right.Text = "正確題數：" + Quiz_Right;
                    label_RightRate.Text = "正確率：" + Quiz_RightRate.ToString("00.000");
                    

                    
                }
                else 
                {
                    if (answer)
                        label_Message.Text = QuizDB[Quiz_Finish].English;
                    else
                        label_Message.Text = "錯誤，再想想";
                }

               
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (textBox_English.ReadOnly == false)
            {

                label_Message.Text = "答錯，跳下一題!";
                Quiz_Finish++;
                Quiz_RightRate = Quiz_RightRate = (float)(Quiz_Right) / (Quiz_Finish) * 100; ;

                if (Quiz_Finish == QuizDB.Count)
                {
                    label_Message.Text = "測驗結束!!";
                    textBox_English.ReadOnly = true;
                }
                else
                {
                    textBox_Chinese.Text = QuizDB[Quiz_Finish].Chinese;
                    textBox_English.Clear();
                }
                label_Finish.Text = "已測驗數：" + Quiz_Finish;
                label_Right.Text = "正確題數：" + Quiz_Right;
                label_RightRate.Text = "正確率：" + Quiz_RightRate.ToString("00.000");

            }
            
        }

        /// <summary>
        /// 答案透明化按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_answer_Click(object sender, EventArgs e)
        {

            if (answer)
            {
                button_answer.Text = "答案公佈(無)";
                answer = false;
            }
            else
            {
                button_answer.Text = "答案公佈(開啟)";
                answer = true;
            }
        }
    }
}
