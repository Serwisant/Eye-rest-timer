namespace EyeRestTimer
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerNumber = new System.Windows.Forms.NumericUpDown();
            this.breakLabel = new System.Windows.Forms.Label();
            this.breakNumber = new System.Windows.Forms.NumericUpDown();
            this.alarmLabel = new System.Windows.Forms.Label();
            this.alarmFileChooser = new System.Windows.Forms.OpenFileDialog();
            this.alarmFilePathTextBox = new System.Windows.Forms.TextBox();
            this.chooseFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(12, 15);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(112, 13);
            this.timerLabel.TabIndex = 0;
            this.timerLabel.Text = "Break every [minutes]:";
            // 
            // timerNumber
            // 
            this.timerNumber.Location = new System.Drawing.Point(130, 13);
            this.timerNumber.Name = "timerNumber";
            this.timerNumber.Size = new System.Drawing.Size(140, 20);
            this.timerNumber.TabIndex = 1;
            // 
            // breakLabel
            // 
            this.breakLabel.AutoSize = true;
            this.breakLabel.Location = new System.Drawing.Point(12, 42);
            this.breakLabel.Name = "breakLabel";
            this.breakLabel.Size = new System.Drawing.Size(119, 13);
            this.breakLabel.TabIndex = 2;
            this.breakLabel.Text = "Break length [seconds]:";
            // 
            // breakNumber
            // 
            this.breakNumber.Location = new System.Drawing.Point(137, 40);
            this.breakNumber.Name = "breakNumber";
            this.breakNumber.Size = new System.Drawing.Size(133, 20);
            this.breakNumber.TabIndex = 3;
            // 
            // alarmLabel
            // 
            this.alarmLabel.AutoSize = true;
            this.alarmLabel.Location = new System.Drawing.Point(12, 69);
            this.alarmLabel.Name = "alarmLabel";
            this.alarmLabel.Size = new System.Drawing.Size(52, 13);
            this.alarmLabel.TabIndex = 4;
            this.alarmLabel.Text = "Alarm file:";
            // 
            // alarmFileChooser
            // 
            this.alarmFileChooser.FileName = "openFileDialog1";
            this.alarmFileChooser.Filter = "Sound files|*.mp3;*.wav;*.ogg";
            this.alarmFileChooser.Title = "Choose alarm file";
            // 
            // alarmFilePathTextBox
            // 
            this.alarmFilePathTextBox.Location = new System.Drawing.Point(70, 66);
            this.alarmFilePathTextBox.Name = "alarmFilePathTextBox";
            this.alarmFilePathTextBox.Size = new System.Drawing.Size(163, 20);
            this.alarmFilePathTextBox.TabIndex = 5;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(239, 66);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(31, 20);
            this.chooseFileButton.TabIndex = 6;
            this.chooseFileButton.Text = "...";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 99);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.alarmFilePathTextBox);
            this.Controls.Add(this.alarmLabel);
            this.Controls.Add(this.breakNumber);
            this.Controls.Add(this.breakLabel);
            this.Controls.Add(this.timerNumber);
            this.Controls.Add(this.timerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EyeTimer";
            ((System.ComponentModel.ISupportInitialize)(this.timerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.NumericUpDown timerNumber;
        private System.Windows.Forms.Label breakLabel;
        private System.Windows.Forms.NumericUpDown breakNumber;
        private System.Windows.Forms.Label alarmLabel;
        private System.Windows.Forms.OpenFileDialog alarmFileChooser;
        private System.Windows.Forms.TextBox alarmFilePathTextBox;
        private System.Windows.Forms.Button chooseFileButton;
    }
}

