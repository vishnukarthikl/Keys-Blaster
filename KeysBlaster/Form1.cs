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
        int indexToSend = 0;
        String inputText = "";
        String[] toSend;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshTimer();
        }

        private void refreshTimer()
        {
            int seconds = (int)secondsToWait.Value;
            seconds = seconds <= 0 ? 1 : seconds;
            timer1.Interval = seconds * 1000;
        }

        private void refreshWpm()
        {
            int wordsPerMinute = (int)wpm.Value;
            wordsPerMinute = wordsPerMinute <= 0 ? 60 : wordsPerMinute;
            timer2.Interval = (int)((60.0 / wordsPerMinute) * 1000);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            refreshTimer();
            refreshWpm();
            inputText = textBox1.Text;
            toSend = inputText.Split(' ');
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (indexToSend == toSend.Length)
            {
                timer2.Stop();
                indexToSend = 0;
            }
            else
                SendKeys.Send(toSend[indexToSend++] + " ");
        }

    }
}
