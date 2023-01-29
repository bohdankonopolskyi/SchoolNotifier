using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using SchoolNotifier.EventNotifications;
using SchoolNotifier.FileReader.JSON;
using NotifierService.EventTrigger;

namespace SchoolNotifier.Interface
{
    public partial class Form1 : Form
    {
        private string _scheduleFilePath = Environment.CurrentDirectory;
        private string _audioFilePath = Environment.CurrentDirectory;
        private DailyTriggerService _setuper;
        private IFileManager _fileManager;
        private JSONSerializer<List<Notification>> jSONSerializer;
        private List<Notification> _notifications;
        private Notification _currentNotification;
        public Form1()
        {
            InitializeComponent();
          
            
        }

        private void SelectScheduleBtn_Click(object sender, EventArgs e)
        {
            string filePath = OpenDialog("txt files (*.txt)|*.txt|All files (*.*)|*.*");

            scheduleFilePathTextBox.Text = filePath;

            _scheduleFilePath = filePath;

        }

        private void selectAudioFileBtn_Click(object sender, EventArgs e)
        {
            string filePath = OpenDialog("wav files (*.wav)|*.wav|All files (*.*)|*.*");
           
            _audioFilePath = filePath;
            audioFilePathTextBox.Text = filePath;

            var filetype = "sound" + Path.GetExtension(filePath);
            audioFilePathTextBox.Text = filetype;
           _fileManager.CopyFile(filePath, _audioFilePath, filetype);
        }

       

        private string OpenDialog(string filter = "")
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (filter.Length != 0)
            { openFileDialog.Filter = filter; }

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }

        private void activateBtn_Click(object sender, EventArgs e)
        {

            DailyTriggerService setuper = new DailyTriggerSetuper(_currentNotification);

            var player = new SoundPlayer(_audioFilePath);
            Action action = () => player.Play();

            _setuper.SetUpIntervals(_scheduleFilePath);
            _setuper.SubscribeTriggers(action);
        }

        private void disableBtn_Click(object sender, EventArgs e)
        {
            _setuper.UnsubscribeTriggers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _fileManager = new ScheduleFileReader();
            _setuper = new DailyTriggerSetuper(_fileManager);
            jSONSerializer = new JSONSerializer<List<Notification>>();

            _notifications = jSONSerializer.Deserialize("notifications.json").Result;

            notificationComboBox.DataSource = _notifications;

            notificationComboBox.DisplayMember = "Name";
        }

        private void notificationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentNotification = (Notification)notificationComboBox.SelectedItem;
            nameTextBox.Text = _currentNotification.Name;
            audioFilePathTextBox.Text = _currentNotification.AudioFilePath;

        }
    }
}
