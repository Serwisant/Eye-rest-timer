using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeRestTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            alarmFileChooser = new OpenFileDialog();
            alarmFileChooser.ShowDialog();

            char[] separator = new char[] { '\\' };

            String[] pathTokens = alarmFileChooser.FileName.Split(separator);
            String filename = pathTokens.Last();

            alarmFilePathTextBox.Text = filename;
        }
    }
}
