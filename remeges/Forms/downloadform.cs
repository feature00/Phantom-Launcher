using PhantomLauncher.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhantomLauncher
{
    public partial class downloadform : Form
    {
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
        public downloadform()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void downloadform_Load(object sender, EventArgs e)
        {
            if (File.Exists(lunarpath))
            {
                label9.Text = "Downloaded";
                label9.ForeColor = Color.Green;
                guna2GradientButton1.Enabled = false;
                guna2GradientButton1.Text = "Done!";
            }
            if (!File.Exists(lunarpath))
            {
                label9.Text = "Not Downloaded";
                label9.ForeColor = Color.Red;
            }

            if (File.Exists(optifinepath))
            {
                label10.Text = "Downloaded";
                label10.ForeColor = Color.Green;
                guna2GradientButton2.Enabled = false;
                guna2GradientButton2.Text = "Done!";
            }
            if (!File.Exists(optifinepath))
            {
                label10.Text = "Not Downloaded";
                label10.ForeColor = Color.Red;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(
                   Environment.GetEnvironmentVariable("USERPROFILE"),
                   ".phantomlauncher",
                   "offline",
                   "multiver",
                   "client-natives-win-x86-v1_8.zip"
                   );

            if (File.Exists(path))
            {
                MessageBox.Show("All files downloaded!", "Phantom Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Some files are missing!", "Phantom Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private downloading downloadingForm;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form mainForm = this.ParentForm;

            this.Hide();
            mainForm.Hide();

            downloadingForm = new downloading();
            downloadingForm.FormClosed += (s, args) =>
            {
                mainForm.Show();
                this.Show();
            };

            downloadingForm.Downloadlunar();
            downloadingForm.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(lunarpath))
            {
                MessageBox.Show("Please download lunar files first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Form mainForm = this.ParentForm;

            this.Hide();
            mainForm.Hide();

            downloadingForm = new downloading();
            downloadingForm.FormClosed += (s, args) =>
            {
                mainForm.Show();
                this.Show();
            };

            downloadingForm.DownloadOptifine();
            downloadingForm.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(
       Environment.GetEnvironmentVariable("USERPROFILE"),
       ".phantomlauncher",
       "offline",
       "multiver",
       "client-natives-win-x86-v1_18_2.zip"
       );

            if (File.Exists(path))
            {
                MessageBox.Show("All files downloaded!", "Phantom Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Some files are missing!", "Phantom Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
