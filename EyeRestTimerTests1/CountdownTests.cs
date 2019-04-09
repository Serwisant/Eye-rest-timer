using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeRestTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeRestTimer.Tests
{
    [TestClass()]
    public class CountdownTests
    {
        private Countdown countdown;
        private String dummyAlarmFilepath = @"\Test.mp3";
        private String currentDirectory = System.IO.Directory.GetCurrentDirectory();

        [TestMethod()]
        public void setAndGetAlarmFilepathTest()
        {
            String expectedFilepath = currentDirectory + dummyAlarmFilepath;
            System.IO.File.WriteAllText(currentDirectory + dummyAlarmFilepath, "DUMMY FILE");

            countdown.setAlarmFile(expectedFilepath);
            String actualFilepath = countdown.getAlarmFilepath();

            Assert.AreEqual(expectedFilepath, actualFilepath);
        }

        [TestMethod()]
        public void setAndGetWorktimeTest()
        {
            int workTime = 120;
            int breakTime = 20;

            countdown.setWorkLength(workTime);
            countdown.setBreakLength(breakTime);
            for (int sec = 0; sec < workTime; sec++)
                countdown.tickSecond();

            int actualCountdownValue = countdown.getRemainingTime();
            Countdown.MODE actualMode = countdown.getCurrentMode();

            int expectedCountdownValue = breakTime;
            Countdown.MODE expectedMode = Countdown.MODE.BREAK;

            Assert.AreEqual(expectedCountdownValue, actualCountdownValue);
            Assert.AreEqual(expectedMode, actualMode);
        }

        [TestMethod()]
        public void setAndGetBreakLengthAndModesTest()
        {
            int workTime = 20;
            int breakTime = 20;
            int middleOfBreak = breakTime / 2;
            int timeToMiddleOfBreak = workTime + middleOfBreak;

            countdown.setWorkLength(workTime);
            countdown.setBreakLength(breakTime);

            for (int sec = 0; sec < timeToMiddleOfBreak; sec++)
                countdown.tickSecond();

            int actualCountdownValue = countdown.getRemainingTime();
            Countdown.MODE actualMode = countdown.getCurrentMode();

            int expectedCountdownValue = middleOfBreak;
            Countdown.MODE expectedMode = Countdown.MODE.BREAK;

            Assert.AreEqual(expectedCountdownValue, actualCountdownValue);
            Assert.AreEqual(expectedMode, actualMode);

        }

        [TestMethod()]
        public void tickSecondAndGetRemainingTimeTest()
        {
            int timePassed = 20;
            int workTime = 100;

            countdown.setWorkLength(workTime);

            for (int sec = 0; sec < timePassed; sec++)
                countdown.tickSecond();

            int actualCountdownValue = countdown.getRemainingTime();
            int expectedCountdownValue = workTime - timePassed;
        }

        [TestInitialize]
        public void prepareObjects()
        {
            countdown = new Countdown();
        }
    }
}