﻿using System;
using System.Windows.Forms;

namespace EyeRestTimer
{
    public partial class MainWindow : Form
    {
        private Countdown countdown;

        public MainWindow()
        {
            InitializeComponent();

            initializeCountdown();

            restoreSettings();
        }

        private void initializeCountdown()
        {
            countdown = new Countdown();
        }

        private void restoreSettings()
        {
            SettingsSaver ss = new SettingsSaver();

            int savedBreakLength = ss.getBreakLength();
            int savedWorkLength = ss.getWorkLength();
            String savedAlarmPath = ss.getAlarmPath();

            if(savedBreakLength > 0)
            {
                countdown.setBreakLength(savedBreakLength);
                breakNumber.Value = savedBreakLength;
            }

            if(savedWorkLength > 0)
            {
                countdown.setWorkLength(savedWorkLength * 60);
                timerNumber.Value = savedWorkLength;
            }

            if(savedAlarmPath != "")
            {
                countdown.setAlarmFile(savedAlarmPath);
                alarmFilePathTextBox.Text = savedAlarmPath;
            }
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            String filePath = AlarmFileChooser.getFilePath();

            changeAlarmFile(filePath);
        }

        private void changeAlarmFile(String filepath)
        {
            bool failureOfSettingAlarmFile = !countdown.setAlarmFile(filepath);

            if (failureOfSettingAlarmFile)
                showInvalidAlarmFileError();

            setAlarmTextBox();
        }

        private void showInvalidAlarmFileError()
        {
            MessageBox.Show("Invalid alarm file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void setAlarmTextBox()
        {
            alarmFilePathTextBox.Text = countdown.getAlarmFilepath();
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
            countdown.setWorkLength(workTime);
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
            countdown.stopAlarm();
        }

        private void resumeCountdown()
        {
            timer.Enabled = true;
            HoldButton.Text = "Hold";
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            if (isWindowMinimized())
                minimizeToTray();
            else if (isWindowNormal())
                restoreWindow();
        }

        private bool isWindowMinimized()
        {
            return WindowState == FormWindowState.Minimized;
        }

        private void minimizeToTray()
        {
            ShowInTaskbar = false;
        }

        private bool isWindowNormal()
        {
            return WindowState == FormWindowState.Normal;
        }

        private void restoreWindow()
        {
            ShowInTaskbar = true;
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void SaveSettingsOnFormClose(object sender, FormClosingEventArgs e)
        {
            SettingsSaver ss = new SettingsSaver();

            ss.setBreakLength(int.Parse(breakNumber.Value.ToString()));
            ss.setWorkLength(int.Parse(timerNumber.Value.ToString()));
            ss.setAlarmPath(alarmFilePathTextBox.Text.ToString());

            ss.saveSettings();
        }
    }
}