using System;
using System.IO;

namespace EyeRestTimer
{
    public class Alarm
    {
        private String filepath;
        WMPLib.WindowsMediaPlayer alarmPlayer;

        public Alarm()
        {
            filepath = "";
            alarmPlayer = new WMPLib.WindowsMediaPlayer();
        }

        public bool setAlarmFile(String filepath)
        {
            this.filepath = filepath;
            bool success = true;

            if (isInvalidAlarmFile())
            {
                this.filepath = "";
                success = false;
            }

            return success;
        }

        private bool isInvalidAlarmFile()
        {
            return doesntFileExist() || hasFileIncorrectExtension();
        }

        private bool hasFileIncorrectExtension()
        {
            return !filepath.EndsWith(".mp3") && !filepath.EndsWith(".wav") && !filepath.EndsWith(".ogg");
        }

        private bool doesntFileExist()
        {
            return !File.Exists(filepath);
        }

        public String getFilepath()
        {
            return filepath;
        }

        public void play()
        {
            alarmPlayer.URL = filepath;
            alarmPlayer.controls.play();
        }

        public void stop()
        {
            alarmPlayer.controls.stop();
        }
    }
}
