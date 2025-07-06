using System.Diagnostics;

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

        private void button1_Click(object sender, EventArgs e)
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

            Process.Start(new ProcessStartInfo
            {
                FileName = "shutdown",
                Arguments = $"/s /t {delayInSeconds}",
                CreateNoWindow = true,
                UseShellExecute = false
            });
            button1.Visible = false;
            CancelShutdown.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
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
            CountShut.Text = $"Restarting in {TimeSpan.FromSeconds(remainingTime):hh\\:mm\\:ss}";
            countdownTimer.Tick += CountdownTimer_Tick2;
            countdownTimer.Start();

            Process.Start(new ProcessStartInfo
            {
                FileName = "shutdown",
                Arguments = $"/r /f /t {delayInSeconds}",
                CreateNoWindow = true,
                UseShellExecute = false
            });

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
            remainingTime--;

            if (remainingTime <= 0)
            {
                countdownTimer.Stop();
                CountShut.Text = "Restarting...";
            }
            else
            {
                CountShut.Text = $"Restarting in {TimeSpan.FromSeconds(remainingTime):hh\\:mm\\:ss}";
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
            countdownTimer.Stop();
            button2.Visible = true;
            CancelRestart.Visible = false;
            CountShut.Text = "";
        }

    }
}
