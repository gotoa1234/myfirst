using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlphabetDictionaryGGJM.SqliteClass;

namespace AlphabetDictionaryGGJM.BuildAlphabetSystem
{
    public partial class BuildAlphabetSystemMainForm : Form
    {
        AlphabetDictionaryMain MainForm;//主視窗
        SqliteDB SQLMyDB = new SqliteDB();//---我的Sqlite工具
        List<string> DB = new List<string>();

        public BuildAlphabetSystemMainForm()
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
        /// Form_loading 初始載入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildAlphabetSystemMainForm_Load(object sender, EventArgs e)
        {

            DB = SQLMyDB.Get_Table_Index();
            DB.Add("建立新資料表");
            AlphabetDataBaseDropdownList.DataSource = DB;

            ///以下為八大詞性的動作
            noun_checkBox.KeyDown += Keypress_spece;
            pronoun_checkBox.KeyDown += Keypress_spece;
            adjective_checkBox.KeyDown += Keypress_spece;
            adverb_checkBox.KeyDown += Keypress_spece;
            verb_checkBox.KeyDown += Keypress_spece;
            preposition_checkBox.KeyDown += Keypress_spece;
            conjunction_checkBox.KeyDown += Keypress_spece;
            interjection_checkBox.KeyDown += Keypress_spece;

            noun_checkBox.Enter += Tab_Enter;
            pronoun_checkBox.Enter += Tab_Enter;
            adjective_checkBox.Enter += Tab_Enter;
            adverb_checkBox.Enter += Tab_Enter;
            verb_checkBox.Enter += Tab_Enter;
            preposition_checkBox.Enter += Tab_Enter;
            conjunction_checkBox.Enter += Tab_Enter;
            interjection_checkBox.Enter += Tab_Enter;

            noun_checkBox.Leave += Tab_Leave;
            pronoun_checkBox.Leave += Tab_Leave;
            adjective_checkBox.Leave += Tab_Leave;
            adverb_checkBox.Leave += Tab_Leave;
            verb_checkBox.Leave += Tab_Leave;
            preposition_checkBox.Leave += Tab_Leave;
            conjunction_checkBox.Leave += Tab_Leave;
            interjection_checkBox.Leave += Tab_Leave;
        }

        /// <summary>
        /// Form關閉時開啟原始的Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildAlphabetSystemMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            MainForm.Show();
        }

        /// <summary>
        /// 建立sqlite的單一資料表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildTabletButton_Click(object sender, EventArgs e)
        {
            try
            {
                    List<string> column = new List<string>();
                    column.Add("English");//---英文
                    column.Add("Chinese");//---中文

                    state_label.Text = "狀態：" + SQLMyDB.BuildeTable(NowName_textbox.Text, column);//建立Table
                    DB = SQLMyDB.Get_Table_Index();
                    DB.Add("建立新資料表");
                    AlphabetDataBaseDropdownList.DataSource = DB;
            }
            catch (Exception ex)
            {
                state_label.Text = "狀態：" + ex.Message;
            }

        }

        /// <summary>
        /// 當選擇的項目改變時要 做變化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlphabetDataBaseDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;

            if(comboBox.SelectedValue.ToString() == "建立新資料表")
            {
                NowName_textbox.ReadOnly = false;
                BuildTabletButton.Enabled = true;
                NowName_textbox.Text = "";
                dataGridViewTabledata.Rows.Clear();
            }
            else
            {
                NowName_textbox.ReadOnly = true;
                BuildTabletButton.Enabled = false;
                //並且讀資料庫
                NowName_textbox.Text = comboBox.Text;//當前資料表
                LoadGridData();//----------------------讀到griddata
               
            }
        }

        /// <summary>
        /// 中文結構-按下Enter時觸發
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chinese_textBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) 
            {
                if (English_textbox.Text != string.Empty && chinese_textBox.Text != string.Empty)
                {
                    //寫入資料庫
                    state_label.Text = "狀態：" + SQLMyDB.Write_Alphabet(NowName_textbox.Text, English_textbox.Text, chinese_textBox.Text);

                    //ReloadDB
                    LoadGridData();

                    //焦點再給英文結構
                    English_textbox.Focus();

                    //清空格子
                    English_textbox.Text="";
                    chinese_textBox.Text = "";
                }
                else
                {
                    state_label.Text = "狀態：" + "中文跟英文不可為空";
                }
            }

        }

        /// <summary>
        /// 當八大詞性按下空白鍵時的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="s"></param>
        private void Keypress_spece(object sender, KeyEventArgs e)
        {
            CheckBox control = (CheckBox)sender;
            if (e.KeyCode == Keys.Space)
            {

                if (control.Text == "名詞 (noun) n.")
                    chinese_textBox.Text += "【n.】";
                else if (control.Text == "代名詞 (pronoun) pron.")
                    chinese_textBox.Text += "【pron.】";
                else if (control.Text == "形容詞 (adjective) adj.")
                    chinese_textBox.Text += "【adj.】";
                else if (control.Text == "動詞 (verb) v.")
                    chinese_textBox.Text += "【v.】";
                else if (control.Text == "副詞 (adverb) adv.")
                    chinese_textBox.Text += "【adv.】";
                else if (control.Text == "介系詞 (preposition) prep.")
                    chinese_textBox.Text += "【prep.】";
                else if (control.Text == "連接詞 (conjunction) conj.")
                    chinese_textBox.Text += "【conj.】";
                else if (control.Text == "感嘆詞 (interjection) int.")
                    chinese_textBox.Text += "【int.】";

                chinese_textBox.Focus();//焦點在中文結構
                System.Windows.Forms.SendKeys.Send("{END}");//並且幫使用者按下End鍵
                control.Checked = false;
            }
            
        }

        /// <summary>
        /// 當焦點在八大詞性時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="s"></param>
        private void Tab_Enter(object sender, EventArgs e)
        {
            CheckBox control = (CheckBox)sender;
            control.Checked = true;
        }

        /// <summary>
        /// 當焦點離開八大詞性時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="s"></param>
        private void Tab_Leave(object sender, EventArgs e)
        {
            CheckBox control = (CheckBox)sender;
            control.Checked = false;
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
                SQLMyDB.Get_SelectTable(NowName_textbox.Text, rows);//讀進

                if (rows.Count > 0)
                {
                    rows[0].Selected = false;//------------第一筆記得要取消 windows預設選擇
                    rows[rows.Count - 1].Selected = true;//最新的資料放在最下方
                    dataGridViewTabledata.FirstDisplayedScrollingRowIndex = rows.Count - 1;//scrobar 移到最下方
                }

            }
            catch (Exception ex)
            {
                state_label.Text += "狀態：" + ex.Message;
            }
        }

        /// <summary>
        /// 按兩下資料列行首時 delete資料 - 需先將delete checkBox打勾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewTabledata_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DeleteMode_checkbox.Checked)
            {
                for (int i = 0; i < dataGridViewTabledata.Rows.Count; i++)
                {
                    if (dataGridViewTabledata.Rows[i].Selected)
                    {
                        state_label.Text = SQLMyDB.Delete_Alphabet(NowName_textbox.Text, dataGridViewTabledata.Rows[i].Cells["English"].Value.ToString(), dataGridViewTabledata.Rows[i].Cells["chinese"].Value.ToString());
                        LoadGridData();
                        break;
                    }
                }
            }
        }


        ///========The End
    }
}
