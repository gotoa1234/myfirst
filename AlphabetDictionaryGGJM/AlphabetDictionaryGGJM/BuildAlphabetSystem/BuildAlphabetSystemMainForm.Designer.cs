namespace AlphabetDictionaryGGJM.BuildAlphabetSystem
{
    partial class BuildAlphabetSystemMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AlphabetDataBaseDropdownList = new System.Windows.Forms.ComboBox();
            this.BuildTabletButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NowName_textbox = new System.Windows.Forms.TextBox();
            this.state_label = new System.Windows.Forms.Label();
            this.dataGridViewTabledata = new System.Windows.Forms.DataGridView();
            this.English = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chinese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.English_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chinese_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.noun_checkBox = new System.Windows.Forms.CheckBox();
            this.pronoun_checkBox = new System.Windows.Forms.CheckBox();
            this.adjective_checkBox = new System.Windows.Forms.CheckBox();
            this.verb_checkBox = new System.Windows.Forms.CheckBox();
            this.adverb_checkBox = new System.Windows.Forms.CheckBox();
            this.preposition_checkBox = new System.Windows.Forms.CheckBox();
            this.conjunction_checkBox = new System.Windows.Forms.CheckBox();
            this.interjection_checkBox = new System.Windows.Forms.CheckBox();
            this.DeleteMode_checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabledata)).BeginInit();
            this.SuspendLayout();
            // 
            // AlphabetDataBaseDropdownList
            // 
            this.AlphabetDataBaseDropdownList.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AlphabetDataBaseDropdownList.FormattingEnabled = true;
            this.AlphabetDataBaseDropdownList.Location = new System.Drawing.Point(12, 4);
            this.AlphabetDataBaseDropdownList.Name = "AlphabetDataBaseDropdownList";
            this.AlphabetDataBaseDropdownList.Size = new System.Drawing.Size(245, 39);
            this.AlphabetDataBaseDropdownList.TabIndex = 1;
            this.AlphabetDataBaseDropdownList.TabStop = false;
            this.AlphabetDataBaseDropdownList.SelectedIndexChanged += new System.EventHandler(this.AlphabetDataBaseDropdownList_SelectedIndexChanged);
            // 
            // BuildTabletButton
            // 
            this.BuildTabletButton.Enabled = false;
            this.BuildTabletButton.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BuildTabletButton.Location = new System.Drawing.Point(263, 29);
            this.BuildTabletButton.Name = "BuildTabletButton";
            this.BuildTabletButton.Size = new System.Drawing.Size(180, 22);
            this.BuildTabletButton.TabIndex = 2;
            this.BuildTabletButton.TabStop = false;
            this.BuildTabletButton.Text = "建立";
            this.BuildTabletButton.UseVisualStyleBackColor = true;
            this.BuildTabletButton.Click += new System.EventHandler(this.BuildTabletButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(263, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "當前資料表名稱：";
            // 
            // NowName_textbox
            // 
            this.NowName_textbox.Location = new System.Drawing.Point(457, 4);
            this.NowName_textbox.Name = "NowName_textbox";
            this.NowName_textbox.ReadOnly = true;
            this.NowName_textbox.Size = new System.Drawing.Size(547, 22);
            this.NowName_textbox.TabIndex = 4;
            this.NowName_textbox.TabStop = false;
            // 
            // state_label
            // 
            this.state_label.AutoSize = true;
            this.state_label.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.state_label.Location = new System.Drawing.Point(449, 25);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(75, 26);
            this.state_label.TabIndex = 15;
            this.state_label.Text = "狀態：";
            // 
            // dataGridViewTabledata
            // 
            this.dataGridViewTabledata.AllowUserToAddRows = false;
            this.dataGridViewTabledata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTabledata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTabledata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabledata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.English,
            this.chinese});
            this.dataGridViewTabledata.Location = new System.Drawing.Point(12, 73);
            this.dataGridViewTabledata.Name = "dataGridViewTabledata";
            this.dataGridViewTabledata.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTabledata.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(250)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dataGridViewTabledata.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTabledata.RowTemplate.Height = 48;
            this.dataGridViewTabledata.Size = new System.Drawing.Size(992, 456);
            this.dataGridViewTabledata.TabIndex = 6;
            this.dataGridViewTabledata.TabStop = false;
            this.dataGridViewTabledata.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTabledata_RowHeaderMouseDoubleClick);
            // 
            // English
            // 
            this.English.HeaderText = "英文";
            this.English.Name = "English";
            this.English.ReadOnly = true;
            this.English.Width = 320;
            // 
            // chinese
            // 
            this.chinese.HeaderText = "中文";
            this.chinese.MinimumWidth = 15;
            this.chinese.Name = "chinese";
            this.chinese.ReadOnly = true;
            this.chinese.Width = 620;
            // 
            // English_textbox
            // 
            this.English_textbox.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.English_textbox.Location = new System.Drawing.Point(148, 535);
            this.English_textbox.Name = "English_textbox";
            this.English_textbox.Size = new System.Drawing.Size(856, 57);
            this.English_textbox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(8, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 40);
            this.label2.TabIndex = 8;
            this.label2.Text = "英文結構";
            // 
            // chinese_textBox
            // 
            this.chinese_textBox.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chinese_textBox.Location = new System.Drawing.Point(148, 598);
            this.chinese_textBox.Name = "chinese_textBox";
            this.chinese_textBox.Size = new System.Drawing.Size(856, 57);
            this.chinese_textBox.TabIndex = 20;
            this.chinese_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chinese_textBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(8, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 40);
            this.label3.TabIndex = 10;
            this.label3.Text = "中文解釋";
            // 
            // noun_checkBox
            // 
            this.noun_checkBox.AutoSize = true;
            this.noun_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.noun_checkBox.Location = new System.Drawing.Point(5, 658);
            this.noun_checkBox.Name = "noun_checkBox";
            this.noun_checkBox.Size = new System.Drawing.Size(166, 28);
            this.noun_checkBox.TabIndex = 11;
            this.noun_checkBox.Text = "名詞 (noun) n.";
            this.noun_checkBox.UseVisualStyleBackColor = true;
            // 
            // pronoun_checkBox
            // 
            this.pronoun_checkBox.AutoSize = true;
            this.pronoun_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pronoun_checkBox.Location = new System.Drawing.Point(288, 657);
            this.pronoun_checkBox.Name = "pronoun_checkBox";
            this.pronoun_checkBox.Size = new System.Drawing.Size(250, 28);
            this.pronoun_checkBox.TabIndex = 12;
            this.pronoun_checkBox.Text = "代名詞 (pronoun) pron.";
            this.pronoun_checkBox.UseVisualStyleBackColor = true;
            // 
            // adjective_checkBox
            // 
            this.adjective_checkBox.AutoSize = true;
            this.adjective_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.adjective_checkBox.Location = new System.Drawing.Point(530, 657);
            this.adjective_checkBox.Name = "adjective_checkBox";
            this.adjective_checkBox.Size = new System.Drawing.Size(242, 28);
            this.adjective_checkBox.TabIndex = 13;
            this.adjective_checkBox.Text = "形容詞 (adjective) adj.";
            this.adjective_checkBox.UseVisualStyleBackColor = true;
            // 
            // verb_checkBox
            // 
            this.verb_checkBox.AutoSize = true;
            this.verb_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.verb_checkBox.Location = new System.Drawing.Point(5, 685);
            this.verb_checkBox.Name = "verb_checkBox";
            this.verb_checkBox.Size = new System.Drawing.Size(162, 28);
            this.verb_checkBox.TabIndex = 14;
            this.verb_checkBox.Text = "動詞 (verb) v.";
            this.verb_checkBox.UseVisualStyleBackColor = true;
            // 
            // adverb_checkBox
            // 
            this.adverb_checkBox.AutoSize = true;
            this.adverb_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.adverb_checkBox.Location = new System.Drawing.Point(288, 685);
            this.adverb_checkBox.Name = "adverb_checkBox";
            this.adverb_checkBox.Size = new System.Drawing.Size(204, 28);
            this.adverb_checkBox.TabIndex = 15;
            this.adverb_checkBox.Text = "副詞 (adverb) adv.";
            this.adverb_checkBox.UseVisualStyleBackColor = true;
            // 
            // preposition_checkBox
            // 
            this.preposition_checkBox.AutoSize = true;
            this.preposition_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.preposition_checkBox.Location = new System.Drawing.Point(530, 685);
            this.preposition_checkBox.Name = "preposition_checkBox";
            this.preposition_checkBox.Size = new System.Drawing.Size(275, 28);
            this.preposition_checkBox.TabIndex = 16;
            this.preposition_checkBox.Text = "介系詞 (preposition) prep.";
            this.preposition_checkBox.UseVisualStyleBackColor = true;
            // 
            // conjunction_checkBox
            // 
            this.conjunction_checkBox.AutoSize = true;
            this.conjunction_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.conjunction_checkBox.Location = new System.Drawing.Point(5, 710);
            this.conjunction_checkBox.Name = "conjunction_checkBox";
            this.conjunction_checkBox.Size = new System.Drawing.Size(277, 28);
            this.conjunction_checkBox.TabIndex = 17;
            this.conjunction_checkBox.Text = "連接詞 (conjunction) conj.";
            this.conjunction_checkBox.UseVisualStyleBackColor = true;
            // 
            // interjection_checkBox
            // 
            this.interjection_checkBox.AutoSize = true;
            this.interjection_checkBox.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.interjection_checkBox.Location = new System.Drawing.Point(288, 710);
            this.interjection_checkBox.Name = "interjection_checkBox";
            this.interjection_checkBox.Size = new System.Drawing.Size(259, 28);
            this.interjection_checkBox.TabIndex = 18;
            this.interjection_checkBox.Text = "感嘆詞 (interjection) int.";
            this.interjection_checkBox.UseVisualStyleBackColor = true;
            // 
            // DeleteMode_checkbox
            // 
            this.DeleteMode_checkbox.AutoSize = true;
            this.DeleteMode_checkbox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DeleteMode_checkbox.Location = new System.Drawing.Point(12, 49);
            this.DeleteMode_checkbox.Name = "DeleteMode_checkbox";
            this.DeleteMode_checkbox.Size = new System.Drawing.Size(275, 20);
            this.DeleteMode_checkbox.TabIndex = 19;
            this.DeleteMode_checkbox.TabStop = false;
            this.DeleteMode_checkbox.Text = "開啟移除模式(點擊行首兩下移除一筆單字資料)";
            this.DeleteMode_checkbox.UseVisualStyleBackColor = true;
            // 
            // BuildAlphabetSystemMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.interjection_checkBox);
            this.Controls.Add(this.conjunction_checkBox);
            this.Controls.Add(this.preposition_checkBox);
            this.Controls.Add(this.adverb_checkBox);
            this.Controls.Add(this.verb_checkBox);
            this.Controls.Add(this.adjective_checkBox);
            this.Controls.Add(this.pronoun_checkBox);
            this.Controls.Add(this.noun_checkBox);
            this.Controls.Add(this.chinese_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.English_textbox);
            this.Controls.Add(this.dataGridViewTabledata);
            this.Controls.Add(this.NowName_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuildTabletButton);
            this.Controls.Add(this.AlphabetDataBaseDropdownList);
            this.Controls.Add(this.state_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeleteMode_checkbox);
            this.MaximizeBox = false;
            this.Name = "BuildAlphabetSystemMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "建立字詞庫";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuildAlphabetSystemMainForm_FormClosing);
            this.Load += new System.EventHandler(this.BuildAlphabetSystemMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabledata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AlphabetDataBaseDropdownList;
        private System.Windows.Forms.Button BuildTabletButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NowName_textbox;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.DataGridView dataGridViewTabledata;
        private System.Windows.Forms.TextBox English_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chinese_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox noun_checkBox;
        private System.Windows.Forms.CheckBox pronoun_checkBox;
        private System.Windows.Forms.CheckBox adjective_checkBox;
        private System.Windows.Forms.CheckBox verb_checkBox;
        private System.Windows.Forms.CheckBox adverb_checkBox;
        private System.Windows.Forms.CheckBox preposition_checkBox;
        private System.Windows.Forms.CheckBox conjunction_checkBox;
        private System.Windows.Forms.CheckBox interjection_checkBox;
        private System.Windows.Forms.CheckBox DeleteMode_checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn English;
        private System.Windows.Forms.DataGridViewTextBoxColumn chinese;
    }
}