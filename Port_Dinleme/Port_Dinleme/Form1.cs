using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace Port_Dinleme
{
    public partial class Form1 : Form
    {
        private string veri;
        int sayac;
        public Form1()
        {
            InitializeComponent();
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            veri = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
        }

        private void DisplayText(object sender,EventArgs e)
        {
            textBox1.AppendText(veri);
            timer1.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = "COM1";
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Handshake = Handshake.None;

                serialPort1.Open();
                serialPort1.ReadTimeout = 500;


                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac = sayac + 1;
            if (sayac==20)
            {
                sayac = 0;
                textBox1.Text="";
                timer1.Stop();
            }
        }
    }
}
