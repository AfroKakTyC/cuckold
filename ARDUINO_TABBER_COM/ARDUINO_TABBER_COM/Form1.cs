using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARDUINO_TABBER_COM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Interval = 250;
            timer1.Start();
        }

        int tabbed = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int msg = serialPort1.ReadChar();
            if (msg == 48)
                tabbed = 0;
            richTextBox1.Text += msg.ToString();
            if (msg == 49 && tabbed == 0)
            {
                SendKeys.Send("%({TAB})");
                tabbed = 1;
            }
        }
    }
}
