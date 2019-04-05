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
        }

        public void setAlarm(Alarm alarm)
        {
            this.alarm = alarm;
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

        public void playAlarmDuringBreak(bool enableAlarm)
        {
            playAlarm = enableAlarm;
        }

        public void tickSecond()
        {
            if (currentCountdown > 0)
                currentCountdown--;
            else
                changeModeAndResetCountdown();
        }

        public int getRemainingTime() => currentCountdown;

        public Countdown.MODE getCurrentMode() => currentMode;

        private void changeModeAndResetCountdown()
        {
            if (currentMode == MODE.WORK)
            {
                currentMode = MODE.BREAK;
                currentCountdown = breakTime;
                if(playAlarm)
                    alarm.play();
            } else
            {
                currentMode = MODE.WORK;
                currentCountdown = workTime;
                alarm.stop();
            }
        }

        private int normalizeTime(int time)
        {
            if (time >= 1)
                return time;
            else
                return 1;
        }
    }
}
