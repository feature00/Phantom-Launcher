using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace PhantomLauncher
{
    public partial class settingsform : Form
    {
        private ToolTip toolTip1;
        public static string SettingsFilePath = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
"phantomsettings.txt"
        );

        public static string versionchecker = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
".phantomlauncher",
"offline",
"multiver",
"OptiFine_v1_8.jar"
);

        public static string lunarpath = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
".phantomlauncher",
"offline",
"multiver",
"OptiFine_v1_8.jar"
);

        public static string optifinepath = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
".phantomlauncher",
"offline",
"multiver",
"OptiFine_v1_18_2.jar"
);



        public settingsform()
        {
            InitializeComponent();
            ramtrackbar.ValueChanged += ramtrackbar_ValueChanged;
            toggleRPC.CheckedChanged += toggleRPC_CheckedChanged;
            toggleOffline.CheckedChanged += toggleOffline_CheckedChanged;
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
            toolTip1 = new ToolTip();

            guna2ComboBox1.SelectedIndexChanged -= guna2ComboBox1_SelectedIndexChanged;
            LoadSettings();
        }

        private void SaveSettings()
        {
            try
            {
                string settingsContent = $"{ramtrackbar.Value.ToString()}\n{richpresence.ToString()}\n{crackedaccount.ToString()}\n{oldversion.ToString()}";
                File.WriteAllText(SettingsFilePath, settingsContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    string[] settingsLines = File.ReadAllLines(SettingsFilePath);

                    if (settingsLines.Length >= 1)
                    {
                        int value;
                        if (int.TryParse(settingsLines[0], out value))
                        {
                            ramtrackbar.Value = Math.Max(ramtrackbar.Minimum, Math.Min(ramtrackbar.Maximum, value));
                        }
                    }

                    if (settingsLines.Length >= 2)
                    {
                        bool richPresenceValue;
                        if (bool.TryParse(settingsLines[1], out richPresenceValue))
                        {
                            richpresence = richPresenceValue;
                            toggleRPC.Checked = richPresenceValue;
                        }
                    }

                    if (settingsLines.Length >= 3)
                    {
                        bool crackedAccountValue;
                        if (bool.TryParse(settingsLines[2], out crackedAccountValue))
                        {
                            crackedaccount = crackedAccountValue;
                            toggleOffline.Checked = crackedAccountValue;
                        }
                    }
                    if (settingsLines.Length >= 4)
                    {
                        bool oldversionValue;
                        if (bool.TryParse(settingsLines[3], out oldversionValue))
                        {
                            oldversion = oldversionValue;
                            if (oldversionValue == false)
                            {
                                guna2ComboBox1.SelectedIndex = 1;
                            }
                            if (oldversionValue == true)
                            {
                                guna2ComboBox1.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void settingsform_Load(object sender, EventArgs e)
        {
            LoadSettings();
            string mb = (ramtrackbar.Value * 100).ToString();
            label10.Text = mb + " MB";

            toolTip1.SetToolTip(toggleRPC, "use this to make it visible on discord that you are using this program.");
        }

        private void ramtrackbar_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void ramtrackbar_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ramtrackbar_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void ramtrackbar_ValueChanged(object sender, EventArgs e)
        {
            string mb = (ramtrackbar.Value * 100).ToString();
            label10.Text = mb + " MB";

            if (ramtrackbar.Value < 20)
            {
                ramtrackbar.Value = 20;
            }
            SaveSettings();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public static bool richpresence;


        private void toggleRPC_CheckedChanged(object sender, EventArgs e)
        {

            if (toggleRPC.Checked == true)
            {
                richpresence = true;
            }
            if (toggleRPC.Checked == false)
            {
                richpresence = false;
            }
            SaveSettings();
        }

        public static bool crackedaccount;
        private void toggleOffline_CheckedChanged(object sender, EventArgs e)
        {

            if (toggleOffline.Checked == true)
            {
                crackedaccount = true;
            }
            if (toggleOffline.Checked == false)
            {
                crackedaccount = false;
            }
            SaveSettings();
        }


        public static bool oldversion;
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                if (File.Exists(lunarpath))
                {
                    oldversion = true;
                    toggleOffline.Enabled = true;
                    SaveSettings();
                }
                else
                {
                    guna2ComboBox1.SelectedIndex = -1;
                    MessageBox.Show("Lunar files does not exist. Please download it first.");
                }
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                if (File.Exists(optifinepath))
                {
                    oldversion = false;
                    toggleOffline.Enabled = false;
                    SaveSettings();
                }
                else
                {
                    guna2ComboBox1.SelectedIndex = -1;
                    MessageBox.Show("Optifine files does not exist. Please download it first.");
                }
            }

        }


        public static bool hitdelayfix;
        private void toggleHitdelay_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }

}