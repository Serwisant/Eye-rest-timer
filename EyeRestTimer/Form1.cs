using System;
using System.Windows.Forms;

namespace EyeRestTimer
{
    public partial class MainWindow : Form
    {
        private Countdown countdown;
        private Alarm alarm;
        
        //TODO: "Start with windows" setting?
        //TODO: "Continue playing after break" setting?
        //TODO: "Save settings" setting
        //TODO: Default alarm?
        //TODO: AlarmFilepath?

        public MainWindow()
        {
            InitializeComponent();

            initializeAlarm();
            initializeCountdown();
        }

        private void initializeAlarm()
        {
            alarm = new Alarm();
        }

        private void initializeCountdown()
        {
            countdown = new Countdown();
            countdown.setAlarm(alarm);
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            String filePath = AlarmFileChooser.getFilePath();

            if (filePath == "")
                return;

            changeAlarmFile(filePath);
        }

        private void changeAlarmFile(String filepath)
        {
            try
            {
                alarm.tryToSetAlarmFile(filepath);
            }
            catch (InvalidAlarmFile)
            {
                MessageBox.Show("Invalid alarm file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            alarmFilePathTextBox.Text = filepath;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            countdown.tickSecond();

            changeRemainingTimeText();
            if (changedToBreakTime())
                showBaloon();
        }

        private void changeRemainingTimeText()
        {
            int remainingTime = countdown.getRemainingTime();

            this.Text = $"Remaining: {remainingTime} seconds";
            trayIcon.Text = $"Remaining: {remainingTime} seconds";
        }

        private bool changedToBreakTime()
        {
            return countdown.getRemainingTime() == 0 && countdown.getCurrentMode() == Countdown.MODE.WORK;
        }

        private void showBaloon()
        {
            trayIcon.ShowBalloonTip(20000, "Break time!", "It's time for a short break!", ToolTipIcon.Info);
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

        private void playAlarmCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            countdown.playAlarmDuringBreak(playAlarmCheckBox.Checked);
        }

        private void HoldButton_Click(object sender, EventArgs e)
        {
            bool isTimerRunning = timer.Enabled;

            if (isTimerRunning)
                holdCountdown();
            else
                resumeCountdown();
        }

        private void holdCountdown()
        {
            timer.Enabled = false;
            HoldButton.Text = "Resume";
            alarm.stop();
        }

        private void resumeCountdown()
        {
            timer.Enabled = true;
            HoldButton.Text = "Hold";
        }
    }
}