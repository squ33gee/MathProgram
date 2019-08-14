using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace MM
{
    public partial class Math_Malceva : Form
    {
        public Math_Malceva()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;

                textA.Enabled = false;
                textB.Enabled = false;
                textEps.Enabled = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;

                checkBox2.Enabled = false;

                double a = 0, b = 0;
                double c = 0, f = 0;
                double eps = 0, t = 1;
                int j = 0;

                a = Convert.ToDouble(textA.Text);
                b = Convert.ToDouble(textB.Text);
                eps = Convert.ToDouble(textEps.Text);

                while (eps <= t)
                {
                    progressBar1.Value++;
                    Thread.Sleep(50);

                    c = (a + b) / 2;
                    f = 5 * Math.Sin(c) - c;
                    t = (b - a) / 2;
                    j++;

                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(Convert.ToString(j)); //первый
                    lvi.SubItems.Add(Convert.ToString(a)); //второй
                    lvi.SubItems.Add(Convert.ToString(b)); //третий
                    lvi.SubItems.Add(Convert.ToString(t)); //четвертый
                    listView1.Items.Add(lvi);

                    if (f > 0)
                    {
                        a = c;
                    }
                    else
                    {
                        b = c;
                    }
                }

                if(checkBox2.Checked == true)
                {
                    listView1.Items.RemoveAt(j-1);
                }          

                progressBar1.Value = 100;

                textA.Enabled = true;
                textB.Enabled = true;
                textEps.Enabled = true;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                checkBox2.Enabled = true;
            }
            catch (FormatException)
            {
                textA.Enabled = true;
                textB.Enabled = true;
                textEps.Enabled = true;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                checkBox2.Enabled = true;

                progressBar1.Value = 0;

                MessageBox.Show("Сработала защита - FormatException, неправильно введены значения!");
            }
            catch (OverflowException)
            {
                textA.Enabled = true;
                textB.Enabled = true;
                textEps.Enabled = true;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                checkBox2.Enabled = true;

                progressBar1.Value = 0;

                MessageBox.Show("Сработала защита - OverflowException, переполнение!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if(checkBox1.Checked == true)
            {
                textA.Text = "";
                textB.Text = "";
                textEps.Text = "";
            }

            progressBar1.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
