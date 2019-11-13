using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Producer_Consumer
{
    public partial class Form1 : Form
    {
        private int item_to_produce, item_in_buffer, item_to_consume;
        public Form1()
        {
            InitializeComponent();
            item_in_buffer = 0;
            item_to_consume = 1;
        }

        private void actu()
        {
            label4.Text = Convert.ToString(item_in_buffer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            item_in_buffer = progressBar1.Value;
            item_to_consume = Convert.ToInt32(textBox2.Text);
            item_in_buffer -= item_to_consume;
            if (item_in_buffer >= 0 && item_in_buffer <= progressBar1.Value)
            {
                progressBar1.Value = item_in_buffer;
                textBox2.Text = "0";
            }
            else
            {
                MessageBox.Show("Can't consume more than what is in the buffer");
                item_in_buffer = 0;
            }
            actu();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (item_in_buffer <= 100)
            {
                Random tmp = new Random();
                item_to_produce= tmp.Next(1, 50);
                item_in_buffer += item_to_produce;
                if (item_in_buffer > 100)
                    item_in_buffer = 100;
                textBox1.Text = Convert.ToString(item_to_produce);
                progressBar1.Value = item_in_buffer;
                actu();



            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (item_in_buffer <= 100)
            {
              

                item_in_buffer -= item_to_consume;
                if (item_in_buffer < 0)
                    item_in_buffer = 0;
                progressBar1.Value = item_in_buffer;
                textBox2.Text = Convert.ToString(item_to_consume);
                actu();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            item_to_produce = System.Convert.ToInt32(textBox1.Text);
            if (item_to_produce >= 0 && item_to_produce <= 100)
            {
                item_in_buffer += (item_to_produce);
                if (item_in_buffer > 100)
                {
                    MessageBox.Show("Can't overload the buffer");
                    progressBar1.Value = 100;
                    item_in_buffer = 100;
                }
                else
                    progressBar1.Value = item_in_buffer;
            }
            else
                MessageBox.Show("Can't overload the buffer");
            textBox1.Text = "0";
            actu();
        }
       
    }
}
