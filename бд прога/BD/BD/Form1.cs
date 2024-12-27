using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class Form1 : Form
    {
        #region Поля
        public string[] Msik = { "Сталь-сталь", "Сталь-чугун", "Сталь-бронза", "Чугун-чугун", "Текстолит-сталь", "ДСП-сталь", "Полиамилид-сталь" };
        public string[] Mim = { "Сталь 45", "Сталь 50Г", "Сталь 40Х", "Сталь 40ХН", "Сталь 20ХФ", "Сталь 12ХН3А", "Сталь 18ХГТ",
            "Сталь 20Х", "Сталь 30ХГТ","Сталь 40ХФА","Чугун СЧ 32-52","Высокопрочный чугун ВЧ 30-2","Стальное литьё 40ХЛ-40ГЛ"};
        public string[] Term = { "Улучшение", "ТВЧ сквозная с охватом дна впадины", "ТВЧ поверхностная с охватом дна впадины" };
        public string[] Z1 = { "14", "16", "17", "18", "19", "20", "21", "22", "24", "25", "28", "30", "32", "37", "40", "45", "50", "60", "80", "100", "150" };
        public string[] X = { "0.7", "0.5", "0.3" };
        public static double Kd = 0;
        public static double Sigma1FP = 0;
        public static double NF0 = 0;
        public static double Sigma1HP = 0;
        public static double NH0 = 0;
        public static double HB = 200;
        public static double KHB = 0;
        public static double KFB = 0;
        public static double Psibd = 0.2;
        public static double z1 = 14;
        public static double x = 0.7;
        public static double Y1f = 0;
        public static double Km = 14;
        public static double T1 = 250;
        public static double u = 2;
        public static double mf = 6;
        public static double Beta = 15;
        public double tch = 200;
        public double n = 4000;
        public static double NHE = 0;
        public static double NFE = 0;
        public static double KHL = 0;
        public static double KFL = 0;
        public static double sigmaHP = 0;
        public static double sigmaFP = 0;
        public static double Dw1 = 0;
        public static double m = 0;
        public static double mmin = 0;
        public bool init = false;
        #endregion
        

        public Form1()
        { 
            InitializeComponent();
           
            label3.Text = "<=" + imax.ToString();
        }
        double Eu=140;
        double D1 = 180;
        double O0 = 24;
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            if(radioButton2.Checked)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                Eu = 0.5 * 1000;
                D1 = 36;
                
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Items.AddRange(new string[] { "40", "50", "75", "100" });
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Items.AddRange(new string[] { "16", "18","20","24" });
                D1 = 180;
                Eu = 140;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox3.Enabled = false;
                groupBox3.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        int imax = 50;

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
                imax = 5;
            else
                imax = 50;
            label3.Text = "<=" + imax.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            O0 = Int32.Parse(comboBox1.SelectedItem.ToString());
        }
        double a=1, w=1;
        List<bool> answ = new System.Collections.Generic.List<bool>();

        private void button2_Click(object sender, EventArgs e)
        {
            if(answ.Count()!=0)
                answ.RemoveAt(answ.Count() - 1);
            int z = 1;
            label34.Text = "Массив ответов: ";
            foreach (bool it in answ)
            {
                label34.Text += "(" + z.ToString() + ") ";
                if (it)
                    label34.Text += "Достоверно, ";
                else
                    label34.Text += "Не достоверно, ";
                z++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(textBox1.Text)>imax)
            {
                MessageBox.Show("Частота пробега ремня указана неправильно");
                return;
            }
            if(comboBox1.Text.ToString()=="")
            {
                MessageBox.Show("Выберете начальное напряжение О0");
                return;
            }
            double d,D1,N,n1,n2,i;
            label2.Text = "i=" + textBox1.Text;
            i = Double.Parse(textBox1.Text);
            label6.Text = "On= " + (7.5 * 1000 * 1000).ToString();
            label7.Text = "Nц0= " + 10000000.ToString();
            label8.Text = "Еи= " + Eu.ToString();
            label13.Text = "d= " + textBox2.Text.ToString();
            d = Double.Parse(textBox2.Text);
            if (radioButton1.Checked)
            {
                label12.Text = "D1= " + "180";
                D1 = 180;
            }
            else {
                label12.Text = "D1= " + "36";
                D1 = 36;
            }
            
            label11.Text = "O0= " + O0.ToString();
            label9.Text = "Ox= " + 25400.ToString();
            label19.Text = "ix= 5";
            label18.Text = "ex= 0.15";
            label17.Text = "N= " + textBox3.Text.ToString();
            N = Double.Parse(textBox3.Text);
            label14.Text = "n1= " + textBox4.Text.ToString();
            label23.Text = "n2= " + textBox5.Text.ToString();
            n1 = Double.Parse(textBox4.Text);
            n2 = Double.Parse(textBox5.Text);
            string s = comboBox1.SelectedItem.ToString();
            if (radioButton1.Checked)
            {
                
                if(s=="16")
                {
                    a=2.3;
                    w = 9;
                }
                if (s == "18")
                {
                    a = 2.5;
                    w = 10;
                }
                if (s == "20")
                {
                    a = 2.7;
                    w = 10;
                }
                if (s == "24")
                {
                    a = 3.05;
                    w = 13.5;
                }
            }
            else
            {
                if(radioButton5.Checked)
                {
                    if (s == "40")
                    {
                        a = 5.75;
                        w = 176;
                    }
                    if (s == "50")
                    {
                        a = 7;
                        w = 220;
                    }
                    if (s == "75")
                    {
                        a = 9.6;
                        w = 330;
                    }
                    if (s == "100")
                    {
                        a = 11.6;
                        w = 440;
                    }
                }
                else
                {
                    if (s == "40")
                    {
                        a = 6.55;
                        w = 124;
                    }
                    if (s == "50")
                    {
                        a = 8;
                        w = 156;
                    }
                    if (s == "75")
                    {
                        a = 11.4;
                        w = 233;
                    }
                    if (s == "100")
                    {
                        a = 14.3;
                        w = 311;
                    }
                }
            }
            label22.Text = "w= " + w.ToString();
            label21.Text = "a= " + a.ToString();


            ///
            double omax;
            double op;
            double ou;
            double F;
            double b;
            double A;
            double B;
            double Cu;
            double Cp;
            double tch;
            double tch0;

            F = 1000 * N/n1;
            ou = Eu * d / D1;
            b = F / d * (a - w * d / D1);
            op = O0 + F / 2 * b * d + ou;
            
            omax = op + ou;
            if (omax < 0)
                omax *= -1;
            tch0 = 2.46 * 100000000 / omax;
            Cu = 2 / Math.Pow((1 + ((op + ou / u) / omax)), 6);
            Cp = i / (15 / 5 * 3);
            tch = (tch0 / i) * Cu * Cp;

            A = Math.Pow(omax, 6) * 3600 * 2 * tch;

            B = Math.Pow(7500000, 6) * 1000000;

            label20.Text = "omax= "+omax.ToString();
            label33.Text = "tч= "+tch.ToString();
            label32.Text = "Ou= " + ou.ToString();
            label31.Text = "Op= " + op.ToString();
            label30.Text = "Cu= " + Cu.ToString();
            label29.Text = "Cp= " + Cp.ToString();
            label28.Text = "F= " + F.ToString();
            label27.Text = "b= " + b.ToString();
            label26.Text = "u= " + u.ToString();
            string answA, answB;
            answA = A.ToString().Substring(0, 9);
            answB = B.ToString().Substring(0, 9);
            label25.Text = "A= " + answA;
            label24.Text = "B= " + answB;
            double ansA, ansB;
            ansA = Double.Parse(answA);
            ansB = Double.Parse(answB);
            answ.Add(ansA > ansB);

            label34.Text = "Массив ответов: ";
            int z = 1;
            foreach(bool it in answ)
            {
                label34.Text += "(" + z.ToString() + ") ";
                if (it)
                    label34.Text += "Достоверно, ";
                else
                    label34.Text += "Не достоверно, ";
                z++;
            }



        }

        
    }
}
