using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _5_19_XuHaoRan1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(Test);
            th.IsBackground = true;
            th.Start();
        }
        void Test()
        {
            for (int i = 0; i < 10000; i++)
            {
                textBox1.Text = i.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th != null)
            {
                th.Abort();
            }
        }
    }
}
