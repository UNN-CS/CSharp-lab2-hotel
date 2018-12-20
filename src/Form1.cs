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

namespace Отель
{
    public partial class Form1 : Form
    {
        double price_wifi;
        double price_SPA;
        double price_washing;
        double Price;
        double Optionally;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json2.json") == true)
            {
                string stringList = File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json2.json");
                Class_PriceList PRICELIST = JsonConvert.DeserializeObject<Class_PriceList>(File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json2.json"));
                foreach (var PriceTuples in PRICELIST.Rooms)
                {
                    comboBox1.Items.Add(PriceTuples.name);
                };
            }
            if (File.Exists("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json1.json") == true)
            {
                string stringList = File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json1.json");
                OptionallyList OPTILIST = JsonConvert.DeserializeObject<OptionallyList>(File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json1.json"));

                foreach (var OptionallyTuples in OPTILIST.Service)
                {
                    if (OptionallyTuples.name == "Wi-Fi")
                    {
                        price_wifi = Convert.ToDouble(OptionallyTuples.price);
                    }
                    else if ((OptionallyTuples.name == "SPA"))
                    {
                        price_SPA = Convert.ToDouble(OptionallyTuples.price);
                    }
                    else if ((OptionallyTuples.name == "Washing"))
                    {
                        price_washing = Convert.ToDouble(OptionallyTuples.price);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comboName;
            try
            {
                comboName = comboBox1.SelectedItem.ToString();

                double comboPrice = 0;

                if (File.Exists("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json2.json") == true) 
                {
                    string stringList = File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json2.json");
                    Class_PriceList PRICELIST = JsonConvert.DeserializeObject<Class_PriceList>(File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\Отель\\Отель\\json2.json"));
                    foreach (var PriceTuples in PRICELIST.Rooms)
                    {
                        if (PriceTuples.name == comboName)
                        {
                            comboPrice = Convert.ToDouble(PriceTuples.price);
                        }
                    }
                }

                DateTime dateIn = dateTimePicker1.Value;
                DateTime dateOut = dateTimePicker2.Value;
                TimeSpan x = dateOut - dateIn; 
            
                Optionally = 0;
                if (checkBox1.Checked == true)
                {
                    Optionally = Optionally + price_wifi;
                }
                if (checkBox4.Checked == true)
                {
                    Optionally=Optionally+price_SPA;
                }
                if (checkBox5.Checked == true)
                {
                    Optionally=Optionally+price_washing;
                }
                Price = 0;

                if ((int)x.TotalDays == 0)
                {
                    Price = Optionally + comboPrice;
                }
                else
                { Price = ((int)x.TotalDays) * (Optionally + comboPrice); }

                textBox1.Text = Convert.ToString(Price);
            }
            catch
            {
                MessageBox.Show("Возникла проблема");
            }
        }
    
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
