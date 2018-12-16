using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;

namespace hotel_maiami
{
    public partial class MAIAMI_HOTEL : Form
    {
        double cena_wifi;
        double cena_uborka;
        double cena_minibar;
        double cena_seif;
        double Price;
        double Dopi;
        public MAIAMI_HOTEL()
        {
            InitializeComponent();
        }

        private void MAIAMI_HOTEL_Load(object sender, EventArgs e)
        {
            //считывание номеров и цен
            if (File.Exists("D:\\бэкап\\С#\\hotel-maiami\\PriceList.json") == true) //требуется полный путь!!!!
            {
                string stringList = File.ReadAllText("D:\\бэкап\\С#\\hotel-maiami\\PriceList.json");
                price_list PRICELIST = JsonConvert.DeserializeObject<price_list>(File.ReadAllText("D:\\бэкап\\С#\\hotel-maiami\\PriceList.json"));
                foreach (var price_kortegi in PRICELIST.Nomera)
                {
                    comboBox1.Items.Add(price_kortegi.name);
                };
            }
            else
            {
                MessageBox.Show("ОООШИБКА! Где файл с которого считывать????");
            }

            //-------------------------------------------------------------------------------------------------------------------

            //считывание дополнительных опций и их цен
            if (File.Exists("D:\\бэкап\\С#\\hotel-maiami\\DopiList.json") == true) //требуется полный путь!!!!
            {
                string stringList = File.ReadAllText("D:\\бэкап\\С#\\hotel-maiami\\DopiList.json");
                dopi_list DOPILIST = JsonConvert.DeserializeObject<dopi_list>(File.ReadAllText("D:\\бэкап\\С#\\hotel-maiami\\DopiList.json"));

                foreach (var dopi_kortegi in DOPILIST.Uslugi)
                {
                    if (dopi_kortegi.name == "wifi [200]")
                    {
                        cena_wifi = Convert.ToDouble(dopi_kortegi.price);
                        textBox4.Text = Convert.ToString(dopi_kortegi.name);
                    }
                    else if ((dopi_kortegi.name == "uborka [500]"))
                    {
                        cena_uborka = Convert.ToDouble(dopi_kortegi.price);
                        textBox5.Text = Convert.ToString(dopi_kortegi.name);
                    }
                    else if ((dopi_kortegi.name == "minibar [3000]"))
                    {
                        cena_minibar = Convert.ToDouble(dopi_kortegi.price);
                        textBox6.Text = Convert.ToString(dopi_kortegi.name);
                    }
                    else if ((dopi_kortegi.name == "seif [700]"))
                    {
                        cena_seif = Convert.ToDouble(dopi_kortegi.price);
                        textBox7.Text = Convert.ToString(dopi_kortegi.name);
                    }
                }
            }
            else
            {
                MessageBox.Show("ОООШИБКА! Где файл с которого считывать????");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comboName;
            try
            {
                comboName = comboBox1.SelectedItem.ToString();  //ситывание name из комбобокса

                double comboPrice = 0;
                //поиск в numbers по name

                if (File.Exists("D:\\бэкап\\С#\\hotel-maiami\\PriceList.json") == true) //требуется полный путь!!!!
                {
                    string stringList = File.ReadAllText("D:\\бэкап\\С#\\hotel-maiami\\PriceList.json");
                    price_list PRICELIST = JsonConvert.DeserializeObject<price_list>(File.ReadAllText("D:\\бэкап\\С#\\hotel-maiami\\PriceList.json"));
                    foreach (var price_kortegi in PRICELIST.Nomera)
                    {
                        if (price_kortegi.name == comboName)
                        {
                            comboPrice = Convert.ToDouble(price_kortegi.price);
                        }
                    }
                }

                else
                {
                    MessageBox.Show("ОООШИБКА! Где файл с которого считывать????");
                }

                DateTime dateIn = dateTimePicker1.Value;
                DateTime dateOut = dateTimePicker2.Value;
                TimeSpan x = dateOut - dateIn; // высчитываем кол-во дней в переменную х
                if ((int)x.TotalDays < 0)
                {
                    MessageBox.Show("Марти Макфлай, чтоли? Как ты можешь вьехать в один день, а выехать раньше, чем вьехал?????");
                }

                Dopi = 0;
                if (checkBox1.Checked == true)
                {
                    Dopi = Dopi + cena_wifi;
                }
                if (checkBox2.Checked == true)
                {
                    Dopi = Dopi + cena_uborka;
                }
                if (checkBox3.Checked == true)
                {
                    Dopi = Dopi + cena_minibar;
                }
                if (checkBox4.Checked == true)
                {
                    Dopi = Dopi + cena_seif;
                }


                Price = 0;

                if ((int)x.TotalDays == 0)
                {
                    Price = Dopi + comboPrice;
                }
                else
                { Price = ((int)x.TotalDays) * (Dopi + comboPrice); }
            
                textBox8.Text = Convert.ToString(Price);
            }
            catch
            {
                MessageBox.Show("ОООШИБКА! НЕ выбрал тип комнаты");

            }

        }
    }
}

// вопрос 1: если ничего не выбрать(тип номера), то возвращает нас в код на  string comboName = comboBox1.SelectedItem.ToString();
// каждое нажатие на чекбокс считает как прибавку к сумме (ошибка в логике?), т.е. если ошиблись и убрали галочку, то уже из суммы не убрать