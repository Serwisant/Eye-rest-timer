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
    public class AlarmTests
    {
        private String dummyAlarmFilepath = @"\Test.mp3";
        private String currentDirectory = System.IO.Directory.GetCurrentDirectory();
        private Alarm alarm;

        [TestMethod()]
        public void setAndGetCorrectFilepathTest()
        {
            String expected = currentDirectory + dummyAlarmFilepath;

            bool success = alarm.setAlarmFile(currentDirectory + dummyAlarmFilepath);
            String actual = alarm.getFilepath();

            Assert.AreEqual(true, success);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void setAndGetInvalidFilepathTest()
        {
            String expected = "";

            bool success = alarm.setAlarmFile(currentDirectory + @"\SOME_NOT_ExisTING_FILE.mp3");
            String actual = alarm.getFilepath();

            Assert.AreEqual(false, success);
            Assert.AreEqual(expected, actual);
        }

        [TestInitialize]
        public void prepareObjects()
        {
            System.IO.File.WriteAllText(currentDirectory + dummyAlarmFilepath, "DUMMY FILE");
            alarm = new Alarm();
        }

        [TestCleanup]
        public void deleteDummyAlarmFile()
        {
            System.IO.File.Delete(currentDirectory + dummyAlarmFilepath);
        }
    }
}