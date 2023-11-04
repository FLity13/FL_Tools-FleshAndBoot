using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FL_Tools_1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        class CommadsHelper
        {
            public static bool FastbootChecker()
            {
                Process process = new Process();
                process.StartInfo.FileName = "platform-tools/fastboot.exe";
                process.StartInfo.Arguments = "devices";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
                process.Close();

                if (!string.IsNullOrEmpty(output))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static void FastbootFile(string Argument)
            {
                OpenFileDialog OPF = new OpenFileDialog();
                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show("You may damage your device. You take responsibility only for yourself. Continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string fastbootPath = @"platform-tools\fastboot.exe";

                        ProcessStartInfo startInfo = new ProcessStartInfo(fastbootPath);
                        startInfo.Arguments = $"{Argument} {OPF.FileName}";
                        startInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(fastbootPath);
                        startInfo.RedirectStandardOutput = true;
                        startInfo.RedirectStandardError = true;
                        startInfo.UseShellExecute = false;
                        startInfo.CreateNoWindow = true;

                        using (Process process = new Process())
                        {
                            process.StartInfo = startInfo;
                            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                            process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);

                            process.Start();
                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();

                            process.WaitForExit();
                        }
                    }
                }
            }

            public static void Fastboot(string Argument)
            {
                if (MessageBox.Show("You may damage your device. You take responsibility only for yourself. Continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string fastbootPath = @"platform-tools\fastboot.exe";

                    ProcessStartInfo startInfo = new ProcessStartInfo(fastbootPath);
                    startInfo.Arguments = $"{Argument}";
                    startInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(fastbootPath);
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;

                    using (Process process = new Process())
                    {
                        process.StartInfo = startInfo;
                        process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                        process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);

                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();

                        process.WaitForExit();
                    }
                }
            }

            public static void ADB(string Argument)
            {
                string fastbootPath = @"platform-tools\adb.exe";

                ProcessStartInfo startInfo = new ProcessStartInfo(fastbootPath);
                startInfo.Arguments = $"{Argument}";
                startInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(fastbootPath);
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                    process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();
                }
            }

            public static string GetFile()
            {
                OpenFileDialog OPF = new OpenFileDialog();
                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    return OPF.FileName;
                }
                else { MessageBox.Show("Canceled"); return ""; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommadsHelper.ADB("reboot");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CommadsHelper.ADB("reboot recovery");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CommadsHelper.ADB("reboot bootloader");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("reboot");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("reboot recovery");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                if (CommadsHelper.FastbootChecker())
                {
                    CommadsHelper.FastbootFile("flash recovery");
                }
                else
                {
                    MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
                }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
                if (CommadsHelper.FastbootChecker())
                {
                    CommadsHelper.FastbootFile("flash boot");
                }
                else
                {
                    MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
                }

        }

        private void button8_Click(object sender, EventArgs e)
        {

                if (CommadsHelper.FastbootChecker())
                {
                    CommadsHelper.FastbootFile("--disable-verity --disable-verification flash vbmeta");
                }
                else
                {
                    MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
                }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

                if (CommadsHelper.FastbootChecker())
                {
                    CommadsHelper.FastbootFile("boot");
                }
                else
                {
                    MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
                }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
                if (CommadsHelper.FastbootChecker())
                {
                    CommadsHelper.FastbootFile("update");
                }
                else
                {
                    MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
                }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("erase system");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("erase userdata");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("erase recovery");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("erase boot");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("erase cache");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {

            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("erase radio");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("-w");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("oem unlock");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("flashing unlock");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("oem lock");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (CommadsHelper.FastbootChecker())
            {
                CommadsHelper.Fastboot("flashing lock");
            }
            else
            {
                MessageBox.Show("Phone is disconnect of FastBoot. Try again...");
            }
        }
    }
}
