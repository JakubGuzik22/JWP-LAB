using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4___zadanie_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOblicz_Click(object sender, RoutedEventArgs e)
        {
            double w, h, P, O;
            DaneWejściowe okno1 = new DaneWejściowe();
            okno1.ShowDialog();
            w = Convert.ToDouble(okno1.Szerokość);
            h = Convert.ToDouble(okno1.Wysokość);
            P = w * h;
            O = 2*w + 2*h;

            DaneWyjściowe okno2 = new DaneWyjściowe(P,O);
            okno2.ShowDialog();
        }

        private void btnKula_Click(object sender, RoutedEventArgs e)
        {
            Kula kula = new Kula("Kula", 50, 20, 5);
            lblWyniki.Content = kula.ToString();
        }

        private void btnStożek_Click(object sender, RoutedEventArgs e)
        {
            Stożek stozek = new Stożek("Stożek", 10, 10, 3, 7);
            lblWyniki.Content = stozek.ToString();
        }
    }
}