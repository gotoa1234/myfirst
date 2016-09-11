using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlphabetDictionaryGGJM.BuildAlphabetSystem;

namespace AlphabetDictionaryGGJM
{
    public partial class AlphabetDictionaryMain : Form
    {
        BuildAlphabetSystemMainForm BASMF = new BuildAlphabetSystemMainForm();//建立字詞庫的Form 
        AlphabetPracticeSystem.AlphabetPracticeSystem APSF = new AlphabetPracticeSystem.AlphabetPracticeSystem();//字詞庫閱讀
        AlphabetQuizSystem.AlphabetQuizSystem AQS = new AlphabetQuizSystem.AlphabetQuizSystem();//字詞庫測驗
        AlphabetQuicklyQuizSystem.AlphabetQuicklyQuizSystem AQQS = new AlphabetQuicklyQuizSystem.AlphabetQuicklyQuizSystem();//速讀測試

        public AlphabetDictionaryMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 建立字詞庫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildAlphabetSystem_Click(object sender, EventArgs e)
        {
            BASMF.Get_Form(this);//告知對方自己的Form 以便於顯示
            BASMF.Show();//--------開啟對方
            this.Hide();//---------自己隱藏
        }

        /// <summary>
        /// 字詞庫閱讀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlphabetPracticeSystem_Click(object sender, EventArgs e)
        {
            APSF.Get_Form(this);//告知對方自己的Form 以便於顯示
            APSF.Show();//--------開啟對方
            this.Hide();//---------自己隱藏
        }

        /// <summary>
        /// 字詞庫練習
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlphabetQuizSystem_Click(object sender, EventArgs e)
        {
            AQS.Get_Form(this);
            AQS.Show();
            this.Hide();
        }

        /// <summary>
        /// 字詞庫腦速練習
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlphabetQuicklyQuizSystem_Click(object sender, EventArgs e)
        {
            AQQS.Get_Form(this);
            AQQS.Show();
            this.Hide();
        }
    }
}
