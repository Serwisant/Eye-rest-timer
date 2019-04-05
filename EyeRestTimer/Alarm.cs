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

        public void tryToSetAlarmFile(String filepath)
        {
            this.filepath = filepath;

            if (isInvalidAlarmFile())
            {
                filepath = "";
                throw new InvalidAlarmFile();
            }
                
            this.filepath = filepath;
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
