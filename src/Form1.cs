﻿using System;
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
            if (File.Exists("Resources/help.json") == true) 
            {
                string stringList = File.ReadAllText("Resources/help.json");
                nomer nom = JsonConvert.DeserializeObject<nomer>(File.ReadAllText("Resources/help.json"));
                foreach (var pop in nom.nomera)
                {
                    comboBox1.Items.Add(pop.Type);
                };
            }
            if (File.Exists("Resources/help.json") == true) 
            {
                string stringList = File.ReadAllText("Resources/help.json");
                uslug dop = JsonConvert.DeserializeObject<uslug>(File.ReadAllText("Resources/help.json"));

                foreach (var options in dop.uslugi)
                {
                    if (options.Type == "Breakfast")
                    {
                        sum1 = Convert.ToDouble(options.Price);                
                    }
                    if ((options.Type == "Lunch"))
                    {
                        sum2 = Convert.ToDouble(options.Price);
                    }
                    if ((options.Type == "Dinner"))
                    {
                       sum = Convert.ToDouble(options.Price);
                        
                    }          
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string name;
            try
            {
             name = comboBox1.SelectedItem.ToString();  

                if (File.Exists("Resources/help.json") == true) 
                {
                    string stringList = File.ReadAllText("Resources/help.json");
                    nomer n = JsonConvert.DeserializeObject<nomer>(File.ReadAllText("Resources/help.json"));
                    foreach (var p in n.nomera)
                    {
                        if (p.Type == name)
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
                    sum1 = sum1 + (400 * day);
                }
                if (checkBox3.Checked == true)
                {
                    sum2 = sum2 + (300 * day);
                }
                if (checkBox2.Checked == true)
                {
                    sum3 = sum3 + (500 * day);
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
