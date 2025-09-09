    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SzamologepWindows_WPF
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }
        private void btn_leadgomb_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbx_email.Text))
            {
                MessageBox.Show("Please write an email address.");
                tbx_email.Clear();
                return;
            }

            string inputEmail = tbx_email.Text.Trim();
            string pattern = @"^[\w\.-]+@[\w\.-]+\.\w{2,}$";

            Match match = Regex.Match(inputEmail, pattern);

            if (!match.Success)
            {
                MessageBox.Show("Invalid email format. Please check it.");
            }
            else
            {
                MessageBox.Show("Thank you for the email, I will answer in 10,000 years later!");
            }
        }
    }
}
