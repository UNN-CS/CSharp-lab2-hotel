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

namespace lab2
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
            if (File.Exists("C:\\Users\\lab2\\help.json") == true) 
            {
                string stringList = File.ReadAllText("C:\\Users\\lab2\\help.json");
                nomer nom = JsonConvert.DeserializeObject<nomer>(File.ReadAllText("C:\\Users\\lab2\\help.json"));
                foreach (var pop in nom.nomera)
                {
                    comboBox1.Items.Add(pop.Type);
                };
            }
            if (File.Exists("C:\\Users\\lab2\\help.json") == true) 
            {
                string stringList = File.ReadAllText("C:\\Users\\lab2\\help.json");
                uslug dop = JsonConvert.DeserializeObject<uslug>(File.ReadAllText("C:\\Users\\lab2\\help.json"));

                foreach (var dopu in dop.uslugi)
                {
                    if (dopu.Type == "wi-fi")
                    {
                        sum1 = Convert.ToDouble(dopu.Price);                
                    }
                    if ((dopu.Type == "Beer"))
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

                if (File.Exists("C:\\Users\\lab2\\help.json") == true) 
                {
                    string stringList = File.ReadAllText("C:\\Users\\lab2\\help.json");
                    nomer n = JsonConvert.DeserializeObject<nomer>(File.ReadAllText("C:\\Users\\lab2\\help.json"));
                    foreach (var p in n.nomera)
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
                    sum1 = sum1 + (150 * day);
                }
                if (checkBox3.Checked == true)
                {
                    sum2 = sum2 + (350 * day);
                }
                if (checkBox2.Checked == true)
                {
                    sum3 = sum3 + (200 * day);
                }
                sum = (comboPrice * day) + sum1 + sum2 + sum3;
                textBox1.Text = sum.ToString();
            }
            catch
            {
                MessageBox.Show("  ");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



            }
    }
}