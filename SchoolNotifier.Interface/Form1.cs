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
using NotifierService.EventTrigger;
using NotifierData.JSON;
using NotifierData.Models;

namespace SchoolNotifier.Interface
{
    public partial class Form1 : Form
    {
        private string configFile = "notifications.json";
        private string _scheduleFilePath = Environment.CurrentDirectory;
        private string _audioFilePath = Environment.CurrentDirectory;
        private IConfigurator _configurator;

        private DailyTriggerService _setuper;
        private IFileManager _fileManager;
        private IJSONRepository<List<Notification>> _jSONRepository;
        
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

        private async void activateBtn_Click(object sender, EventArgs e)
        {
           await SetupNotificationAsync();
        }

        private async void disableBtn_Click(object sender, EventArgs e)
        {
            _setuper.UnsubscribeTriggers(_currentNotification.Id);
           await _setuper.RemoveNotificationAsync(_currentNotification.Id);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _fileManager = new ScheduleFileManager();
            _jSONRepository = new JSONRepository(configFile);
            _setuper = new DailyTriggerService(_jSONRepository);

            _configurator = new Configurator(_setuper, _jSONRepository);
           await _configurator.SetConfiguration();

            notificationComboBox.DataSource = _jSONRepository.Data;
            
            notificationComboBox.DisplayMember = "Name";
        }

        private void notificationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentNotification = (Notification)notificationComboBox.SelectedItem;
            nameTextBox.Text = _currentNotification.Name;
            audioFilePathTextBox.Text = _currentNotification.AudioFilePath;

            _audioFilePath = Path.Combine(Environment.CurrentDirectory, _currentNotification.AudioFilePath);
            

        }

        private async Task SetupNotificationAsync()
        {
            _fileManager.ReadFile(_scheduleFilePath);
            var schedule = _fileManager.GetTimes();

            if (schedule.Count != 0)
            {
                var newFileName = nameTextBox.Text + Path.GetExtension(_audioFilePath);

                _fileManager.CopyFile(_audioFilePath, Environment.CurrentDirectory, newFileName); 

                Notification notification = new Notification(nameTextBox.Text, newFileName, schedule);

                _currentNotification = notification;
               await _setuper.AddNotificationAsync(notification);


                var player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory, notification.AudioFilePath));
                Action action = () => player.Play();

                _setuper.SubscribeTriggers(notification.Id, action);

                notificationComboBox.Refresh();
            }
        }
    }
}
