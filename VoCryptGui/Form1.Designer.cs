namespace vocrypt
{
    partial class VoCrypt
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            button1 = new Button();
            label4 = new Label();
            button2 = new Button();
            label5 = new Label();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            button5 = new Button();
            label7 = new Label();
            textBox2 = new TextBox();
            button6 = new Button();
            openFileDialog2 = new OpenFileDialog();
            saveFileDialog2 = new SaveFileDialog();
            progressBar1 = new ProgressBar();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            label8 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            button7 = new Button();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            button8 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label14 = new Label();
            label15 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 77);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '•';
            textBox1.Size = new Size(256, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Myanmar Text", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(155, 43);
            label1.TabIndex = 2;
            label1.Text = "Create a file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(267, 15);
            label2.TabIndex = 3;
            label2.Text = "Password (nothing for no password protection)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Myanmar Text", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(384, 9);
            label3.Name = "label3";
            label3.Size = new Size(263, 43);
            label3.TabIndex = 4;
            label3.Text = "Open / destroy file(s)";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "VoCr";
            // 
            // button1
            // 
            button1.Location = new Point(12, 134);
            button1.Name = "button1";
            button1.Size = new Size(256, 23);
            button1.TabIndex = 5;
            button1.Text = "Select file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLight;
            label4.Location = new Point(12, 116);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 6;
            label4.Text = "File to convert";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(12, 187);
            button2.Name = "button2";
            button2.Size = new Size(256, 23);
            button2.TabIndex = 7;
            button2.Text = "Select output file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLight;
            label5.Location = new Point(12, 169);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 8;
            label5.Text = "Output path";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ControlLight;
            button3.Location = new Point(12, 230);
            button3.Name = "button3";
            button3.Size = new Size(256, 30);
            button3.TabIndex = 9;
            button3.Text = "CREATE FILE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkRed;
            button4.Enabled = false;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Red;
            button4.Location = new Point(391, 180);
            button4.Name = "button4";
            button4.Size = new Size(129, 30);
            button4.TabIndex = 14;
            button4.Text = "DESTROY FILE";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLight;
            label6.Location = new Point(391, 116);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 13;
            label6.Text = "File to open";
            // 
            // button5
            // 
            button5.Location = new Point(391, 134);
            button5.Name = "button5";
            button5.Size = new Size(128, 23);
            button5.TabIndex = 12;
            button5.Text = "Select file";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLight;
            label7.Location = new Point(391, 59);
            label7.Name = "label7";
            label7.Size = new Size(227, 15);
            label7.TabIndex = 11;
            label7.Text = "Password (not required for destruction)";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(391, 77);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '•';
            textBox2.Size = new Size(256, 23);
            textBox2.TabIndex = 10;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.ControlLight;
            button6.Location = new Point(526, 180);
            button6.Name = "button6";
            button6.Size = new Size(121, 30);
            button6.TabIndex = 15;
            button6.Text = "OPEN FILE";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // saveFileDialog2
            // 
            saveFileDialog2.Title = "Save file";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 347);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(705, 23);
            progressBar1.Step = 1;
            progressBar1.TabIndex = 16;
            progressBar1.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = SystemColors.ControlLight;
            checkBox1.Location = new Point(391, 216);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(102, 19);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "wipe key only";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox2.ForeColor = SystemColors.ControlLight;
            checkBox2.Location = new Point(391, 241);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(155, 19);
            checkBox2.TabIndex = 18;
            checkBox2.Text = "set a dead man's switch";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(390, 292);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 23);
            numericUpDown1.TabIndex = 19;
            numericUpDown1.Tag = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlLight;
            label8.Location = new Point(390, 269);
            label8.Name = "label8";
            label8.Size = new Size(143, 15);
            label8.TabIndex = 20;
            label8.Text = "Dead man's switch timer";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(452, 292);
            numericUpDown2.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(56, 23);
            numericUpDown2.TabIndex = 21;
            numericUpDown2.Tag = "";
            numericUpDown2.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(514, 292);
            numericUpDown3.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(56, 23);
            numericUpDown3.TabIndex = 22;
            numericUpDown3.Tag = "";
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(576, 292);
            numericUpDown4.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(56, 23);
            numericUpDown4.TabIndex = 23;
            numericUpDown4.Tag = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ControlLight;
            label9.Location = new Point(390, 318);
            label9.Name = "label9";
            label9.Size = new Size(30, 15);
            label9.TabIndex = 24;
            label9.Text = "secs";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ControlLight;
            label10.Location = new Point(452, 318);
            label10.Name = "label10";
            label10.Size = new Size(33, 15);
            label10.TabIndex = 25;
            label10.Text = "mins";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ControlLight;
            label11.Location = new Point(514, 318);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 26;
            label11.Text = "hours";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ControlLight;
            label12.Location = new Point(576, 318);
            label12.Name = "label12";
            label12.Size = new Size(31, 15);
            label12.TabIndex = 27;
            label12.Text = "days";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = SystemColors.ControlLight;
            label13.Location = new Point(491, 347);
            label13.Name = "label13";
            label13.Size = new Size(82, 21);
            label13.TabIndex = 28;
            label13.Text = "Time left:";
            label13.Visible = false;
            // 
            // button7
            // 
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ControlLight;
            button7.Location = new Point(391, 347);
            button7.Name = "button7";
            button7.Size = new Size(94, 23);
            button7.TabIndex = 29;
            button7.Text = "STOP TIMER";
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            button7.Click += button7_Click;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox3.ForeColor = SystemColors.ControlLight;
            checkBox3.Location = new Point(491, 216);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(229, 19);
            checkBox3.TabIndex = 30;
            checkBox3.Text = "stealthy (exits app after destruction)";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox4.ForeColor = SystemColors.ControlLight;
            checkBox4.Location = new Point(545, 241);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(83, 19);
            checkBox4.TabIndex = 31;
            checkBox4.Text = "delete file";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(519, 134);
            button8.Name = "button8";
            button8.Size = new Size(128, 23);
            button8.TabIndex = 32;
            button8.Text = "Select folder";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ControlLight;
            label14.Location = new Point(519, 116);
            label14.Name = "label14";
            label14.Size = new Size(102, 15);
            label14.TabIndex = 33;
            label14.Text = "Folder to destroy";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ControlLight;
            label15.Location = new Point(519, 160);
            label15.Name = "label15";
            label15.Size = new Size(205, 15);
            label15.TabIndex = 34;
            label15.Text = "^ only targets .VoCr files (recursive)";
            // 
            // VoCrypt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(729, 381);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(button8);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(button7);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(label8);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(progressBar1);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(label6);
            Controls.Add(button5);
            Controls.Add(label7);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            MaximumSize = new Size(745, 420);
            MinimumSize = new Size(745, 420);
            Name = "VoCrypt";
            Text = "VoCrypt";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button button1;
        private Label label4;
        private Button button2;
        private Label label5;
        private Button button3;
        private Button button4;
        private Label label6;
        private Button button5;
        private Label label7;
        private TextBox textBox2;
        private Button button6;
        private OpenFileDialog openFileDialog2;
        private SaveFileDialog saveFileDialog2;
        private ProgressBar progressBar1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private NumericUpDown numericUpDown1;
        private Label label8;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button button7;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Button button8;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label14;
        private Label label15;
    }
}
