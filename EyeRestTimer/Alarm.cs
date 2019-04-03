using System;

namespace EyeRestTimer
{
    class Alarm
    {
        private String filepath;
        WMPLib.WindowsMediaPlayer alarmPlayer;

        public Alarm()
        {
            filepath = "";
            alarmPlayer = new WMPLib.WindowsMediaPlayer();
        }

        public void setAlarmFile(String filepath)
        {
            this.filepath = filepath;
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
