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

namespace Hotel
{
    public partial class Form1 : Form
    {
        double price_dinner;
        double price_wifi;
        double price_alcohol;
        double Price;
        double Optionally;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json2.json") == true)
            {
                string stringList = File.ReadAllText("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json2.json");
                Class_PriceList PRICELIST = JsonConvert.DeserializeObject<Class_PriceList>(File.ReadAllText("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json2.json"));
                foreach (var PriceTuples in PRICELIST.Rooms)
                {
                    comboBox1.Items.Add(PriceTuples.name);
                };
            }
            if (File.Exists("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json1.json") == true)
            {
                string stringList = File.ReadAllText("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json1.json");
                OptionallyList OPTILIST = JsonConvert.DeserializeObject<OptionallyList>(File.ReadAllText("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json1.json"));
                    foreach (var OptionallyTuples in OPTILIST.Service)
                {
                    if (OptionallyTuples.name == "Dinner")
                    {
                        price_dinner = Convert.ToDouble(OptionallyTuples.price);
                    }
                    else if ((OptionallyTuples.name == "Wi-fi"))
                    {
                        price_wifi = Convert.ToDouble(OptionallyTuples.price);
                    }
                    else if ((OptionallyTuples.name == "Alcohol"))
                    {
                        price_alcohol = Convert.ToDouble(OptionallyTuples.price);
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comboName;
            try
            {
                comboName = comboBox1.SelectedItem.ToString();

                double comboPrice = 0;

                if (File.Exists("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json2.json") == true)
                {
                    string stringList = File.ReadAllText("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json2.json");
                    Class_PriceList PRICELIST = JsonConvert.DeserializeObject<Class_PriceList>(File.ReadAllText("C:\\Users\\Lenovo\\Desktop\\5 семестр\\Вмп(сш)- Штанюк\\Hotel\\Hotel\\json2.json"));
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
                    Optionally = Optionally + price_dinner;
                }
                if (checkBox2.Checked == true)
                {
                    Optionally = Optionally + price_wifi;
                }
                if (checkBox3.Checked == true)
                {
                    Optionally = Optionally + price_alcohol;
                }
                Price = 0;

                if ((double)x.TotalDays == 0)
                {
                    Price = Optionally + comboPrice;
                }
                else
                { Price = ((double)x.TotalDays) * (Optionally + comboPrice); }

                textBox1.Text = Convert.ToString(Price);
            }
            catch
            {
                MessageBox.Show("Возникла проблема");
            }
        }
    
    }
}
