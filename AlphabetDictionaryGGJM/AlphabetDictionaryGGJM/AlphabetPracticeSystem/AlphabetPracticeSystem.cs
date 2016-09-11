using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlphabetDictionaryGGJM.SqliteClass;

namespace AlphabetDictionaryGGJM.AlphabetPracticeSystem
{
    public partial class AlphabetPracticeSystem : Form
    {
        AlphabetDictionaryMain MainForm;//主視窗
        AlphabetDictionaryGGJM.Speech.Speech SpeakClass = new Speech.Speech();//語音功能  
        SqliteDB SQLMyDB = new SqliteDB();//SqlDB
        Timer WatchState = new Timer();
        Timer Voice_run = new Timer();
        bool State = false;//---------------播放狀態
        Random Ram = new Random();

        int step = 0;//---------------------流程步驟
        System.Threading.Thread WorkSpeak;
        //Action WorkSpeak;
        public AlphabetPracticeSystem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 給Form存放控制權
        /// </summary>
        /// <param name="ResourceForm"></param>
        public void Get_Form(AlphabetDictionaryMain ResourceForm)
        {
            this.MainForm = ResourceForm;
        }

        /// <summary>
        /// Form關閉時將權限返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlphabetPracticeSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            MainForm.Show();
        }

        private void AlphabetPracticeSystem_Load(object sender, EventArgs e)
        {
            //速率初始化
            string[] rate_range = {"0","1", "2" ,"3","4","5","6","7","8","9","10","-1","-2","-3","-4","-5","-6","-7","-8","-9","-10"};
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
                foreach (string get in Get)
                    combobox_Voice.Items.Add(get);
            }
            combobox_Voice.SelectedIndex = 0;
            
            //讀取資料表SqliteDB 
            comboBox_Table.DataSource =  SQLMyDB.Get_Table_Index();

            //播放模式
            string[] play_modeInitinal = {"循序播放","重複播放","隨機播放"};
            comboBox_playmode.Items.AddRange(play_modeInitinal);
            comboBox_playmode.SelectedIndex = 0;
            //播放間隔
            for (int i = 1; i <= 15; i++)
                comboBox_Intral.Items.Add(i.ToString());
            comboBox_Intral.SelectedIndex = 0;

            //函式初始設定
            WatchState.Tick += Watch;
            WatchState.Interval = 500;
            Voice_run.Tick += Play_Auto;
        }

        private void comboBox_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
                LoadGridData();//----------------------讀到griddata

        }

        //===========獨立函式

        /// <summary>
        /// 重新讀取DataGridView控制項
        /// </summary>
        public void LoadGridData()
        {
            try
            {
                DataGridViewRowCollection rows = dataGridViewTabledata.Rows;
                rows.Clear();//清除
                SQLMyDB.Get_SelectTable(comboBox_Table.SelectedItem.ToString(), rows);//讀進

            }
            catch (Exception ex)
            {
              
            }
        }

        /// <summary>
        /// 播放該英文單字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewTabledata_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Play_word = dataGridViewTabledata.Rows[dataGridViewTabledata.CurrentCell.RowIndex].Cells["English"].Value.ToString();
            SpeakClass.Set_rate(int.Parse(comboBox_Rate.Text));
            SpeakClass.Set_volume(int.Parse(comboBox_volumn.Text));
            SpeakClass.Set_UseVoice(combobox_Voice.Text);
            SpeakClass.Speak(Play_word);

        }

        /// <summary>
        /// 按下播放的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Play_Click(object sender, EventArgs e)
        {
            if (State)//停止
            {
                button_Play.Text = "播放";
                State = false;

                Voice_run.Stop();//-停止自動播放
                WatchState.Stop();
            }
            else//播放
            {
                button_Play.Text = "停止";
                State = true;

                step = 0;//步驟從0開始

             
                Voice_run.Interval = int.Parse(comboBox_Intral.Text) * 1000;
               

                WatchState.Start();
            }
        }

        /// <summary>
        /// timer 的工作 ->播放單字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Play_Auto(object sender, EventArgs e)
        {
            WorkSpeak = new System.Threading.Thread(SpeakClass.Speak);
            if (step == 1 && WorkSpeak.IsAlive == false)
            {
                
                string Play_word = dataGridViewTabledata.Rows[dataGridViewTabledata.CurrentCell.RowIndex].Cells["English"].Value.ToString();
                SpeakClass.Set_rate(int.Parse(comboBox_Rate.Text));
                SpeakClass.Set_volume(int.Parse(comboBox_volumn.Text));
                SpeakClass.Set_Alphabet(Play_word);
            
                WorkSpeak.Start();
                step = 2;
            }

            if(step==2 && WorkSpeak.IsAlive ==false)
            {
                step = 3;
                
                Voice_run.Stop();
            }

        }

        private void Watch(object sender, EventArgs e)
        {
            //--先播放單字

            if (step == 0)
            {
                step = 1;
                Voice_run.Start();
            }
            else if (step == 3)
            {

                //以下是播完後的移動


                if (comboBox_playmode.Text == "循序播放")
                {
                    if (dataGridViewTabledata.CurrentCell.RowIndex == dataGridViewTabledata.Rows.Count - 1)//到結尾了
                    {

                        //從0開始移動
                        dataGridViewTabledata.FirstDisplayedScrollingRowIndex = 0;//scrobar 移到回到最上面
                        dataGridViewTabledata.CurrentCell = this.dataGridViewTabledata[0, 0];
                    }
                    else//往下移動
                    {
                        dataGridViewTabledata.CurrentCell = this.dataGridViewTabledata[0, dataGridViewTabledata.CurrentCell.RowIndex + 1];

                        if (dataGridViewTabledata.CurrentCell.RowIndex <= 2)
                        {
                        }
                        else if ((dataGridViewTabledata.Rows.Count - dataGridViewTabledata.CurrentCell.RowIndex) > 0)
                        {
                            dataGridViewTabledata.FirstDisplayedScrollingRowIndex = dataGridViewTabledata.CurrentCell.RowIndex-2 + 1;//scrobar 跟著移動
                        }
                    }

                }
                else if (comboBox_playmode.Text == "重複播放")
                {

                }
                else if (comboBox_playmode.Text == "隨機播放")
                {
                    int Move = Ram.Next(0, dataGridViewTabledata.Rows.Count);
                    dataGridViewTabledata.CurrentCell = this.dataGridViewTabledata[0, Move];

                    if (dataGridViewTabledata.CurrentCell.RowIndex <= 2)
                    { 
                    }
                    else if ((dataGridViewTabledata.Rows.Count - dataGridViewTabledata.CurrentCell.RowIndex) > 0)
                    {
                        dataGridViewTabledata.FirstDisplayedScrollingRowIndex = dataGridViewTabledata.CurrentCell.RowIndex-2 +1;//scrobar 跟著移動
                    }
                }

                step = 0;
            }
        }
        //--- The End
    }
}
