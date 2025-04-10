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
    /// Logika interakcji dla klasy DaneWejściowe.xaml
    /// </summary>
    public partial class DaneWejściowe : Window
    {
        public double Szerokość { get { return Convert.ToDouble(txtSzerokość.Text); } }
        // public double Wysokość { get => Convert.ToDouble(txtSzerokość.Text); }
        public double Wysokość => Convert.ToDouble(txtSzerokość.Text);
        public DaneWejściowe()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
