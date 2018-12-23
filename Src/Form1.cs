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
        List<CheckBox> servlist = new List<CheckBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            TimeSpan x = dt2 - dt1;
            days = (int)Math.Ceiling(x.TotalDays);
            if (days < 0)
            {
                textBox3.Text = "Дата указана неверно!";
                textBox2.Text = "Дата указана неверно!";
                days = 0;
                return;
            }
            if (days == 0)
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
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            TimeSpan x = dt2 - dt1;
            days = (int)x.TotalDays;
            if (days < 0)
            {
                textBox3.Text = "Дата указана неверно!";
                textBox2.Text = "Дата указана неверно!";
                return;
            }
            if (days == 0)
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

        private void Form1_Load(object sender, EventArgs e)
        {

            days = 1;
            textBox3.Text = "1";
            textBox2.Text = "24";
            var n = JsonConvert.DeserializeObject<InfoNumbers>(File.ReadAllText("C:\\Users\\Ivan\\source\\repos\\Lab2\\Lab2\\In.json"));
            Numbers buf1;
            for (int i = 0; n.numbers[i] != null; i++)
            {
                buf1 = n.numbers[i];
                comboBox1.Items.Add(buf1.Type);
            }
            var ns = JsonConvert.DeserializeObject<InfoServices>(File.ReadAllText("C:\\Users\\Ivan\\source\\repos\\Lab2\\Lab2\\In.json"));
            Numbers buf2;
            for (int i = 0; ns.services[i] != null; i++)
            {
                buf2 = ns.services[i];
            }
            servlist.Add(checkBox1);
            servlist.Add(checkBox2);
            servlist.Add(checkBox3);
            servlist.Add(checkBox4);
            servlist.Add(checkBox5);
            servlist.Add(checkBox6);
            servlist.Add(checkBox7);
            for (int i = 0; i < servlist.Count(); i++)
            {
                buf2 = ns.services[i];
                servlist[i].Text = buf2.Type;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (days == 0)
            {
                textBox1.Text = "Дата указана неверно!";
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                textBox1.Text = "Выберите номер!";
                return;
            }
            int fullprice = 0;
            var n = JsonConvert.DeserializeObject<InfoNumbers>(File.ReadAllText("C:\\Users\\Ivan\\source\\repos\\Lab2\\Lab2\\In.json"));
            Numbers ex = n.numbers[comboBox1.SelectedIndex];
            fullprice = ex.Price * days;
            var ns = JsonConvert.DeserializeObject<InfoServices>(File.ReadAllText("C:\\Users\\Ivan\\source\\repos\\Lab2\\Lab2\\In.json"));
            for (int i = 0; i < servlist.Count(); i++)
            {
                if (servlist[i].Checked)
                {
                    fullprice = fullprice + (ns.services[i].Price * days);
                }
            }
            textBox1.Text = Convert.ToString(fullprice) + "₽";
        }
    }
    public class InfoNumbers
    {
        public Numbers[] numbers { get; set; }

    }

    public class InfoServices
    {
        public Numbers[] services { get; set; }
    }

    public class Numbers
    {
        public string Type { get; set; }
        public int Price { get; set; }
    }
}