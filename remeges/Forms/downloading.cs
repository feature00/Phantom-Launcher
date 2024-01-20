using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhantomLauncher.Forms
{
    public partial class downloading : Form
    {
        public static string addonpath = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
".phantomlauncher",
"addons"
);

        public static string optifinefiles = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
".phantomlauncher",
"offline",
"multiver"
);

        private static readonly string jrepath = Path.Combine(
            Environment.GetEnvironmentVariable("USERPROFILE"),
            ".phantomlauncher",
            "custom-jre"
        );

        private static readonly string launcherpathh = Path.Combine(
            Environment.GetEnvironmentVariable("USERPROFILE"));

        public downloading()
        {
            InitializeComponent();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the download?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                Application.Restart();
            }
        }


        public async void Downloadlunar()
        {
            await Task.Delay(3000);

            label1.Text = "Downloading Lunar 1.8.9";

            await Task.Run(() =>
            {
                label4.Invoke((MethodInvoker)delegate
                {

                    pictureBox2.Visible = true;
                    label4.Text = "Downloading Lunar Files";
                    label4.Location = new System.Drawing.Point(278, 248);
                });
                PhantomLauncher.Utils.SafeWebClient.GenerateClient().DownloadFile("https://cdn.discordapp.com/attachments/1196112048262754374/1196112162385567876/phantomlauncher.zip", Path.Combine(launcherpathh, "tempfiles.zip"));

                Task.Delay(3000);
                label4.Invoke((MethodInvoker)delegate
                {
                    label4.Text = "Extracting Lunar Files";
                    label4.Location = new System.Drawing.Point(292, 248);
                });

                ZipFile.ExtractToDirectory(Path.Combine(launcherpathh, "tempfiles.zip"), launcherpathh);

                if (!Directory.Exists(addonpath))
                {
                    Directory.CreateDirectory(addonpath);
                }

                label4.Invoke((MethodInvoker)delegate
                {

                    label4.Text = "Downloading Java Agents";
                    label4.Location = new System.Drawing.Point(271, 248);
                });

                PhantomLauncher.Utils.SafeWebClient.GenerateClient().DownloadFile("https://github.com/Nilsen84/lunar-client-agents/releases/download/v1.2.0/CrackedAccount.jar", Path.Combine(addonpath, "CrackedAccount.jar"));
                PhantomLauncher.Utils.SafeWebClient.GenerateClient().DownloadFile("https://github.com/Nilsen84/lunar-client-agents/releases/download/v1.2.0/HitDelayFix.jar", Path.Combine(addonpath, "HitDelayFix.jar"));

                label4.Invoke((MethodInvoker)delegate
                {
                    label4.Text = "Downloading JRE";
                    label4.Location = new System.Drawing.Point(310, 248);
                });

                if (!Directory.Exists(jrepath))
                {
                    Directory.CreateDirectory(jrepath);
                }

                PhantomLauncher.Utils.SafeWebClient.GenerateClient().DownloadFile("https://cdn.azul.com/zulu/bin/zulu18.32.11-ca-jdk18.0.2-win_x64.zip", Path.Combine(jrepath, "zulu18.32.11-ca-jdk18.0.2-win_x64.zip"));

                Task.Delay(1000);

                label4.Invoke((MethodInvoker)delegate
                {
                    label4.Text = "Extracting JRE";
                    label4.Location = new System.Drawing.Point(310, 248);
                });

                Task.Delay(3000);

                ZipFile.ExtractToDirectory(Path.Combine(jrepath, "zulu18.32.11-ca-jdk18.0.2-win_x64.zip"), jrepath);

                label4.Invoke((MethodInvoker)delegate
                {
                    label4.Location = new System.Drawing.Point(221, 248);
                    label4.Text = "Lunar 1.8.9 Successfully Downloaded";
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    guna2Button1.Visible = false;
                });
            });
        }



        public async void DownloadOptifine()
        {
            label1.Text = "Downloading Optifine 1.18.2";
            label1.Location = new System.Drawing.Point(212, 155);
            await Task.Delay(2000);


            await Task.Run(() =>
            {

                label4.Invoke((MethodInvoker)delegate
                {

                    label4.Text = "Downloading 1.18 files";
                    label4.Location = new System.Drawing.Point(288, 248);
                });
                Task.Delay(2000);
                PhantomLauncher.Utils.SafeWebClient.GenerateClient().DownloadFile("https://cdn.discordapp.com/attachments/1196112048262754374/1196117297660706916/OptiFine_v1_18_2.jar", Path.Combine(optifinefiles, "OptiFine_v1_18_2.jar"));
                PhantomLauncher.Utils.SafeWebClient.GenerateClient().DownloadFile("https://cdn.discordapp.com/attachments/1196112048262754374/1196117308041609226/modern-0.1.0-SNAPSHOT-all.jar", Path.Combine(optifinefiles, "modern-0.1.0-SNAPSHOT-all.jar"));
                PhantomLauncher.Utils.SafeWebClient.GenerateClient().DownloadFile("https://cdn.discordapp.com/attachments/1196112048262754374/1196117320939077702/client-natives-win-x86-v1_18_2.zip", Path.Combine(optifinefiles, "client-natives-win-x86-v1_18_2.zip"));
                Task.Delay(3000);
                label4.Invoke((MethodInvoker)delegate
                {
                    label4.Location = new System.Drawing.Point(199, 248);
                    label4.Text = "Optifine 1.18.2 Successfully Downloaded";
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    guna2Button1.Visible = false;
                });
            });
            }

        private void downloading_Load(object sender, EventArgs e)
        {
            label4.Text = "Downloading starting soon....";
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
