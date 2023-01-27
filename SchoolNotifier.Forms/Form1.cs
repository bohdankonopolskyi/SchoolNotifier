using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolNotifier.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectScheduleBtn_Click(object sender, EventArgs e)
        { 
            string filePath = OpenDialog("txt files (*.txt)|*.txt|All files (*.*)|*.*");

            scheduleFilePathTextBox.Text = filePath;
        }

        private void selectAudioFileBtn_Click(object sender, EventArgs e)
        {
            string filePath = OpenDialog();

            audioFilePathTextBox.Text = filePath;
        }

        private string OpenDialog(string filter = "")
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(filter.Length != 0) { openFileDialog.Filter = filter; }
          
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
