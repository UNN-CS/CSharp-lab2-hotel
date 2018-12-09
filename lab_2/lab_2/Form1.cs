using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2
{
    public partial class Form1 : Form
    {
        int[] prices;
        public Form1()
        {
            InitializeComponent();
            prices = new int[4];
            StreamReader sr = new StreamReader("price.txt");

            ////Read the first line of text
            prices[0] = Convert.ToInt32(sr.ReadLine().Split(':')[1]);
            prices[1] = Convert.ToInt32(sr.ReadLine().Split(':')[1]);
            prices[2] = Convert.ToInt32(sr.ReadLine().Split(':')[1]);
            prices[3] = Convert.ToInt32(sr.ReadLine().Split(':')[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total_price = 0;
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            TimeSpan x = dt2 - dt1;
            tx1.Text = ((int)x.TotalDays + 1).ToString() + " дней ";  //дни
            int hours = ((int)x.TotalHours); //часы
            total_price += prices[0] * ((int)x.TotalDays + 1) * (comboBox1.SelectedIndex + 1);
            if (total_price == 0) return;
            if (checkBox1.Checked == true)
                total_price += prices[1] * ((int)x.TotalDays + 1);
            if (checkBox2.Checked == true)
                total_price += prices[2] * ((int)x.TotalDays + 1);
            if (checkBox3.Checked == true)
                total_price += prices[3] * ((int)x.TotalDays + 1);
            textBox1.Text = (total_price).ToString();
        }
    }
}
