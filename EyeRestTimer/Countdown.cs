using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeRestTimer
{
    class Countdown
    {
        private enum MODE { WORK, BREAK };

        private int workTime;
        private int breakTime;
        private int currentCountdown;
        private MODE currentMode;

        public Countdown()
        {
            workTime = 20;
            breakTime = 20;
            currentCountdown = workTime;
            currentMode = MODE.WORK;
        }

        public void setWorktime(int seconds)
        {
            if (seconds >= 1)
                workTime = seconds;
            else
                workTime = 1;

            if (currentMode == MODE.WORK && currentCountdown > workTime)
                currentCountdown = workTime;
        }

        public void setBreakLength(int seconds)
        {
            if (seconds >= 1)
                breakTime = seconds;
            else
                breakTime = 1;

            if (currentMode == MODE.BREAK && currentCountdown > breakTime)
                currentCountdown = breakTime;
        }

        public void tickSecond()
        {
            if (currentCountdown >= 0)
                currentCountdown--;
            else
                changeModeAndResetCountdown();
        }

        private void changeModeAndResetCountdown()
        {
            if (currentMode == MODE.WORK)
            {
                currentMode = MODE.BREAK;
                currentCountdown = breakTime;
            } else
            {
                currentMode = MODE.WORK;
                currentCountdown = workTime;
            }
        }
    }
}
