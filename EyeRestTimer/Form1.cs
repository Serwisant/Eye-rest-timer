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
        private Countdown countdown;

        public Form1()
        {
            InitializeComponent();

            countdown = new Countdown();
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            alarmFileChooser = new OpenFileDialog();
            alarmFileChooser.ShowDialog();

            char[] separator = new char[] { '\\' };

            String[] pathTokens = alarmFileChooser.FileName.Split(separator);
            String filename = pathTokens.Last();

            alarmFilePathTextBox.Text = filename;

            trayIcon.Visible = true;
            trayIcon.BalloonTipTitle = "Test title";
            trayIcon.BalloonTipText = filename;
            trayIcon.ShowBalloonTip(10000, "Test title", filename + " has been choosen!", ToolTipIcon.Info);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            countdown.tickSecond();
            //TODO: observer?
        }

        private void timerNumber_ValueChanged(object sender, EventArgs e)
        {
            int workTime = (int)timerNumber.Value * 60;
            countdown.setWorktime(workTime);
        }

        private void breakNumber_ValueChanged(object sender, EventArgs e)
        {
            int breakLenght = (int)breakNumber.Value;
            countdown.setBreakLength(breakLenght);
        }
    }
}
