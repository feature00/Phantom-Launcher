using System;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DiscordRpcDemo;

namespace PhantomLauncher
{
    public partial class homeform : Form
    {
        private bool oldversion;
        private bool crackedAccount;
        private string mb;
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public static string minecraftpath = Path.Combine(
    Environment.GetEnvironmentVariable("USERPROFILE"),
    ".phantomlauncher",
    "offline",
    "multiver",
    "OptiFine_v1_8.jar"
);

        public static string settingspath = Path.Combine(
Environment.GetEnvironmentVariable("USERPROFILE"),
"phantomsettings.txt"
);


        public homeform()
        {
            InitializeComponent();
            string userName = Environment.UserName;
            string greetingMessage = $"Hi, {userName}!\nThank you for using our launcher!";
            label6.Text = greetingMessage;
            this.KeyPreview = true;
            username.KeyPress += username_KeyPress;
            LoadSettings();
        }


        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                username.Enabled = false;

                e.Handled = true;
            }

        }       

        private void homeform_Load(object sender, EventArgs e)
        {
            LoadSettings();

            label2.Visible = false;
            if (oldversion == true)
            {
                guna2GradientButton1.Text = "Launch 1.8.9";
            }
            if (oldversion == false)
            {
                guna2GradientButton1.Text = "Launch 1.18.2";
            }
            if (!File.Exists(minecraftpath))
            {
                if (!File.Exists(settingspath))
                {
                    guna2GradientButton1.Text = "Not available";
                    guna2GradientButton1.FillColor = Color.Red;
                    guna2GradientButton1.FillColor2 = Color.Red;
                }
                if (File.Exists(settingspath))
                {
                    guna2GradientButton1.Text = "Missing files!";
                    guna2GradientButton1.Enabled = false;
                    guna2GradientButton1.FillColor = Color.Red;
                    guna2GradientButton1.FillColor2 = Color.Red;
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discordapp.com/users/811991165993615361");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void Guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
                {
                }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
                
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
        private bool lunarElinditva = false;
        private startingform startingForm;

        public static string settingsfile = Path.Combine(
        Environment.GetEnvironmentVariable("USERPROFILE"),
        "phantomsettings.txt"
        );

        public void LoadSettings()
        {
            try
            {
        // string settingsFilePath = @"C:\Users\" + Environment.UserName + @"\phantomsettings.txt";
        string settingsFilePath = settingsfile;


                if (File.Exists(settingsFilePath))
                {
                    string[] settingsLines = File.ReadAllLines(settingsFilePath);

                    if (settingsLines.Length >= 1)
                    {
                        int ramValue;
                        if (int.TryParse(settingsLines[0], out ramValue))
                        {                   
                            string ramString = (ramValue * 100).ToString();
                            mb = ramString;
                        }
                    }


                    if (settingsLines.Length >= 3)
                    {
                        bool crackedAccountValue;
                        if (bool.TryParse(settingsLines[2], out crackedAccountValue))
                        {
                            crackedAccount = crackedAccountValue;
                            if (!crackedAccountValue)
                            {
                                username.Enabled = false;
                                username.Text = "You are in online mode!";

                            }
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
                                username.Enabled = true;
                                username.Text = "";
                            }
                            if (oldversionValue == true)
                            {
                                //
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string jatekosnev = username.Text;

            if (!File.Exists(settingspath))
            {
                label2.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(jatekosnev))
            {
                MessageBox.Show("You forgot to enter your playername!", "Phantom Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2GradientButton1.Checked = false;
                return;
            }


            if (!lunarElinditva)
            {
                Form mainForm = this.ParentForm;

                this.Hide();

                mainForm.Hide();

                startingForm = new startingform();
                startingForm.FormClosed += (s, args) =>
                {
                    mainForm.Show();
                    this.Show();
                };
                startingForm.Show();
                LoadSettings();
                Launchsecond.LaunchLunar(jatekosnev, crackedAccount, oldversion, mb);
                lunarElinditva = true;

                Task.Run(() =>
                {
                    Process[] processes = Process.GetProcessesByName("javaw");
                    {
                        lunarElinditva = false;
                    }
                });
            }
        }

        public class Launchsecond
        {
            private static readonly string _LogsPath = Path.Combine(
            Environment.GetEnvironmentVariable("USERPROFILE"),
            ".phantomlauncher",
            "offline",
            "multiver",
            "logs"
        );

            private static readonly string _multiverDirectory = Path.Combine(
               Environment.GetEnvironmentVariable("USERPROFILE"),
               ".phantomlauncher",
               "offline",
               "multiver"
           );

            private static readonly string _CrackedAccountPath = Path.Combine(
                Environment.GetEnvironmentVariable("USERPROFILE"),
                ".phantomlauncher",
                "addons",
                "CrackedAccount.jar"
            );

            private static readonly string _HitDelayFixPath = Path.Combine(
                Environment.GetEnvironmentVariable("USERPROFILE"),
                ".phantomlauncher",
                "addons",
                "HitDelayFix.jar"
            );

            private static readonly string _texturesDirectory = Path.Combine(
                Environment.GetEnvironmentVariable("USERPROFILE"),
                ".phantomlauncher",
                "textures"
            );
            private static readonly string _AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\"
            );

            private static readonly string _assetsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\assets");

            private static readonly string _minecraftDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft");


            private static Process process;
            public static void LaunchLunar(string jatekosnev, bool crackedAccountValue, bool oldversionValue, string mb)
            {

                var userProfile = Environment.GetEnvironmentVariable("USERPROFILE");

                var lunarDirectory = Path.Combine(userProfile, @".phantomlauncher\offline\multiver");

                var lunarJrePath = Path.Combine(userProfile, @".phantomlauncher\custom-jre\zulu18.32.11-ca-jdk18.0.2-win_x64\bin\javaw");


                var processArguments = GetProcessArguments(jatekosnev, crackedAccountValue, oldversionValue, mb); 

                try
                {
                    process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            WorkingDirectory = lunarDirectory,

                            FileName = lunarJrePath,

                            Arguments = processArguments,

                            UseShellExecute = false,

                            RedirectStandardOutput = true,

                            StandardOutputEncoding = Encoding.UTF8,
                        },
                        EnableRaisingEvents = true
                    };

                    // Subscribe to the OutputDataReceived event to read and process the standard output


                    // Subscribe to the Exited event and close the launched process when it exits
                    process.Exited += new EventHandler((sender, args) => Environment.Exit(0));

                    // Subscribe to the ProcessExit event to close the launched process if it is still running when the application exits
                    AppDomain.CurrentDomain.ProcessExit += new EventHandler((sender, args) =>
                    {
                    });

                    // Start the process
                    process.Start();

                    // Begin reading the standard output
                    process.BeginOutputReadLine();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unkown Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private static string GetProcessArguments(string jatekosnev, bool crackedAccountValue, bool oldversionValue, string mb)
            {
                if (oldversionValue)
                {
                    if (crackedAccountValue == true)
                    {
                        return GetBasicArguments(jatekosnev, mb);
                    }
                    else if (crackedAccountValue == false)
                    {
                        return GetBasicArgumentsoutAccount(mb);
                    }
                    else
                    {
                        return GetBasicArgumentsnothing(mb);
                    }
                }
                else
                {
                    return GetBasicArguments118(jatekosnev, mb);
                }
            }


            public static string GetBasicArguments118(string jatekosnev, string mb)
            {
                //Return the process arguments
                string breathingOption = jatekosnev;
                string args = @"--add-modules jdk.naming.dns --add-exports jdk.naming.dns/com.sun.jndi.dns=java.naming -Djna.boot.library.path=natives -Dlog4j2.formatMsgNoLookups=true --add-opens java.base/java.io=ALL-UNNAMED -Xmx" + mb + @"m -Djava.library.path=natives -XX:+DisableAttachMechanism -cp ""common-0.1.0-SNAPSHOT-all.jar;v1_8-0.1.0-SNAPSHOT-all.jar;optifine-0.1.0-SNAPSHOT-all.jar;genesis-0.1.0-SNAPSHOT-all.jar;lunar-lang.jar;lunar-emote.jar;lunar.jar"" ""-javaagent:" + _HitDelayFixPath + @""" ""-javaagent:" + _CrackedAccountPath + "=" + breathingOption + @""" com.moonsworth.lunar.genesis.Genesis --version 1.18.2 --accessToken 0 --assetIndex 1.18 --userProperties {} --gameDir """ + _minecraftDirectory + @""" --texturesDir """ + _texturesDirectory + @""" --launcherVersion 3.2.0 --hwid 0 --installationId 0 --width 640 --height 480 --workingDirectory . --classpathDir . --ichorClassPath common-0.1.0-SNAPSHOT-all.jar,v1_8-0.1.0-SNAPSHOT-all.jar,optifine-0.1.0-SNAPSHOT-all.jar,genesis-0.1.0-SNAPSHOT-all.jar,lunar-lang.jar,lunar-emote.jar,lunar.jar --ichorExternalFiles OptiFine_v1_18_2.jar";

                return args;
            }

            public static string GetBasicArguments(string jatekosnev, string mb)
            {
                //Return the process arguments
                string breathingOption = jatekosnev;
                string args = @"--add-modules jdk.naming.dns --add-exports jdk.naming.dns/com.sun.jndi.dns=java.naming -Djna.boot.library.path=natives -Dlog4j2.formatMsgNoLookups=true --add-opens java.base/java.io=ALL-UNNAMED -Xmx" + mb + @"m -Djava.library.path=natives -XX:+DisableAttachMechanism -cp ""common-0.1.0-SNAPSHOT-all.jar;v1_8-0.1.0-SNAPSHOT-all.jar;optifine-0.1.0-SNAPSHOT-all.jar;genesis-0.1.0-SNAPSHOT-all.jar;lunar-lang.jar;lunar-emote.jar;lunar.jar"" ""-javaagent:" + _HitDelayFixPath + @""" ""-javaagent:" + _CrackedAccountPath + "=" + breathingOption + @""" com.moonsworth.lunar.genesis.Genesis --version 1.8.9 --accessToken 0 --assetIndex 1.8 --userProperties {} --gameDir """ + _minecraftDirectory + @""" --texturesDir """ + _texturesDirectory + @""" --launcherVersion 3.2.0 --hwid 0 --installationId 0 --width 640 --height 480 --workingDirectory . --classpathDir . --ichorClassPath common-0.1.0-SNAPSHOT-all.jar,v1_8-0.1.0-SNAPSHOT-all.jar,optifine-0.1.0-SNAPSHOT-all.jar,genesis-0.1.0-SNAPSHOT-all.jar,lunar-lang.jar,lunar-emote.jar,lunar.jar --ichorExternalFiles OptiFine_v1_8.jar";

                return args;
            }
            public static string GetBasicArgumentsoutHitdelayfix(string jatekosnev, string mb)
            {
                //Return the process arguments
                string breathingOption = jatekosnev;
                string args = @"--add-modules jdk.naming.dns --add-exports jdk.naming.dns/com.sun.jndi.dns=java.naming -Djna.boot.library.path=natives -Dlog4j2.formatMsgNoLookups=true --add-opens java.base/java.io=ALL-UNNAMED -Xmx" + mb + @"m -Djava.library.path=natives -XX:+DisableAttachMechanism -cp ""common-0.1.0-SNAPSHOT-all.jar;v1_8-0.1.0-SNAPSHOT-all.jar;optifine-0.1.0-SNAPSHOT-all.jar;genesis-0.1.0-SNAPSHOT-all.jar;lunar-lang.jar;lunar-emote.jar;lunar.jar"" ""-javaagent:" + _CrackedAccountPath + "=" + breathingOption + @""" com.moonsworth.lunar.genesis.Genesis --version 1.8.9 --accessToken 0 --assetIndex 1.8 --userProperties {} --gameDir """ + _minecraftDirectory + @""" --texturesDir """ + _texturesDirectory + @""" --launcherVersion 3.2.0 --hwid 0 --installationId 0 --width 640 --height 480 --workingDirectory . --classpathDir . --ichorClassPath common-0.1.0-SNAPSHOT-all.jar,v1_8-0.1.0-SNAPSHOT-all.jar,optifine-0.1.0-SNAPSHOT-all.jar,genesis-0.1.0-SNAPSHOT-all.jar,lunar-lang.jar,lunar-emote.jar,lunar.jar --ichorExternalFiles OptiFine_v1_8.jar";

                return args;
            }

            public static string GetBasicArgumentsoutAccount(string mb)
            {
                //Return the process arguments
                string args = @"--add-modules jdk.naming.dns --add-exports jdk.naming.dns/com.sun.jndi.dns=java.naming -Djna.boot.library.path=natives -Dlog4j2.formatMsgNoLookups=true --add-opens java.base/java.io=ALL-UNNAMED -Xmx" + mb + @"m -Djava.library.path=natives -XX:+DisableAttachMechanism -cp ""common-0.1.0-SNAPSHOT-all.jar;v1_8-0.1.0-SNAPSHOT-all.jar;optifine-0.1.0-SNAPSHOT-all.jar;genesis-0.1.0-SNAPSHOT-all.jar;lunar-lang.jar;lunar-emote.jar;lunar.jar"" ""-javaagent:" + _HitDelayFixPath + @""" com.moonsworth.lunar.genesis.Genesis --version 1.8.9 --accessToken 0 --assetIndex 1.8 --userProperties {} --gameDir """ + _minecraftDirectory + @""" --texturesDir """ + _texturesDirectory + @""" --launcherVersion 3.2.0 --hwid 0 --installationId 0 --width 640 --height 480 --workingDirectory . --classpathDir . --ichorClassPath common-0.1.0-SNAPSHOT-all.jar,v1_8-0.1.0-SNAPSHOT-all.jar,optifine-0.1.0-SNAPSHOT-all.jar,genesis-0.1.0-SNAPSHOT-all.jar,lunar-lang.jar,lunar-emote.jar,lunar.jar --ichorExternalFiles OptiFine_v1_8.jar";

                return args;
            }

            public static string GetBasicArgumentsnothing(string mb)
            {
                //Return the process arguments
                string args = @"--add-modules jdk.naming.dns --add-exports jdk.naming.dns/com.sun.jndi.dns=java.naming -Djna.boot.library.path=natives -Dlog4j2.formatMsgNoLookups=true --add-opens java.base/java.io=ALL-UNNAMED -Xmx" + mb + @"m -Djava.library.path=natives -XX:+DisableAttachMechanism -cp ""common-0.1.0-SNAPSHOT-all.jar;v1_8-0.1.0-SNAPSHOT-all.jar;optifine-0.1.0-SNAPSHOT-all.jar;genesis-0.1.0-SNAPSHOT-all.jar;lunar-lang.jar;lunar-emote.jar;lunar.jar""  com.moonsworth.lunar.genesis.Genesis --version 1.8.9 --accessToken 0 --assetIndex 1.8 --userProperties {} --gameDir """ + _minecraftDirectory + @""" --texturesDir """ + _texturesDirectory + @""" --launcherVersion 3.2.0 --hwid 0 --installationId 0 --width 640 --height 480 --workingDirectory . --classpathDir . --ichorClassPath common-0.1.0-SNAPSHOT-all.jar,v1_8-0.1.0-SNAPSHOT-all.jar,optifine-0.1.0-SNAPSHOT-all.jar,genesis-0.1.0-SNAPSHOT-all.jar,lunar-lang.jar,lunar-emote.jar,lunar.jar --ichorExternalFiles OptiFine_v1_8.jar";

                return args;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
