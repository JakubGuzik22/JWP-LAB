using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab4___zadanie_1
{
    /// <summary>
    /// Logika interakcji dla klasy DaneWyjściowe.xaml
    /// </summary>
    public partial class DaneWyjściowe : Window
    {

        public DaneWyjściowe()
        {
            InitializeComponent();
        }

        public DaneWyjściowe(double P, double O):this()
        {
            this.tbkPole.Text = $"Pole: {P:F2}";
            this.tbkObwód.Text = $"Obwód: {O:F2}";
        }

        private void btnOkej_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
