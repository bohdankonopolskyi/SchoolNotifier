namespace SchoolNotifier.Interface
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
            this.disableBtn = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.notificationComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SelectScheduleBtn
            // 
            this.SelectScheduleBtn.Location = new System.Drawing.Point(509, 142);
            this.SelectScheduleBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectScheduleBtn.Name = "SelectScheduleBtn";
            this.SelectScheduleBtn.Size = new System.Drawing.Size(155, 23);
            this.SelectScheduleBtn.TabIndex = 0;
            this.SelectScheduleBtn.Text = "Обрати розклад";
            this.SelectScheduleBtn.UseVisualStyleBackColor = true;
            this.SelectScheduleBtn.Click += new System.EventHandler(this.SelectScheduleBtn_Click);
            // 
            // scheduleFilePathTextBox
            // 
            this.scheduleFilePathTextBox.Location = new System.Drawing.Point(43, 142);
            this.scheduleFilePathTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scheduleFilePathTextBox.Name = "scheduleFilePathTextBox";
            this.scheduleFilePathTextBox.Size = new System.Drawing.Size(431, 23);
            this.scheduleFilePathTextBox.TabIndex = 1;
            // 
            // selectAudioFileBtn
            // 
            this.selectAudioFileBtn.Location = new System.Drawing.Point(509, 89);
            this.selectAudioFileBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectAudioFileBtn.Name = "selectAudioFileBtn";
            this.selectAudioFileBtn.Size = new System.Drawing.Size(155, 23);
            this.selectAudioFileBtn.TabIndex = 2;
            this.selectAudioFileBtn.Text = "Обрати аудіо";
            this.selectAudioFileBtn.UseVisualStyleBackColor = true;
            this.selectAudioFileBtn.Click += new System.EventHandler(this.selectAudioFileBtn_Click);
            // 
            // audioFilePathTextBox
            // 
            this.audioFilePathTextBox.Location = new System.Drawing.Point(43, 89);
            this.audioFilePathTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.audioFilePathTextBox.Name = "audioFilePathTextBox";
            this.audioFilePathTextBox.Size = new System.Drawing.Size(431, 23);
            this.audioFilePathTextBox.TabIndex = 3;
            // 
            // activateBtn
            // 
            this.activateBtn.Location = new System.Drawing.Point(91, 190);
            this.activateBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.activateBtn.Name = "activateBtn";
            this.activateBtn.Size = new System.Drawing.Size(88, 27);
            this.activateBtn.TabIndex = 4;
            this.activateBtn.Text = "Активувати";
            this.activateBtn.UseVisualStyleBackColor = true;
            this.activateBtn.Click += new System.EventHandler(this.activateBtn_Click);
            // 
            // disableBtn
            // 
            this.disableBtn.Location = new System.Drawing.Point(341, 190);
            this.disableBtn.Name = "disableBtn";
            this.disableBtn.Size = new System.Drawing.Size(96, 23);
            this.disableBtn.TabIndex = 5;
            this.disableBtn.Text = "Деактивувати";
            this.disableBtn.UseVisualStyleBackColor = true;
            this.disableBtn.Click += new System.EventHandler(this.disableBtn_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(43, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(431, 23);
            this.nameTextBox.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(45, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 15);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name";
            // 
            // notificationComboBox
            // 
            this.notificationComboBox.FormattingEnabled = true;
            this.notificationComboBox.Location = new System.Drawing.Point(509, 40);
            this.notificationComboBox.Name = "notificationComboBox";
            this.notificationComboBox.Size = new System.Drawing.Size(249, 23);
            this.notificationComboBox.TabIndex = 8;
            this.notificationComboBox.SelectedIndexChanged += new System.EventHandler(this.notificationComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 281);
            this.Controls.Add(this.notificationComboBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.disableBtn);
            this.Controls.Add(this.activateBtn);
            this.Controls.Add(this.audioFilePathTextBox);
            this.Controls.Add(this.selectAudioFileBtn);
            this.Controls.Add(this.scheduleFilePathTextBox);
            this.Controls.Add(this.SelectScheduleBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectScheduleBtn;
        private System.Windows.Forms.TextBox scheduleFilePathTextBox;
        private System.Windows.Forms.Button selectAudioFileBtn;
        private System.Windows.Forms.TextBox audioFilePathTextBox;
        private System.Windows.Forms.Button activateBtn;
        private Button disableBtn;
        private TextBox nameTextBox;
        private Label nameLabel;
        private ComboBox notificationComboBox;
    }
}

