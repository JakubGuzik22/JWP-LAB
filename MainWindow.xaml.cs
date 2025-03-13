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

namespace lab2_b
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

        public double Potęguj(double wykładnik, double potęga)
        {
            if (potęga == 0)
            {
                return Potęguj(wykładnik, potęga - 1) * wykładnik;
            }
            return 0;
        }

        private void btnPotęguj_Click(object sender, RoutedEventArgs e)
        {
            double wykładnik = 0, potęga = 0;


            if (!double.TryParse(txtWykładnik.Text, out wykładnik) || wykładnik <= 0)
            {
                MessageBox.Show("Błąd: Wykładnik musi być liczbą dodatnią.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(txtPotęga.Text, out potęga) || potęga <= 0)
            {
                MessageBox.Show("Błąd: Potęga musi być liczbą dodatnią.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            lblWynik.Content = $"Potęga wynosi: {Potęguj(wykładnik, potęga):F2}";
        }
    }
}