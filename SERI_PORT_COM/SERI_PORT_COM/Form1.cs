using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace SERI_PORT_COM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bilgi = textBox1.Text;
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = "COM1";
                serialPort1.BaudRate = 9600;
                serialPort1.StopBits = StopBits.One;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.Handshake = Handshake.None;
                serialPort1.Open();
                serialPort1.WriteLine(bilgi);
                serialPort1.Close();
            }
        }
    }
}
