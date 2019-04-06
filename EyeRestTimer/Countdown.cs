using System;

namespace EyeRestTimer
{
    public class Countdown
    {
        public enum MODE { WORK, BREAK };

        private int workTime;
        private int breakTime;
        private int currentCountdown;
        private MODE currentMode;
        private Alarm alarm;
        private bool playAlarm;

        public Countdown()
        {
            workTime = 1200; // 20 minutes
            breakTime = 20;
            currentCountdown = workTime;
            currentMode = MODE.WORK;
            playAlarm = true;
            alarm = new Alarm();
        }

        public bool setAlarmFile(String filepath)
        {
            return alarm.setAlarmFile(filepath);
        }

        public String getAlarmFilepath() => alarm.getFilepath();

        public void stopAlarm()
        {
            alarm.stop();
        }

        public void setWorktime(int seconds)
        {
            workTime = normalizeTime(seconds);

            if (currentMode == MODE.WORK && currentCountdown > workTime)
                currentCountdown = workTime;
        }

        public void setBreakLength(int seconds)
        {
            breakTime = normalizeTime(seconds);

            if (currentMode == MODE.BREAK && currentCountdown > breakTime)
                currentCountdown = breakTime;
        }

        private int normalizeTime(int time)
        {
            if (time >= 1)
                return time;
            else
                return 1;
        }

        public void playAlarmDuringBreak(bool enableAlarm)
        {
            playAlarm = enableAlarm;
            if (enableAlarm == false)
                alarm.stop();
        }

        public void tickSecond()
        {
            if (currentCountdown > 0)
                currentCountdown--;
            else
                changeMode();
        }

        public int getRemainingTime() => currentCountdown;

        public Countdown.MODE getCurrentMode() => currentMode;

        private void changeMode()
        {
            if (currentMode == MODE.WORK)
                changeToBreakTime();
            else if(currentMode == MODE.BREAK)
                changeToWorkTime();
        }

        private void changeToBreakTime()
        {
            currentMode = MODE.BREAK;
            currentCountdown = breakTime;
            if (playAlarm)
                alarm.play();
        }

        private void changeToWorkTime()
        {
            currentMode = MODE.WORK;
            currentCountdown = workTime;
            alarm.stop();
        }
    }
}
