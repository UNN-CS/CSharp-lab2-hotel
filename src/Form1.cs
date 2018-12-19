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
        double cost = 0, sum = 0, sum1 = 0, sum2 = 0, sum3 = 0;
        double comboPrice = 0;
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("D:\\C#Labs\\Lab2\\Lab2\\Price.json") == true)
            {
                string stringList = File.ReadAllText("D:\\C#Labs\\Lab2\\Lab2\\Price.json");
                nomer nom = JsonConvert.DeserializeObject<Appartment>(File.ReadAllText("D:\\C#Labs\\Lab2\\Lab2\\Price.json"));
                foreach (var pop in nom.Appartments)
                {
                    comboBox1.Items.Add(pop.Type);
                };
            }
            if (File.Exists("D:\\C#Labslab2\\Lab2\\Lab2\\Price.json") == true)
            {
                string stringList = File.ReadAllText("D:\\C#Labs\\Lab2\\Lab2\\Price.json");
                uslug dop = JsonConvert.DeserializeObject<Extra>(File.ReadAllText("D:\\C#Labs\\Lab2\\Lab2\\Price.json"));

                foreach (var dopu in dop.Extras)
                {
                    if (dopu.Type == "WiFi")
                    {
                        sum1 = Convert.ToDouble(dopu.Price);
                    }
                    if ((dopu.Type == "Cleaning"))
                    {
                        sum2 = Convert.ToDouble(dopu.Price);
                    }
                    if ((dopu.Type == "Breakfast"))
                    {
                        sum = Convert.ToDouble(dopu.Price);

                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string comboName;
            try
            {
                comboName = comboBox1.SelectedItem.ToString();

                if (File.Exists("D:\\C#Labs\\Lab2\\Lab2\\Price.json") == true)
                {
                    string stringList = File.ReadAllText("D:\\C#Labs\\Lab2\\Lab2\\Price.json");
                    nomer n = JsonConvert.DeserializeObject<Appartment>(File.ReadAllText("D:\\C#Labs\\Lab2\\Lab2\\Price.json"));
                    foreach (var p in n.Appartments)
                    {
                        if (p.Type == comboName)
                        {
                            comboPrice = Convert.ToDouble(p.Price);
                        }
                    }
                }
                DateTime dt1 = dateTimePicker1.Value;
                DateTime dt2 = dateTimePicker2.Value;
                TimeSpan x = dt2 - dt1;
                int day = ((int)x.TotalDays);
                MessageBox.Show(day.ToString());
                int hours = ((int)x.TotalHours);
                if (hours != 0)
                {
                    day++;
                }
                if (day == 0)
                {
                    day++;
                }
                if (checkBox1.Checked == true)
                {
                    sum1 = sum1 + (100 * day);
                }
                if (checkBox3.Checked == true)
                {
                    sum2 = sum2 + (200 * day);
                }
                if (checkBox2.Checked == true)
                {
                    sum3 = sum3 + (300 * day);
                }
                sum = (comboPrice * day) + sum1 + sum2 + sum3;
                textBox1.Text = sum.ToString();
            }
            catch
            {
                MessageBox.Show("  ");

            }
        }
    }
}