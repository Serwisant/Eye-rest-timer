using System;
using System.Windows.Forms;

namespace EyeRestTimer
{
    public partial class MainWindow : Form
    {
        private Countdown countdown;
        private Alarm alarm;

        //TODO: "Hold" button
        //TODO: "Start with windows" setting?
        //TODO: Disable alarm, just a baloon tip

        public MainWindow()
        {
            InitializeComponent();

            countdown = new Countdown();
            timer.Enabled = true;
            alarm = new Alarm();
            countdown.setAlarm(alarm);
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            String filePath = AlarmFileChooser.getFilePath();

            alarm.setAlarmFile(filePath);
            alarmFilePathTextBox.Text = filePath;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            countdown.tickSecond();
            Text = $"Remaining: {countdown.getRemainingTime()} seconds";
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
