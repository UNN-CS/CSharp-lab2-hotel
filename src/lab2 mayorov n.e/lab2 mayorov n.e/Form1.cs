
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace lab2_mayorov_n.e
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\user\Desktop\Numbers.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    comboBox1.Items.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            int cost;
            cost = 0;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    cost = 1000;
                    break;
                case 1:
                    cost = 1300;
                    break;
                case 2:
                    cost = 2000;
                    break;
                case 3:
                    cost = 4000;
                    break;
            }
            TimeSpan x = dt2 - dt1;
            int days = (int)x.TotalDays;
            int hours = (int)x.TotalDays;
            if (hours != 0)
            {
                days = days + 1;
            }
            if (days == 0)
            {
                days = days + 1;
            }
            if (days < 0)
            {
                days = 0;
            }
            int summa, cb1, cb2, cb3;
            cb1 = 0;
            cb2 = 0;
            cb3 = 0;
            if (checkBox1.Checked == true)
            {
                cb1 = days * 400;
            }
            if (checkBox2.Checked == true)
            {
                cb2 = days * 200;
            }
            if (checkBox3.Checked == true)
            {
                cb3 = 1500;
            }
            summa = days * cost + cb1 + cb2 + cb3;
            textBox1.Text = summa.ToString() + "₽";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
