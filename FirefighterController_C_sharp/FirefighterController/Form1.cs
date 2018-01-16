using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
//using System.IO.Ports.SerialPort;

namespace FirefighterController
{
    public partial class Form1 : Form
    {
        string RxString;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                serialPort1.WriteLine("F");
                direction_textbox.Text = "Moving Forward";
            }
            if (e.KeyCode == Keys.Down)
            {
                serialPort1.WriteLine("B");
                direction_textbox.Text = "Moving Backward";
            }
            if (e.KeyCode == Keys.Left)
            {
                serialPort1.WriteLine("L");
                direction_textbox.Text = "Moving Left";
            }
            if (e.KeyCode == Keys.Right)
            {
                serialPort1.WriteLine("R");
                direction_textbox.Text = "Moving Right";
            }
            if (e.KeyCode == Keys.P)
            {
                serialPort1.WriteLine("P");
                direction_textbox.Text = "Pump On";
            }
            if (e.KeyCode == Keys.O)
            {
                serialPort1.WriteLine("p");
                direction_textbox.Text = "Pump Off";
            }
        }

        private void forward_button_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("F");
            direction_textbox.Text = "Moving Forward";
        }
        

        private void backward_button_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("B");
            direction_textbox.Text = "Moving Backward";
        }

        private void left_button_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("L");
            direction_textbox.Text = "Moving Left";
        }

        private void right_button_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("R");
            direction_textbox.Text = "Moving Right";
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("S");
            direction_textbox.Text = "Stop";
            
        }

        private void pump_on_button_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("P");
            direction_textbox.Text = "Pump On";
            pump_on_radioButton.Checked = true;
            pump_off_radioButton.Checked = false;
        }

        private void pump_off_button_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("p");
            direction_textbox.Text = "Pump Off";
            pump_on_radioButton.Checked = false;
            pump_off_radioButton.Checked = true;
        }

        private void about_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By-\nDebasish Dev\nRUET, EEE'12\nblackviper065@gmail.com");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(automatic_checker.Checked == true)
            {
                String str;
                str = "A";
                serialPort1.WriteLine(str);
                automatic_status.Text = "Automatic Mode Activate";
                forward_button.Enabled = false;
                backward_button.Enabled = false;
                left_button.Enabled = false;
                right_button.Enabled = false;
                stop_button.Enabled = false;
                pump_on_button.Enabled = false;
                pump_off_button.Enabled = false;

                   
            }
            else
            {
                String str;
                str = "a";
                serialPort1.WriteLine(str);
                automatic_status.Text = "Automatic Mode Deactivate";
                forward_button.Enabled = true;
                backward_button.Enabled = true;
                left_button.Enabled = true;
                right_button.Enabled = true;
                stop_button.Enabled = true;
                pump_on_button.Enabled = true;
                pump_off_button.Enabled = true;
            }
        }

        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            RxString = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(received_data_textbox_TextChanged));
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    connect_button.Text = "Disconnect";
                    port_list.Enabled = false;
                    baud_rate.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Check your Port Status");
                }
            }
            else
            {
                connect_button.Text = "Connect";
                port_list.Enabled = true;
                baud_rate.Enabled = true;
                serialPort1.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pump_on_radioButton.Checked = false;
            pump_off_radioButton.Checked = false;
            received_data_textbox.ReadOnly = true;
            direction_textbox.ReadOnly = true;
        }

        private void port_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = port_list.Text;
        }

        private void baud_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = int.Parse(baud_rate.Text);
        }
        

        private void received_data_textbox_TextChanged(object sender, EventArgs e)
        {
            received_data_textbox.AppendText(RxString);
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            serialPort1.WriteLine("S");
            direction_textbox.Text = "stop";
        }

        
    }
}
