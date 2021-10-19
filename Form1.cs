using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SerialPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmdClose.Enabled = false;

            // getting serial port names
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) 
            {
                txtPort.Items.Add(s);
            }
        }

        public System.IO.Ports.SerialPort sport;

        public void serialport_connect(String port, int baudrate , Parity parity, int databits, StopBits stopbits) 
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            //initializing and connecting to serial port
            sport = new System.IO.Ports.SerialPort(
            port, baudrate, parity, databits, stopbits);
            try
            {
                sport.Open();
                cmdClose.Enabled = true;
                cmdConnect.Enabled = false;
                txtReceive.AppendText("[" + dtn + "] " + "Connected\n");

                sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error"); }
        }

        // read serial port
        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e) 
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
                        
            txtReceive.AppendText( sport.ReadExisting()+ "\n");
            //"["+dtn+"] " +"Received: " +
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            String port = txtPort.Text;
            int baudrate = Convert.ToInt32(cmbbaudrate.Text);
            Parity parity = (Parity)Enum.Parse(typeof(Parity), cmbparity.Text);
            int databits = Convert.ToInt32(cmbdatabits.Text);
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), cmbstopbits.Text);
            
            serialport_connect(port, baudrate, parity, databits, stopbits);
            

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            
            String dtn = dt.ToShortTimeString();
            //string data = txtDatatoSend.Text;
            //sport.Write(data);
            int dimming = Convert.ToInt32(cmbdimming.Text);
            string data2;

            //setting dimming 10 to 100 by changing register values
            switch(dimming){
                case 10:
                    data2 = "c";          
                    sport.Write(data2);
                    break;
                case 20:
                    data2 = "d";
                    sport.Write(data2);
                    break;
                case 30:
                    data2 = "e";
                    sport.Write(data2);
                    break;
                case 40:
                    data2 = "f";
                    sport.Write(data2);
                    break;
                case 50:
                    data2 = "g";
                    sport.Write(data2);
                    break;
                case 60:
                    data2 = "h";
                    sport.Write(data2);
                    break;
                case 70:
                    data2 = "i";
                    sport.Write(data2);
                    break;
                case 80:
                    data2 = "j";
                    sport.Write(data2);
                    break;
                case 90:
                    data2 = "k";
                    sport.Write(data2);
                    break;
                case 100:
                    data2 = "l";
                    sport.Write(data2);
                    break;
            }
            
            
            //txtReceive.AppendText("[" + dtn + "] " + "Sent: " + dimming + "\n");
        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            if (sport.IsOpen) 
            {
                sport.Close();
                cmdClose.Enabled = false;
                cmdConnect.Enabled = true;
                
                txtReceive.AppendText("[" + dtn + "] " + "Disconnected\n");
            }
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbbaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbparity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDatatoSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // initialize the display                                            
        private void button2_Click(object sender, EventArgs e)
        {
            sport.Write("a");
            //DateTime dt = DateTime.Now;
            //String dtn = dt.ToShortTimeString();
            txtReceive.AppendText("Initialized" + "\n");

        }

        // scanning i2c devices
        private void button3_Click(object sender, EventArgs e)
        {
            sport.Write("s");
        }

        // read temperature sensor data 
        private void button4_Click(object sender, EventArgs e)
        {
            sport.Write("x");
            sport.ReadExisting();
        }
    }
}
