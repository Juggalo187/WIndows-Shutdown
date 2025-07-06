namespace WIndows_Shutdown
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            NudHours = new NumericUpDown();
            NudMinutes = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            CountShut = new Label();
            CancelRestart = new Button();
            CancelShutdown = new Button();
            ((System.ComponentModel.ISupportInitialize)NudHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudMinutes).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(10, 80);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Shutdown";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NudHours
            // 
            NudHours.Location = new Point(50, 22);
            NudHours.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            NudHours.Name = "NudHours";
            NudHours.Size = new Size(120, 23);
            NudHours.TabIndex = 1;
            // 
            // NudMinutes
            // 
            NudMinutes.Location = new Point(50, 51);
            NudMinutes.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            NudMinutes.Name = "NudMinutes";
            NudMinutes.Size = new Size(120, 23);
            NudMinutes.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 24);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 3;
            label1.Text = "Hour";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 53);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 4;
            label2.Text = "Minute";
            // 
            // button2
            // 
            button2.Location = new Point(91, 80);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Restart";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CountShut
            // 
            CountShut.AutoSize = true;
            CountShut.Location = new Point(12, 4);
            CountShut.Name = "CountShut";
            CountShut.Size = new Size(0, 15);
            CountShut.TabIndex = 6;
            // 
            // CancelRestart
            // 
            CancelRestart.Location = new Point(91, 80);
            CancelRestart.Name = "CancelRestart";
            CancelRestart.Size = new Size(75, 23);
            CancelRestart.TabIndex = 7;
            CancelRestart.Text = "Cancel";
            CancelRestart.UseVisualStyleBackColor = true;
            CancelRestart.Visible = false;
            CancelRestart.Click += CancelRestart_Click;
            // 
            // CancelShutdown
            // 
            CancelShutdown.Location = new Point(10, 80);
            CancelShutdown.Name = "CancelShutdown";
            CancelShutdown.Size = new Size(75, 23);
            CancelShutdown.TabIndex = 8;
            CancelShutdown.Text = "Cancel";
            CancelShutdown.UseVisualStyleBackColor = true;
            CancelShutdown.Visible = false;
            CancelShutdown.Click += CancelShutdown_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(182, 107);
            Controls.Add(CancelShutdown);
            Controls.Add(CancelRestart);
            Controls.Add(CountShut);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NudMinutes);
            Controls.Add(NudHours);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Shutdown/Restart";
            ((System.ComponentModel.ISupportInitialize)NudHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudMinutes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private NumericUpDown NudHours;
        private NumericUpDown NudMinutes;
        private Label label1;
        private Label label2;
        private Button button2;
        private Label CountShut;
        private Button CancelRestart;
        private Button CancelShutdown;
    }
}
