using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System;
using System.Threading.Tasks;

namespace WIndows_Shutdown
{
    public partial class Form1 : Form
    {
        private int remainingTime; // countdown in seconds
        private System.Windows.Forms.Timer countdownTimer;
        private int remainingTime2; // countdown in seconds
        private System.Windows.Forms.Timer countdownTimer2;


        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object? sender, EventArgs e)
        {
            int hours = (int)NudHours.Value;
            int minutes = (int)NudMinutes.Value;
            int delayInSeconds = (hours * 3600) + (minutes * 60);

            if (delayInSeconds == 0)
            {
                MessageBox.Show("Please enter a time greater than zero.");
                return;
            }

            remainingTime = delayInSeconds;
            CountShut.Text = TimeSpan.FromSeconds(remainingTime).ToString(@"hh\:mm\:ss");

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 second
            CountShut.Text = $"Shutting down in {TimeSpan.FromSeconds(remainingTime):hh\\:mm\\:ss}";
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();

            //Process.Start(new ProcessStartInfo
            //{
            //    FileName = "shutdown",
            //    Arguments = $"/s /t {delayInSeconds}",
            //    CreateNoWindow = true,
            //    UseShellExecute = false
            //});

            try
            {
                await Task.Run(() =>
                {
                    using var process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = $"/c  shutdown /s /t {delayInSeconds}";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            button1.Visible = false;
            CancelShutdown.Visible = true;
        }

        private async void button2_Click(object? sender, EventArgs e)
        {
            int hours = (int)NudHours.Value;
            int minutes = (int)NudMinutes.Value;
            int delayInSeconds = (hours * 3600) + (minutes * 60);

            if (delayInSeconds == 0)
            {
                MessageBox.Show("Please enter a time greater than zero.");
                return;
            }

            remainingTime2 = delayInSeconds;
            CountShut.Text = TimeSpan.FromSeconds(remainingTime2).ToString(@"hh\:mm\:ss");

            countdownTimer2 = new System.Windows.Forms.Timer();
            countdownTimer2.Interval = 1000; // 1 second
            CountShut.Text = $"Restarting in {TimeSpan.FromSeconds(remainingTime2):hh\\:mm\\:ss}";
            countdownTimer2.Tick += CountdownTimer_Tick2;
            countdownTimer2.Start();

            //Process.Start(new ProcessStartInfo
            //{
            //    FileName = "shutdown",
            //    Arguments = $"/r /f /t {delayInSeconds}",
            //    CreateNoWindow = true,
            //    UseShellExecute = false
            //});


            try
            {
                await Task.Run(() =>
                {
                    using var process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = $"/c  shutdown /r /f /t {delayInSeconds}";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            button2.Visible = false;
            CancelRestart.Visible = true;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            if (remainingTime <= 0)
            {
                countdownTimer.Stop();
                CountShut.Text = "Shutting down...";
            }
            else
            {
                CountShut.Text = $"Shutting down in {TimeSpan.FromSeconds(remainingTime):hh\\:mm\\:ss}";
            }
        }

        private void CountdownTimer_Tick2(object sender, EventArgs e)
        {
            remainingTime2--;

            if (remainingTime2 <= 0)
            {
                countdownTimer2.Stop();
                CountShut.Text = "Restarting...";
            }
            else
            {
                CountShut.Text = $"Restarting in {TimeSpan.FromSeconds(remainingTime2):hh\\:mm\\:ss}";
            }
        }

        private void CancelShutdown_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "shutdown",
                Arguments = $"/a",
                CreateNoWindow = true,
                UseShellExecute = false
            });
            countdownTimer.Stop();
            button1.Visible = true;
            CancelShutdown.Visible = false;
            CountShut.Text = "";
        }

        private void CancelRestart_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "shutdown",
                Arguments = $"/a",
                CreateNoWindow = true,
                UseShellExecute = false
            });
            countdownTimer2.Stop();
            button2.Visible = true;
            CancelRestart.Visible = false;
            CountShut.Text = "";
        }

    }
}
