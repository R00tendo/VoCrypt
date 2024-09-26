using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoCryptLib;

namespace vocrypt
{
    public partial class VoCrypt
    {
        private async void processRead()
        {
            IEnumerable<int> progress;
            try
            {
                progress = ReadWrite.ReadFile(openFileDialog2.FileName,
                    saveFileDialog2.FileName,
                    textBox2.Text);
                foreach (int percentage in progress)
                {
                    progressBar1.Value = percentage;
                }
                MessageBox.Show("File created!");
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Could not decrypt file!\n\nPossible reasons for this include: wrong password, corruption or intentional data destruction.");
                if (File.Exists(saveFileDialog2.FileName))
                    File.Delete(saveFileDialog2.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async void processWrite()
        {
            var progress = ReadWrite.WriteFile(openFileDialog1.FileName,
                saveFileDialog1.FileName,
                textBox1.Text);
            foreach (int percentage in progress)
            {
                progressBar1.Value = percentage;
            }
            progressBar1.Visible = false;
            MessageBox.Show("File created!");
        }
        private void cleanUp()
        {
            openFileDialog1.FileName = string.Empty;
            openFileDialog2.FileName = string.Empty;

            saveFileDialog1.FileName = string.Empty;
            saveFileDialog2.FileName = string.Empty;

            textBox1.Text = string.Empty;

            label13.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;

            SwitchStopped = false;

            button1.Text = "Select file";
            button2.Text = "Select output file";
            button5.Text = "Select file";
            button8.Text = "Select folder";
            button4.Enabled = false;
            button6.Enabled = false;

            progressBar1.Visible = false;
        }
        private async void processDestroy()
        {
            progressBar1.Visible = true;
            try
            {
                var progress = ReadWrite.Destroy(openFileDialog2.FileName, checkBox1.Checked);
                foreach (int percentage in progress)
                {
                    progressBar1.Value = percentage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

            if (checkBox4.Checked)
            {
                var fileName = openFileDialog2.FileName;
                for (var i = 0; i < 10; i++)
                {
                    var newFileName = new string(i.ToString()[0], Path.GetFileName(fileName).Length);
                    FileInfo file = new FileInfo(fileName);
                    fileName = file.Directory.FullName + "\\" + newFileName;
                    file.MoveTo(fileName);
                }
                File.Delete(fileName);
            }
            if (checkBox3.Checked)
            {
                Application.Exit();
                return;
            }
        }
        private async void timedDestruction()
        {
            button7.Visible = true;
            label13.Visible = true;

            decimal secs = numericUpDown1.Value;
            decimal minsSecs = numericUpDown2.Value * 60;
            decimal hoursSecs = numericUpDown3.Value * 60 * 60;
            decimal daysSecs = numericUpDown4.Value * 24 * 60 * 60;
            decimal waiTime = secs + minsSecs + hoursSecs + daysSecs;

            while (waiTime > 0)
            {
                await Task.Delay(1000);
                waiTime--;
                if (SwitchStopped)
                {
                    break;
                }
                label13.Text = $"Time left: {waiTime}s";
            }
            if (SwitchStopped)
            {
                MessageBox.Show("Dead man's switch disabled.");
            }

            button7.Visible = false;
            label13.Visible = false;
            if (!SwitchStopped)
            {
                var exit = checkBox3.Checked;
                if (openFileDialog2.FileName != string.Empty)
                {
                    if (folderBrowserDialog1.SelectedPath != string.Empty)
                    {
                        checkBox3.Checked = false;
                    }
                    await Task.Run(processDestroy);
                }
                checkBox3.Checked = exit;
                await Task.Run(deleteFolderIfAny);
            }

            cleanUp();
        }

        private async void deleteFolderIfAny()
        {
            bool exit = checkBox3.Checked;
            checkBox3.Checked = false;
            string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath,
                "*.VoCr",
                SearchOption.AllDirectories);

            for (var i = 0; i < files.Length; i++)
            {
                var (file, index) = (files[i], i);
                if (i == files.Length - 1)
                {
                    checkBox3.Checked = exit;
                }
                openFileDialog2.FileName = file;
                processDestroy();
            }
        }
    }
}
