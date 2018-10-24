using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public static int days;
        public static int pricenumber;
        List<CheckBox> tb = new List<CheckBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = dTPFirst.Value;
            DateTime dt2 = dTPLast.Value;
            TimeSpan x = dt2 - dt1;
            days = (int)Math.Ceiling(x.TotalDays);
            if (days < 0)
            {
                textBox3.Text = "Дата указана неверно!";
                textBox2.Text = "Дата указана неверно!";
                days = 0;
                return;
            }
            else if (days == 0)
            {
                textBox3.Text = (days + 1).ToString();  //дни
                textBox2.Text = ((int)x.TotalHours + 1).ToString(); //часы
                days = (int)x.TotalDays + 1;
            }
            else
            {
                textBox3.Text = (days).ToString();  //дни
                textBox2.Text = ((int)x.TotalHours).ToString(); //часы
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = dTPFirst.Value;
            DateTime dt2 = dTPLast.Value;
            TimeSpan x = dt2 - dt1;
            days = (int)x.TotalDays;
            if (days < 0)
            {
                textBox3.Text = "Дата указана неверно!";
                textBox2.Text = "Дата указана неверно!";
                return;
            }
            else if (days == 0)
            {
                textBox3.Text = (days + 1).ToString();  //дни
                textBox2.Text = ((int)x.TotalHours + 1).ToString(); //часы
                days = (int)x.TotalDays + 1;
            }
            else
            {
                textBox3.Text = (days).ToString();  //дни
                textBox2.Text = ((int)x.TotalHours).ToString(); //часы
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            days = 1;
            textBox3.Text = "1";
            textBox2.Text = "24";
            var n = JsonConvert.DeserializeObject<InfoNumbers>(File.ReadAllText("C:\\Programs\\CSharp\\Lab2\\Lab2\\Numbers.json"));
            Cnumber ex;
            for (int i = 0; n.numbers[i] != null; i++)
            {
                ex = n.numbers[i];
                comboBox1.Items.Add(ex.Type);
            }
            var ns = JsonConvert.DeserializeObject<InfoServices>(File.ReadAllText("C:\\Programs\\CSharp\\Lab2\\Lab2\\Numbers.json"));
            Cnumber ex2;
            for (int i = 0; ns.services[i] != null; i++)
            {
                ex2 = ns.services[i];
            }

            
            tb.Add(checkBox1);
            tb.Add(checkBox2);
            tb.Add(checkBox3);
            tb.Add(checkBox4);
            tb.Add(checkBox5);
            tb.Add(checkBox6);
            for(int i = 0; i < tb.Count(); i++)
            {
                ex2 = ns.services[i];
                tb[i].Text = ex2.Type;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(days == 0) { textBox1.Text = "Дата указана неверно!"; return; }
            if(comboBox1.SelectedIndex == -1) { textBox1.Text = "Выберите номер!"; return; };

            int fullprice = 0;
            var n = JsonConvert.DeserializeObject<InfoNumbers>(File.ReadAllText("C:\\Programs\\CSharp\\Lab2\\Lab2\\Numbers.json"));
            Cnumber ex = n.numbers[comboBox1.SelectedIndex];
            fullprice = fullprice + (ex.Price * days);
            var ns = JsonConvert.DeserializeObject<InfoServices>(File.ReadAllText("C:\\Programs\\CSharp\\Lab2\\Lab2\\Numbers.json"));
            for(int i = 0; i < tb.Count(); i++)
            {
                if (tb[i].Checked){ fullprice = fullprice + (ns.services[i].Price * days); }
            }
            textBox1.Text = Convert.ToString(fullprice) + " rub";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
