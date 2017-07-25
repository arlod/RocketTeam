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
using System.Timers;

namespace ControllerTest
{
    public partial class Form1 : Form
    {
        private static SerialPort serialPort1 = new SerialPort("COM3", 9600);
        private System.Timers.Timer aTimer;


        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            serialPort1.Open();
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
            //serialPort1.DataReceived += serialPort1_DataReceived;
        }
        //private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        //{
        //    string line = serialPort1.ReadLine();
        //    Console.WriteLine(line);
        //    //textBox1.Text = line;
        //    //this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
        //}

        //private delegate void LineReceivedEvent(string line);
        //private void LineReceived(string line)
        //{
        //    //What to do with the received line here
        //    textBox1.Text = line;
        //    Console.WriteLine(line);

        //    //progressBar1.Value = int.Parse(line);
        //}
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            
            if (serialPort1.BytesToRead > 0)
            {
                string line = serialPort1.ReadLine();
                Console.WriteLine(line);
            }
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
