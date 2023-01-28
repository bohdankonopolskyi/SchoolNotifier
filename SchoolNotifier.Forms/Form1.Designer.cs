namespace SchoolNotifier.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectScheduleBtn = new System.Windows.Forms.Button();
            this.scheduleFilePathTextBox = new System.Windows.Forms.TextBox();
            this.selectAudioFileBtn = new System.Windows.Forms.Button();
            this.audioFilePathTextBox = new System.Windows.Forms.TextBox();
            this.activateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectScheduleBtn
            // 
            this.SelectScheduleBtn.Location = new System.Drawing.Point(107, 245);
            this.SelectScheduleBtn.Name = "SelectScheduleBtn";
            this.SelectScheduleBtn.Size = new System.Drawing.Size(259, 34);
            this.SelectScheduleBtn.TabIndex = 0;
            this.SelectScheduleBtn.Text = "Обрати розклад";
            this.SelectScheduleBtn.UseVisualStyleBackColor = true;
            this.SelectScheduleBtn.Click += new System.EventHandler(this.SelectScheduleBtn_Click);
            // 
            // scheduleFilePathTextBox
            // 
            this.scheduleFilePathTextBox.Location = new System.Drawing.Point(28, 200);
            this.scheduleFilePathTextBox.Name = "scheduleFilePathTextBox";
            this.scheduleFilePathTextBox.Size = new System.Drawing.Size(412, 20);
            this.scheduleFilePathTextBox.TabIndex = 1;
            // 
            // selectAudioFileBtn
            // 
            this.selectAudioFileBtn.Location = new System.Drawing.Point(640, 255);
            this.selectAudioFileBtn.Name = "selectAudioFileBtn";
            this.selectAudioFileBtn.Size = new System.Drawing.Size(133, 23);
            this.selectAudioFileBtn.TabIndex = 2;
            this.selectAudioFileBtn.Text = "Обрати аудіо";
            this.selectAudioFileBtn.UseVisualStyleBackColor = true;
            this.selectAudioFileBtn.Click += new System.EventHandler(this.selectAudioFileBtn_Click);
            // 
            // audioFilePathTextBox
            // 
            this.audioFilePathTextBox.Location = new System.Drawing.Point(546, 200);
            this.audioFilePathTextBox.Name = "audioFilePathTextBox";
            this.audioFilePathTextBox.Size = new System.Drawing.Size(370, 20);
            this.audioFilePathTextBox.TabIndex = 3;
            // 
            // activateBtn
            // 
            this.activateBtn.Location = new System.Drawing.Point(37, 396);
            this.activateBtn.Name = "activateBtn";
            this.activateBtn.Size = new System.Drawing.Size(75, 23);
            this.activateBtn.TabIndex = 4;
            this.activateBtn.Text = "Активувати";
            this.activateBtn.UseVisualStyleBackColor = true;
            this.activateBtn.Click += new System.EventHandler(this.activateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 652);
            this.Controls.Add(this.activateBtn);
            this.Controls.Add(this.audioFilePathTextBox);
            this.Controls.Add(this.selectAudioFileBtn);
            this.Controls.Add(this.scheduleFilePathTextBox);
            this.Controls.Add(this.SelectScheduleBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectScheduleBtn;
        private System.Windows.Forms.TextBox scheduleFilePathTextBox;
        private System.Windows.Forms.Button selectAudioFileBtn;
        private System.Windows.Forms.TextBox audioFilePathTextBox;
        private System.Windows.Forms.Button activateBtn;
    }
}

