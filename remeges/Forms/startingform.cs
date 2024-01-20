using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhantomLauncher
{
    public partial class startingform : Form
    {
        private int countdownSeconds = 10;
        private bool oldversion;
        public static string SettingsFilePath = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
"phantomsettings.txt"
);
        public startingform()
        {
            InitializeComponent();
        }

        private async void startingform_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (oldversion==true)
            {
                label1.Text = "Launching Lunar Client...";
            }
            if (!oldversion==true)
            {
                label1.Text = "Launching Optifine 1.18.2 ...";
            }

            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            label2.Visible = false;

            timer1.Start();

            await Task.Delay(countdownSeconds * 1000);

            if (oldversion == true)
            {
                label1.Text = "Lunar Client Launched";
            }
            if (!oldversion == true)
            {
                label1.Text = "Optifine 1.18.2 Launched";
            }

            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            label2.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;

            if (countdownSeconds <= 0)
            {
                timer1.Stop();
                this.Close();
            }
        }


        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    string[] settingsLines = File.ReadAllLines(SettingsFilePath);

                    if (settingsLines.Length >= 4)
                    {
                        bool oldversionValue;
                        if (bool.TryParse(settingsLines[3], out oldversionValue))
                        {
                            oldversion = oldversionValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
