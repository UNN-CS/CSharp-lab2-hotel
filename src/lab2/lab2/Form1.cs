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
namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void Form_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.AddRange(new string[] { "Эконом","Стандарт","Королевский" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value, dt2 = dateTimePicker2.Value;
            TimeSpan x = dt2 - dt1;
            int n = (int)x.TotalDays,l=0;
            int[] ek = new int[5], sta = new int[5], kor = new int[5];
            n++;
            FileStream file = new FileStream(@"C:\\lab2\text.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                for (int j = 0; j < 5; j++)
                {
                    if (reader.EndOfStream)
                        break;
                    if (l == 0)
                    {
                        ek[j] = Convert.ToInt32(reader.ReadLine());
                    }
                    if (l == 1)
                    {
                        sta[j] = Convert.ToInt32(reader.ReadLine());
                    }
                    if (l == 2)
                    {
                        kor[j] = Convert.ToInt32(reader.ReadLine());
                    }
                }
                l++;
            }
            reader.Close();
            int sum=0,i=2;
                string st = comboBox1.Text;
            if (st == "Эконом")
                i = 1;
            if (st == "Стандарт")
                i = 2;
            if (st == "Королевский")
                i =3;
            switch (i)
            {
                case 1: sum = ek[0] * n;
                    if (checkBox1.TabStop)
                        sum += (ek[1] * n);
                    if (checkBox2.TabStop)
                        sum += (ek[2] * n);
                    if (checkBox3.TabStop)
                        sum += (ek[3] * n);
                    if (checkBox1.TabStop)
                        sum += (ek[4] * n);
                    break;
                case 2:   
                    sum = n * sta[0];
                    if (checkBox1.TabStop)
                        sum += (sta[1]* n);
                    if (checkBox2.TabStop)
                        sum += (sta[2] * n);
                    if (checkBox3.TabStop)
                        sum += (sta[3] * n);
                    if (checkBox1.TabStop)
                        sum += (sta[4] * n);
                    break;
                case 3:
                    
                    sum = n * kor[0];
                    if (checkBox1.TabStop)
                        sum += (kor[1] * n);
                    if (checkBox2.TabStop)
                        sum += (kor[2] * n);
                    if (checkBox3.TabStop)
                        sum += (kor[3] * n);
                    if (checkBox1.TabStop)
                        sum += (kor[4] * n);
                    break;
            }
            textBox1.Text = sum.ToString();

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
