namespace FirefighterController
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.port_list = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baud_rate = new System.Windows.Forms.ComboBox();
            this.received_data_textbox = new System.Windows.Forms.RichTextBox();
            this.left_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.forward_button = new System.Windows.Forms.Button();
            this.backward_button = new System.Windows.Forms.Button();
            this.right_button = new System.Windows.Forms.Button();
            this.automatic_checker = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.automatic_status = new System.Windows.Forms.Label();
            this.pump_on_button = new System.Windows.Forms.Button();
            this.pump_off_button = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.direction_textbox = new System.Windows.Forms.TextBox();
            this.pump_on_radioButton = new System.Windows.Forms.RadioButton();
            this.pump_off_radioButton = new System.Windows.Forms.RadioButton();
            this.about_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // port_list
            // 
            this.port_list.FormattingEnabled = true;
            this.port_list.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30",
            "COM31",
            "COM32",
            "COM33",
            "COM34",
            "COM35",
            "COM36",
            "COM37",
            "COM38",
            "COM39",
            "COM40"});
            this.port_list.Location = new System.Drawing.Point(85, 21);
            this.port_list.Name = "port_list";
            this.port_list.Size = new System.Drawing.Size(75, 21);
            this.port_list.TabIndex = 0;
            this.port_list.SelectedIndexChanged += new System.EventHandler(this.port_list_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PORT NAME : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BAUD RATE : ";
            // 
            // baud_rate
            // 
            this.baud_rate.FormattingEnabled = true;
            this.baud_rate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "38400",
            "57600",
            "115200"});
            this.baud_rate.Location = new System.Drawing.Point(259, 21);
            this.baud_rate.Name = "baud_rate";
            this.baud_rate.Size = new System.Drawing.Size(72, 21);
            this.baud_rate.TabIndex = 3;
            this.baud_rate.SelectedIndexChanged += new System.EventHandler(this.baud_rate_SelectedIndexChanged);
            // 
            // received_data_textbox
            // 
            this.received_data_textbox.Location = new System.Drawing.Point(0, 19);
            this.received_data_textbox.Name = "received_data_textbox";
            this.received_data_textbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.received_data_textbox.Size = new System.Drawing.Size(434, 138);
            this.received_data_textbox.TabIndex = 4;
            this.received_data_textbox.Text = "";
            this.received_data_textbox.TextChanged += new System.EventHandler(this.received_data_textbox_TextChanged);
            // 
            // left_button
            // 
            this.left_button.BackColor = System.Drawing.Color.Blue;
            this.left_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.left_button.ForeColor = System.Drawing.Color.Yellow;
            this.left_button.Location = new System.Drawing.Point(58, 59);
            this.left_button.Name = "left_button";
            this.left_button.Size = new System.Drawing.Size(102, 36);
            this.left_button.TabIndex = 6;
            this.left_button.Text = "Left";
            this.left_button.UseVisualStyleBackColor = false;
            this.left_button.Click += new System.EventHandler(this.left_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.BackColor = System.Drawing.Color.Blue;
            this.stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop_button.ForeColor = System.Drawing.Color.Yellow;
            this.stop_button.Location = new System.Drawing.Point(166, 59);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(102, 36);
            this.stop_button.TabIndex = 7;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = false;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // forward_button
            // 
            this.forward_button.BackColor = System.Drawing.Color.Blue;
            this.forward_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forward_button.ForeColor = System.Drawing.Color.Yellow;
            this.forward_button.Location = new System.Drawing.Point(166, 19);
            this.forward_button.Name = "forward_button";
            this.forward_button.Size = new System.Drawing.Size(102, 36);
            this.forward_button.TabIndex = 8;
            this.forward_button.Text = "Forward";
            this.forward_button.UseVisualStyleBackColor = false;
            this.forward_button.Click += new System.EventHandler(this.forward_button_Click);
            // 
            // backward_button
            // 
            this.backward_button.BackColor = System.Drawing.Color.Blue;
            this.backward_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backward_button.ForeColor = System.Drawing.Color.Yellow;
            this.backward_button.Location = new System.Drawing.Point(166, 101);
            this.backward_button.Name = "backward_button";
            this.backward_button.Size = new System.Drawing.Size(102, 36);
            this.backward_button.TabIndex = 9;
            this.backward_button.Text = "Backward";
            this.backward_button.UseVisualStyleBackColor = false;
            this.backward_button.Click += new System.EventHandler(this.backward_button_Click);
            // 
            // right_button
            // 
            this.right_button.BackColor = System.Drawing.Color.Blue;
            this.right_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.right_button.ForeColor = System.Drawing.Color.Yellow;
            this.right_button.Location = new System.Drawing.Point(274, 59);
            this.right_button.Name = "right_button";
            this.right_button.Size = new System.Drawing.Size(102, 36);
            this.right_button.TabIndex = 10;
            this.right_button.Text = "Right";
            this.right_button.UseVisualStyleBackColor = false;
            this.right_button.Click += new System.EventHandler(this.right_button_Click);
            // 
            // automatic_checker
            // 
            this.automatic_checker.AutoSize = true;
            this.automatic_checker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.automatic_checker.Location = new System.Drawing.Point(15, 307);
            this.automatic_checker.Name = "automatic_checker";
            this.automatic_checker.Size = new System.Drawing.Size(116, 17);
            this.automatic_checker.TabIndex = 11;
            this.automatic_checker.Text = "Automatic mode";
            this.automatic_checker.UseVisualStyleBackColor = true;
            this.automatic_checker.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connect_button);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.port_list);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.baud_rate);
            this.groupBox1.Location = new System.Drawing.Point(15, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 52);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Status";
            // 
            // connect_button
            // 
            this.connect_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect_button.ForeColor = System.Drawing.Color.Blue;
            this.connect_button.Location = new System.Drawing.Point(337, 21);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(90, 23);
            this.connect_button.TabIndex = 4;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = false;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.received_data_textbox);
            this.groupBox2.Location = new System.Drawing.Point(15, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 163);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Received Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.forward_button);
            this.groupBox3.Controls.Add(this.stop_button);
            this.groupBox3.Controls.Add(this.left_button);
            this.groupBox3.Controls.Add(this.right_button);
            this.groupBox3.Controls.Add(this.backward_button);
            this.groupBox3.Location = new System.Drawing.Point(15, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 143);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Console";
            // 
            // automatic_status
            // 
            this.automatic_status.AutoSize = true;
            this.automatic_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.automatic_status.ForeColor = System.Drawing.Color.Red;
            this.automatic_status.Location = new System.Drawing.Point(244, 306);
            this.automatic_status.Name = "automatic_status";
            this.automatic_status.Size = new System.Drawing.Size(198, 16);
            this.automatic_status.TabIndex = 15;
            this.automatic_status.Text = "Automatic Mode Deactivate";
            // 
            // pump_on_button
            // 
            this.pump_on_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pump_on_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pump_on_button.ForeColor = System.Drawing.Color.Yellow;
            this.pump_on_button.Location = new System.Drawing.Point(15, 479);
            this.pump_on_button.Name = "pump_on_button";
            this.pump_on_button.Size = new System.Drawing.Size(75, 23);
            this.pump_on_button.TabIndex = 16;
            this.pump_on_button.Text = "Pump On";
            this.pump_on_button.UseVisualStyleBackColor = false;
            this.pump_on_button.Click += new System.EventHandler(this.pump_on_button_Click);
            // 
            // pump_off_button
            // 
            this.pump_off_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pump_off_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pump_off_button.ForeColor = System.Drawing.Color.Yellow;
            this.pump_off_button.Location = new System.Drawing.Point(374, 482);
            this.pump_off_button.Name = "pump_off_button";
            this.pump_off_button.Size = new System.Drawing.Size(75, 23);
            this.pump_off_button.TabIndex = 17;
            this.pump_off_button.Text = "Pump Off";
            this.pump_off_button.UseVisualStyleBackColor = false;
            this.pump_off_button.Click += new System.EventHandler(this.pump_off_button_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.direction_textbox);
            this.groupBox4.Location = new System.Drawing.Point(15, 236);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(434, 50);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Status : ";
            // 
            // direction_textbox
            // 
            this.direction_textbox.Location = new System.Drawing.Point(58, 20);
            this.direction_textbox.Name = "direction_textbox";
            this.direction_textbox.Size = new System.Drawing.Size(361, 20);
            this.direction_textbox.TabIndex = 0;
            // 
            // pump_on_radioButton
            // 
            this.pump_on_radioButton.AutoSize = true;
            this.pump_on_radioButton.Location = new System.Drawing.Point(107, 482);
            this.pump_on_radioButton.Name = "pump_on_radioButton";
            this.pump_on_radioButton.Size = new System.Drawing.Size(75, 17);
            this.pump_on_radioButton.TabIndex = 19;
            this.pump_on_radioButton.TabStop = true;
            this.pump_on_radioButton.Text = "PUMP ON";
            this.pump_on_radioButton.UseVisualStyleBackColor = true;
            this.pump_on_radioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pump_off_radioButton
            // 
            this.pump_off_radioButton.AutoSize = true;
            this.pump_off_radioButton.Location = new System.Drawing.Point(289, 485);
            this.pump_off_radioButton.Name = "pump_off_radioButton";
            this.pump_off_radioButton.Size = new System.Drawing.Size(79, 17);
            this.pump_off_radioButton.TabIndex = 20;
            this.pump_off_radioButton.TabStop = true;
            this.pump_off_radioButton.Text = "PUMP OFF";
            this.pump_off_radioButton.UseVisualStyleBackColor = true;
            this.pump_off_radioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // about_button
            // 
            this.about_button.BackColor = System.Drawing.Color.Maroon;
            this.about_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.about_button.Location = new System.Drawing.Point(193, 516);
            this.about_button.Name = "about_button";
            this.about_button.Size = new System.Drawing.Size(75, 33);
            this.about_button.TabIndex = 21;
            this.about_button.Text = "About";
            this.about_button.UseVisualStyleBackColor = false;
            this.about_button.Click += new System.EventHandler(this.about_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(461, 551);
            this.Controls.Add(this.about_button);
            this.Controls.Add(this.pump_off_radioButton);
            this.Controls.Add(this.pump_on_radioButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pump_off_button);
            this.Controls.Add(this.pump_on_button);
            this.Controls.Add(this.automatic_status);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.automatic_checker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Fire Fighter Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox port_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baud_rate;
        private System.Windows.Forms.RichTextBox received_data_textbox;
        private System.Windows.Forms.Button left_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button forward_button;
        private System.Windows.Forms.Button backward_button;
        private System.Windows.Forms.Button right_button;
        private System.Windows.Forms.CheckBox automatic_checker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label automatic_status;
        private System.Windows.Forms.Button pump_on_button;
        private System.Windows.Forms.Button pump_off_button;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox direction_textbox;
        private System.Windows.Forms.RadioButton pump_on_radioButton;
        private System.Windows.Forms.RadioButton pump_off_radioButton;
        private System.Windows.Forms.Button about_button;
        private System.Windows.Forms.Button connect_button;

    }
}

