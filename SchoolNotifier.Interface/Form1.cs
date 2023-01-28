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
using SchoolNotifier;

namespace SchoolNotifier.Interface
{
    public partial class Form1 : Form
    {
        private string _scheduleFilePath = Environment.CurrentDirectory;
        private string _audioFilePath = Environment.CurrentDirectory;
        private DailyTriggerSetuper _setuper;
        private IFileReader _reader;
        public Form1()
        {
            InitializeComponent();
           _reader = new ScheduleFileReader();
            _setuper = new  DailyTriggerSetuper(_reader);
        }

        private void SelectScheduleBtn_Click(object sender, EventArgs e)
        {
            string filePath = OpenDialog("txt files (*.txt)|*.txt|All files (*.*)|*.*");

            scheduleFilePathTextBox.Text = filePath;
        }

        private void selectAudioFileBtn_Click(object sender, EventArgs e)
        {
            string filePath = OpenDialog("wav files (*.wav)|*.wav|All files (*.*)|*.*");
           
            _audioFilePath = filePath;
            audioFilePathTextBox.Text = filePath;

            var filetype = "sound" + Path.GetExtension(filePath);
            audioFilePathTextBox.Text = filetype;
            overWriteFile(filePath, _audioFilePath, filetype);
        }

        private void overWriteFile(string source, string destination, string defaultFileName)
        {
            if(string.IsNullOrEmpty(source))
            {
                return;
            }

            var destinationFile = string.IsNullOrEmpty(Path.GetFileName(destination)) ? Path.GetFileName(destination) : defaultFileName;
            destination = Path.Combine(Environment.CurrentDirectory, destinationFile);

            File.Copy(source, destination, overwrite: true);

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
            var player = new SoundPlayer(_audioFilePath);

            Action action = () => player.Play();

            _setuper.SetUpIntervals(_scheduleFilePath);
            _setuper.SubscribeTriggers(action);
        }

        private void disableBtn_Click(object sender, EventArgs e)
        {
            _setuper.UnsubscribeTriggers();
        }
    }
}
