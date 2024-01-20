using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using DiscordRpcDemo;

namespace PhantomLauncher
{
    public partial class Form1 : Form
    {
        public static string checkfiles = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
".phantomlauncher",
"offline",
"multiver",
"lunar-emote.jar"
);
        private DiscordRpc.EventHandlers handlers;
        private static readonly string SettingsFilePath = @"C:\Users\" + Environment.UserName + @"\phantomsettings.txt";
        private DiscordRpc.RichPresence presence;
        private bool richpresence;


        public Form1()
        {
            InitializeComponent();
            label2.Click += label2_Click;
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            f.Show();
        }


        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    string[] settingsLines = File.ReadAllLines(SettingsFilePath);

                    if (settingsLines.Length >= 2)
                    {
                        bool richPresenceValue;
                        if (bool.TryParse(settingsLines[1], out richPresenceValue))
                        {
                            richpresence = richPresenceValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a beállítások betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            loadform(new homeform());
            

            LoadSettings();
            if (richpresence)
            {
                this.handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("1192183252539150507", ref this.handlers, true, null);
                this.handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("1192183252539150507", ref this.handlers, true, null);
                this.presence.details = "discord.gg/phantomlauncher";
                this.presence.startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                this.presence.largeImageKey = "https://i.imgur.com/BjUy2RZ.png";
                DiscordRpc.UpdatePresence(ref this.presence);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void homebutton_Click(object sender, EventArgs e)
        {
            loadform(new homeform());

        }

        private void settingsbutton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(checkfiles))
            {
                MessageBox.Show("Download any version first before you want to configure your game!", "Phantom Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loadform(new homeform());
                settingsbutton.Checked = false;
                homebutton.Checked = true;
            }
            else
            {
                loadform(new settingsform());
            }
        }

        private void downloadbutton_Click(object sender, EventArgs e)
        {
            loadform(new downloadform());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/EtXzxrCRVP");
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
