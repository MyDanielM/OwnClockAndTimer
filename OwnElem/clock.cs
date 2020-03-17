using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwnElem
{
    public partial class clock : UserControl
    {
        int HOUR, MIN, SEC;
        public clock()
        {
            InitializeComponent();
            часыToolStripMenuItem.Checked = true;
            таймерToolStripMenuItem.Checked = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            label2.Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string hour = time.Hour.ToString();
            string min = time.Minute.ToString();
            string sec = time.Second.ToString();
            if (int.Parse(min) < 10)
                min = "0" + min;
            if (int.Parse(sec) < 10)
                sec = "0" + sec;
            label1.Text = hour + ":" + min + ":" + sec;
        }

        private void часыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            label2.Visible = false;
            label1.Visible = true;
        }

        private void таймерToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            label2.Visible = true;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;

            if (textBox1.Text == "")
                HOUR = 0;
            else
                HOUR = int.Parse(textBox1.Text);

            if (textBox2.Text == "")
                MIN = 0;
            else
                MIN = int.Parse(textBox2.Text);

            if (textBox3.Text == "")
                SEC = 0;
            else
                SEC = int.Parse(textBox3.Text);
            timer2.Start();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
                
            string hour, min, sec;
            hour = HOUR.ToString();
            min = MIN.ToString();
            sec = SEC.ToString();


            if (hour.Length < 2 && int.Parse(hour) < 10)
                hour = "0" + hour;
            if (min.Length<2 &&int.Parse(min) < 10)
                min = "0" + min;
            if (sec.Length<2 && int.Parse(sec) < 10)
                sec = "0" + sec;
            

            label2.Text = hour + ":" + min + ":" + sec;

            if (SEC != 0)
                SEC--;
            else if (MIN != 0)
            {
                MIN--;
                SEC = 59;
            }
            else
            {
                HOUR--;
                MIN = 59;
            }
            if (HOUR == 0 && MIN == 0 && SEC == 0)
            {
                label2.Text = "Время истекло!";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                timer2.Stop();
            }
        }
    }
}
