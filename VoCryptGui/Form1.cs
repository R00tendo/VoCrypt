using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using VoCryptLib;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace vocrypt
{
    public partial class VoCrypt : Form
    {
        public VoCrypt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult selected = openFileDialog1.ShowDialog();
            if (selected == DialogResult.Cancel) return;
            button1.Text = Path.GetFileName(openFileDialog1.FileName);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Path.GetFileName(openFileDialog1.FileName) + ".VoCr";
            DialogResult selected = saveFileDialog1.ShowDialog();
            if (selected == DialogResult.Cancel)
            {
                saveFileDialog1.FileName = String.Empty;
                return;
            }
            button2.Text = Path.GetFileName(saveFileDialog1.FileName);
            button3.Enabled = true;
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName.Length == 0
                || saveFileDialog1.FileName.Length == 0)
            {
                MessageBox.Show("Invalid input or output path");
                return;
            }
            progressBar1.Visible = true;

            try
            {
                await Task.Run(new Action(processWrite));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            cleanUp();
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to DESTROY THE FILE(S) YOU SELECTED?",
                                     "Destroy file(s)?",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                if (checkBox2.Checked)
                {
                    timedDestruction();
                    return;
                }
                try
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
                    MessageBox.Show("File(s) destroyed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else { MessageBox.Show("That was a close one!"); }
            cleanUp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult selected = openFileDialog2.ShowDialog();
            if (selected == DialogResult.Cancel) return;
            button5.Text = Path.GetFileName(openFileDialog2.FileName);
            button4.Enabled = true;
            button6.Enabled = true;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            DialogResult selected = saveFileDialog2.ShowDialog();
            if (selected == DialogResult.Cancel) return;
            progressBar1.Visible = true;

            try
            {
                await Task.Run(new Action(processRead));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            button5.Text = "Select output file";
            cleanUp();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SwitchStopped = true;
        }

        private bool SwitchStopped = false;

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult selected = folderBrowserDialog1.ShowDialog();
            if (selected == DialogResult.Cancel) return;
            button8.Text = Path.GetFileName(folderBrowserDialog1.SelectedPath);
            button4.Enabled = true;
        }

    }
}
