using System.Globalization;
using System.Windows.Controls;
using System.Windows;
using System;

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

            {
                try
                {
                    if (muvelet == "n!")
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

            double eredmeny1 = 1;

            for (int i = 1; i <= (int)a; i++)
            {
                eredmeny1 *= i;
            }

            tb_szamolo.Text = $"{a}! = {eredmeny1}";
        }

        private void Gyokvonas(double a)
        {
            if (a < 0)
            {
                tb_szamolo.Text = "Nem lehet negatív szám gyöke.";
                return;
            }
            tb_szamolo.Text = $"√{a} = {Math.Round(Math.Sqrt(a), 4)}";
        }

        private void Hatvanyozas(double a, double b)
        {
            tb_szamolo.Text = $"{a} ^ {b} = {Math.Round(Math.Pow(a, b), 4)}";
        }

        private void Osztas(double a, double b)
        {
            if (b == 0)
            {
                tb_szamolo.Text = "Nullával nem lehet osztani.";
            }
            else
            {
                tb_szamolo.Text = $"{a} / {b} = {Math.Round(a / b, 4)}";
            }
        }

        private void Szorzas(double a, double b)
        {
            tb_szamolo.Text = $"{a} * {b} = {a * b}";
        }

        private void Kivonas(double a, double b)
        {
            tb_szamolo.Text = $"{a} - {b} = {a - b}";
        }

        private void Osszeadas(double a, double b)
        {
            tb_szamolo.Text = $"{a} + {b} = {a + b}";
        }
    }
}