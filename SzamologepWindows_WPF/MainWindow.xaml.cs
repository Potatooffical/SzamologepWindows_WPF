using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SzamologepWindows_WPF
{
    public partial class MainWindow : Window
    {
        private double elsoSzam = 0;
        private string muvelet = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            Button gomb = sender as Button;
            string tartalom = gomb.Content.ToString();

            if (double.TryParse(tartalom, out double szam))
            {
                tb_szamolo.Text += tartalom;
            }
            else
            {
                if (double.TryParse(tb_szamolo.Text, out double szamBeirt))
                {
                    elsoSzam = szamBeirt;
                    muvelet = tartalom;
                    tb_szamolo.Text = "";
                }
                else
                {
                    tb_szamolo.Text = "Hibás bemenet!";
                }
            }
        }

        private void Btn_Egyenloseg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (muvelet == "pi")
                {
                    Piszamitas(elsoSzam);
                }
                else if (muvelet == "n!")
                {
                    Faktorialis(elsoSzam);
                }
                else if (muvelet == "√")
                {
                    Gyokvonas(elsoSzam);
                }
                else
                {
                    if (!double.TryParse(tb_szamolo.Text, out double masodikSzam))
                    {
                        tb_szamolo.Text = "Hibás bemenet!";
                        return;
                    }

                    switch (muvelet)
                    {
                        case "+":
                            Osszeadas(elsoSzam, masodikSzam);
                            break;
                        case "-":
                            Kivonas(elsoSzam, masodikSzam);
                            break;
                        case "*":
                            Szorzas(elsoSzam, masodikSzam);
                            break;
                        case "/":
                            Osztas(elsoSzam, masodikSzam);
                            break;
                        case "^":
                            Hatvanyozas(elsoSzam, masodikSzam);
                            break;
                        case "%":
                            Szazalekszamitas(elsoSzam, masodikSzam);
                            break;
                        default:
                            tb_szamolo.Text = "Ismeretlen művelet.";
                            break;
                    }
                }
            }
            catch
            {
                tb_szamolo.Text = "Hibás bemenet!";
            }
        }

        private void Piszamitas(double a)
        {
            double eredmeny = Math.PI * a;
            tb_szamolo.Text = $"pi * {a} = {eredmeny}";
        }

        private void Szazalekszamitas(double a, double b)
        {
            double eredmeny = a * (b / 100);
            tb_szamolo.Text = $"{b}% of {a} = {eredmeny}";
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            tb_szamolo.Text = "";
            elsoSzam = 0;
            muvelet = "";
        }

        private void Faktorialis(double a)
        {
            if (a < 0 || a != Math.Floor(a))
            {
                tb_szamolo.Text = "Faktoriális csak nemnegatív egészre!";
                return;
            }

            double eredmeny = 1;
            for (int i = 1; i <= (int)a; i++)
            {
                eredmeny *= i;
            }

            tb_szamolo.Text = $"{a}! = {eredmeny}";
            
        }

        private void Gyokvonas(double a)
        {
            if (a < 0)
            {
                tb_szamolo.Text = "Nem lehet negatív szám gyöke.";
                return;
            }
            double eredmeny = Math.Round(Math.Sqrt(a), 4);
            tb_szamolo.Text = $"√{a} = {eredmeny}";
            
        }

        private void Hatvanyozas(double a, double b)
        {
            double eredmeny = Math.Round(Math.Pow(a, b), 4);
            tb_szamolo.Text = $"{a} ^ {b} = {eredmeny}";
            
        }

        private void Osztas(double a, double b)
        {
            if (b == 0)
            {
                tb_szamolo.Text = "Nullával nem lehet osztani.";
                return;
            }
            double eredmeny = Math.Round(a / b, 4);
            tb_szamolo.Text = $"{a} / {b} = {eredmeny}";
            
        }

        private void Szorzas(double a, double b)
        {
            double eredmeny = a * b;
            tb_szamolo.Text = $"{a} * {b} = {eredmeny}";
            
        }

        private void Kivonas(double a, double b)
        {
            double eredmeny = a - b;
            tb_szamolo.Text = $"{a} - {b} = {eredmeny}";
            
        }

        private void Osszeadas(double a, double b)
        {
            double eredmeny = a + b;
            tb_szamolo.Text = $"{a} + {b} = {eredmeny}";
            
        }

        private void Vesszo_Click(object sender, RoutedEventArgs e)
        {
            if (!tb_szamolo.Text.Contains(","))
            {
                tb_szamolo.Text += ",";
            }
        }
        private void tb_szamolo_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;

            
            if (e.Text == "," || e.Text == ".")
            {
                if (tb.Text.Contains(",") || tb.Text.Contains("."))
                {
                    e.Handled = true; 
                }
                else
                {
                    e.Handled = false;
                }
            }
            else if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void Bugreport_Click(object sender, RoutedEventArgs e)
        {
            Report about = new Report();
            about.Owner = this;
            about.ShowDialog();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutProgram about = new AboutProgram();
            about.Owner = this;
            about.ShowDialog();
        }
    }
}
