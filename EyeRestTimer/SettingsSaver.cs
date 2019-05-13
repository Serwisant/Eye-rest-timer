using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeRestTimer
{
    class SettingsSaver
    {
        private int breakLength;
        private int workLength;
        private String alarmPath;

        public SettingsSaver()
        {
            breakLength = 0;
            workLength = 0;
            alarmPath = "";

            readSettings();
        }

        public void setBreakLength(int length)
        {
            breakLength = length;
        }

        public void setWorkLength(int length)
        {
            workLength = length;
        }

        public void setAlarmPath(String filePath)
        {
            alarmPath = filePath;
        }

        public int getBreakLength() => breakLength;

        public int getWorkLength() => workLength;

        public String getAlarmPath() => alarmPath;

        public void readSettings()
        {
            if (!File.Exists("./ert_settings.ini"))
                return;

            using (StreamReader sr = new StreamReader("./ert_settings.ini"))
            {
                String breakString = sr.ReadLine();
                breakLength = int.Parse(breakString);

                String workString = sr.ReadLine();
                workLength = int.Parse(workString);

                alarmPath = sr.ReadLine();
            }
        }

        public bool saveSettings()
        {
            using (StreamWriter sw = new StreamWriter("./ert_settings.ini"))
            {
                sw.WriteLine(breakLength.ToString());
                sw.WriteLine(workLength.ToString());
                sw.WriteLine(alarmPath);
            }

            return true;
        }
    }
}
