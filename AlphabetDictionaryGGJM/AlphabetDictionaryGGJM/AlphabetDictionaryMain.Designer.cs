namespace AlphabetDictionaryGGJM
{
    partial class AlphabetDictionaryMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BuildAlphabetSystem = new System.Windows.Forms.Button();
            this.AlphabetPracticeSystem = new System.Windows.Forms.Button();
            this.AlphabetQuizSystem = new System.Windows.Forms.Button();
            this.AlphabetQuicklyQuizSystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuildAlphabetSystem
            // 
            this.BuildAlphabetSystem.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BuildAlphabetSystem.Location = new System.Drawing.Point(12, 12);
            this.BuildAlphabetSystem.Name = "BuildAlphabetSystem";
            this.BuildAlphabetSystem.Size = new System.Drawing.Size(268, 48);
            this.BuildAlphabetSystem.TabIndex = 0;
            this.BuildAlphabetSystem.Text = "建立字詞庫";
            this.BuildAlphabetSystem.UseVisualStyleBackColor = true;
            this.BuildAlphabetSystem.Click += new System.EventHandler(this.BuildAlphabetSystem_Click);
            // 
            // AlphabetPracticeSystem
            // 
            this.AlphabetPracticeSystem.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AlphabetPracticeSystem.Location = new System.Drawing.Point(12, 78);
            this.AlphabetPracticeSystem.Name = "AlphabetPracticeSystem";
            this.AlphabetPracticeSystem.Size = new System.Drawing.Size(268, 48);
            this.AlphabetPracticeSystem.TabIndex = 1;
            this.AlphabetPracticeSystem.Text = "字詞庫閱讀";
            this.AlphabetPracticeSystem.UseVisualStyleBackColor = true;
            this.AlphabetPracticeSystem.Click += new System.EventHandler(this.AlphabetPracticeSystem_Click);
            // 
            // AlphabetQuizSystem
            // 
            this.AlphabetQuizSystem.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AlphabetQuizSystem.Location = new System.Drawing.Point(12, 146);
            this.AlphabetQuizSystem.Name = "AlphabetQuizSystem";
            this.AlphabetQuizSystem.Size = new System.Drawing.Size(268, 48);
            this.AlphabetQuizSystem.TabIndex = 2;
            this.AlphabetQuizSystem.Text = "字詞庫測驗";
            this.AlphabetQuizSystem.UseVisualStyleBackColor = true;
            this.AlphabetQuizSystem.Click += new System.EventHandler(this.AlphabetQuizSystem_Click);
            // 
            // AlphabetQuicklyQuizSystem
            // 
            this.AlphabetQuicklyQuizSystem.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AlphabetQuicklyQuizSystem.Location = new System.Drawing.Point(12, 213);
            this.AlphabetQuicklyQuizSystem.Name = "AlphabetQuicklyQuizSystem";
            this.AlphabetQuicklyQuizSystem.Size = new System.Drawing.Size(268, 48);
            this.AlphabetQuicklyQuizSystem.TabIndex = 3;
            this.AlphabetQuicklyQuizSystem.Text = "字詞庫腦速測驗";
            this.AlphabetQuicklyQuizSystem.UseVisualStyleBackColor = true;
            this.AlphabetQuicklyQuizSystem.Click += new System.EventHandler(this.AlphabetQuicklyQuizSystem_Click);
            // 
            // AlphabetDictionaryMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.AlphabetQuicklyQuizSystem);
            this.Controls.Add(this.AlphabetQuizSystem);
            this.Controls.Add(this.AlphabetPracticeSystem);
            this.Controls.Add(this.BuildAlphabetSystem);
            this.Name = "AlphabetDictionaryMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "單字字典工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildAlphabetSystem;
        private System.Windows.Forms.Button AlphabetPracticeSystem;
        private System.Windows.Forms.Button AlphabetQuizSystem;
        private System.Windows.Forms.Button AlphabetQuicklyQuizSystem;
    }
}

