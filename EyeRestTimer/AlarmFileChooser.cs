using System;

namespace EyeRestTimer
{
    public class AlarmFileChooser
    {
        static public String getFilePath()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Sound files|*.mp3;*.wav;*.ogg";
            openFileDialog.ShowDialog();

            return openFileDialog.FileName;
        }
    }
}
