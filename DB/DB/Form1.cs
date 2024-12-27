using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                double.TryParse(d.Text, out double d_) &&
                double.TryParse(b1.Text, out double b1_) &&
                double.TryParse(D1.Text, out double D1_) &&
                double.TryParse(ich.Text, out double ich_) &&
                double.TryParse(z.Text, out double z_) &&
                double.TryParse(ix.Text, out double ix_) &&
                double.TryParse(k.Text, out double k_) &&
                double.TryParse(ip.Text, out double ip_) &&
                double.TryParse(u.Text, out double u_) &&
                double.TryParse(n1.Text, out double n1_) &&
                double.TryParse(N.Text, out double N_))
            {
                double.TryParse(Oo.Text, out double Oo_);
                double On = 7.5;
                double NTch_0 = Math.Pow(10, 7);
                double B_ = (Math.Pow(On, 6) * NTch_0) / Math.Pow(10, 12);
                B.Text = B_.ToString();

                /*данные для параметра А*/
                double Omax_;
                double i;
                double Tch_;
                double Op_;
                double Ou_;
                double ro_;
                double F_;
                double v; 
                double Tch_0;
                double Cu_;
                double Cp_;
                double ex = 0.15;
                double OTch_;
                double Eu;
                double A_;
                double Ox;

                if (r.Text == "Тканевые прорезиненные конечной длины (ОСТ 38.05.98 76)")
                {
                    Random random = new Random();
                    double min = 1.25 * Math.Pow(10, 3);
                    double max = 1.50 * Math.Pow(10, 3);
                    ro_ = random.NextDouble() * (max - min) + min;
                    Eu = 140;
                }
                else if (r.Text == "Синтетические капроновые с пленочным покрытием (МРТУ 17-645-68) тип I")
                {
                    ro_ = 0.6 * Math.Pow(10, 3);
                    Eu = 0.5 * Math.Pow(10, 3);
                }
                else
                {
                    ro_ = 1.2 * Math.Pow(10, 3);
                    Eu = 0.5 * Math.Pow(10, 3);
                }

                v = 3.14 * D1_ * n1_ / (1000 * 60);
                F_ = Math.Pow(10, 3) * N_ / v;

                

                OTch_ = Eu*d_/D1_;
                Op_ = Oo_ + F_ / (2 * b1_ * d_) + OTch_;
                Ou_ = ro_ * Math.Pow(v, 2) / Math.Pow(10, 6);
                Omax_ = Op_ + Ou_;
                Ox = Op_ + Ou_;


                i = ix_ + ip_;

                double newSum = 0;
                for (int j = 0; j < k_; j++)
                {
                    newSum += Math.Pow((Ox / Omax_), 6) * (ix_ / ex);
                }
                Cp_ = i / newSum;

                Tch_0 = 2.46 * Math.Pow(10,8) / Math.Pow(Omax_, 6);

                if (Op_ / Ou_ > 0 && Op_ / Ou_ <= 0.75)
                {
                    if (u_ > 0 && u_ <= 1) 
                    {
                        Cu_ = 1.0;
                    }
                    else if (u_ > 1 && u_ <= 1.12)
                    {
                        Cu_ = 1.14;
                    }
                    else if (u_ > 1.12 && u_ <= 1.26)
                    {
                        Cu_ = 1.27;
                    }
                    else if (u_ > 1.26 && u_ <= 1.41)
                    {
                        Cu_ = 1.38;
                    }
                    else if (u_ > 1.41 && u_ <= 1.56)
                    {
                        Cu_ = 1.46;
                    }
                    else if (u_ > 1.56 && u_ <= 2)
                    {
                        Cu_ = 1.62;
                    }
                    else if (u_ > 2 && u_ <= 2.52)
                    {
                        Cu_ = 1.72;
                    }
                    else if (u_ > 2.52 && u_ <= 3)
                    {
                        Cu_ = 1.77;
                    }
                    else if (u_ > 3 && u_ <= 4)
                    {
                        Cu_ = 1.82;
                    }
                    else
                    {
                        Cu_ = 2 / (1 + Math.Pow((Op_ + Ou_ / u_) / Omax_, 6));
                    }
                }
                else if (Op_ / Ou_ > 0.75 && Op_ / Ou_ <= 1)
                {
                    if (u_ > 0 && u_ <= 1)
                    {
                        Cu_ = 1.0;
                    }
                    else if (u_ > 1 && u_ <= 1.12)
                    {
                        Cu_ = 1.18;
                    }
                    else if (u_ > 1.12 && u_ <= 1.26)
                    {
                        Cu_ = 1.32;
                    }
                    else if (u_ > 1.26 && u_ <= 1.41)
                    {
                        Cu_ = 1.44;
                    }
                    else if (u_ > 1.41 && u_ <= 1.56)
                    {
                        Cu_ = 1.55;
                    }
                    else if (u_ > 1.56 && u_ <= 2)
                    {
                        Cu_ = 1.7;
                    }
                    else if (u_ > 2 && u_ <= 2.52)
                    {
                        Cu_ = 1.8;
                    }
                    else if (u_ > 2.52 && u_ <= 3)
                    {
                        Cu_ = 1.84;
                    }
                    else if (u_ > 3 && u_ <= 4)
                    {
                        Cu_ = 1.88;
                    }
                    else
                    {
                        Cu_ = 2 / (1 + Math.Pow((Op_ + Ou_ / u_) / Omax_, 6));
                    }
                }

                else if (Op_ / Ou_ > 1 && Op_ / Ou_ <= 1.5)
                {
                    if (u_ > 0 && u_ <= 1)
                    {
                        Cu_ = 1.0;
                    }
                    else if (u_ > 1 && u_ <= 1.12)
                    {
                        Cu_ = 1.2;
                    }
                    else if (u_ > 1.12 && u_ <= 1.26)
                    {
                        Cu_ = 1.38;
                    }
                    else if (u_ > 1.26 && u_ <= 1.41)
                    {
                        Cu_ = 1.51;
                    }
                    else if (u_ > 1.41 && u_ <= 1.56)
                    {
                        Cu_ = 1.63;
                    }
                    else if (u_ > 1.56 && u_ <= 2)
                    {
                        Cu_ = 1.68;
                    }
                    else if (u_ > 2 && u_ <= 2.52)
                    {
                        Cu_ = 1.87;
                    }
                    else if (u_ > 2.52 && u_ <= 3)
                    {
                        Cu_ = 1.91;
                    }
                    else if (u_ > 3 && u_ <= 4)
                    {
                        Cu_ = 1.95;
                    }
                    else
                    {
                        Cu_ = 2 / (1 + Math.Pow((Op_ + Ou_ / u_) / Omax_, 6));
                    }
                }

                else 
                {
                    Cu_ = 2 / (1 + Math.Pow((Op_ + Ou_ / u_) / Omax_, 6));
                }

                Tch_ = Tch_0 / i * Cu_ * Cp_;
                A_ = (Math.Pow(Omax_, 6) * 3600 * i * z_ * Tch_) / Math.Pow(10, 11);

                A.Text = A_.ToString();
                F.Text = F_.ToString();
                tch.Text = Tch_.ToString();
                Omax.Text = Omax_.ToString();
                Ou.Text = Ou_.ToString();
                Op.Text = Op_.ToString();
                Cu.Text = Cu_.ToString();
                Cp.Text = Cp_.ToString();
                F.Text = F_.ToString();

                AddData(Ox, OTch_, Oo_, Eu, 6, B_, Omax_, Cp_, Cu_, A_, Math.Abs(A_ - B_), 
                    On, Tch_0, ich_, u_, NTch_0, D1_, d_, b1_, z_);
                
            }
            else
            {
                this.label26.Visible = true;
            }
        }
        public void AddData(double Ox, double OTch_, double Oo_, double Eu, double m, double B_, double Omax_, 
                    double Cp_, double Cu_, double A, double delta,
                    double On, double Tch_0, double ich_, double u_, double NTch_0, double D1_, double d_, 
                    double b1_, double z_)
        {
            string connectionString = "Data Source=C:\\Users\\79636\\Documents\\учеба\\БД\\DB.db;Version=3;"; // Путь к фалу .db

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Вставка в таблицу "Сборочная единица"
                        string insertAssembly = "INSERT INTO Unit (Ox, Otch, Eu, m, B, Omax, Cp, Cu, A, delta) VALUES (@Ox, @Otch, @Eu, @m, @B, @Omax, @Cp, @Cu, @A, @delta); SELECT last_insert_rowid();";
                        long assemblyId;
                        using (SQLiteCommand cmd = new SQLiteCommand(insertAssembly, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ox", Ox);
                            cmd.Parameters.AddWithValue("@Otch", OTch_);
                            cmd.Parameters.AddWithValue("@Oo", Oo_);
                            cmd.Parameters.AddWithValue("@Eu", Eu);
                            cmd.Parameters.AddWithValue("@m", m);
                            cmd.Parameters.AddWithValue("@B", B_);
                            cmd.Parameters.AddWithValue("@Omax", Omax_);
                            cmd.Parameters.AddWithValue("@Cp", Cp_);
                            cmd.Parameters.AddWithValue("@Cu", Cu_);
                            cmd.Parameters.AddWithValue("@A", A);
                            cmd.Parameters.AddWithValue("@delta", delta);

                            assemblyId = (long)cmd.ExecuteScalar();
                        }

                        // Вставка в таблицу "Деталь"
                        string insertDetail = "INSERT INTO detail (On, Tch0, Omax, ich, U, Nts0, D1, b, d, Zsh, id) VALUES (@On, @Tch0, @Omax, @ich, @U, @Nts0, @D1, @b, @d, @Zsh, @id)";
                        using (SQLiteCommand cmd = new SQLiteCommand(insertDetail, conn))
                        {
                            cmd.Parameters.AddWithValue("@On", On);
                            cmd.Parameters.AddWithValue("@Tch0", Tch_0);
                            cmd.Parameters.AddWithValue("@Omax", Omax_);
                            cmd.Parameters.AddWithValue("@ich", ich_);
                            cmd.Parameters.AddWithValue("@U", u_);
                            cmd.Parameters.AddWithValue("@Nts0", NTch_0);
                            cmd.Parameters.AddWithValue("@D1", D1_);
                            cmd.Parameters.AddWithValue("@b", b1_);
                            cmd.Parameters.AddWithValue("@d", d_);
                            cmd.Parameters.AddWithValue("@Zsh", z_);
                            cmd.Parameters.AddWithValue("@id", assemblyId);
                            cmd.ExecuteNonQuery();
                        }

                        // Завершаем транзакцию
                        transaction.Commit();
                        Console.WriteLine("Данные успешно добавлены в две таблицы.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Ошибка при добавлении данных: {ex.Message}");
                    }
                }

                conn.Close();
            }
        }

        private static readonly Random random = new Random();
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                                         .Select(s => s[random.Next(s.Length)])
                                         .ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
