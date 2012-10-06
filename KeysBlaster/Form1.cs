using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeysBlaster
{
    public partial class Form1 : Form
    {
        String inputText = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            refreshTimer();
        }

        private void refreshTimer()
        {
            Decimal seconds = secondsToWait.Value;
            seconds = seconds <= 0 ? 1 : seconds;
            timer1.Interval = (int)seconds * 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshTimer();
            inputText = textBox1.Text;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String[] toSend=inputText.Split(' ');
            foreach (String item in toSend)
            {
               
                SendKeys.Send(item+" ");
            }
            timer1.Stop();
        }

    }
}
