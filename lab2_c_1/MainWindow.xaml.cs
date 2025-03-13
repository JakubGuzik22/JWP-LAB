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

namespace lab2_c
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

        private void Prostokąt(double szerokość, double wysokość, out double pole, out double obwód, out double przekątna)
        {
            pole = szerokość * wysokość;
            obwód = 2 * (szerokość + wysokość);
            przekątna = Math.Sqrt(Math.Pow(szerokość,2) + Math.Pow(wysokość, 2));
        }

        private void btnTest3_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtSzerokość.Text, out double szerokość) &&
               double.TryParse(txtWysokość.Text, out double wysokość))
            {
                Prostokąt(szerokość, wysokość, out double pole, out double obwód, out double przekątna);

                string wynik = $"Pole: {pole:F2}\nObwód: {obwód:F2}\nPrzekątna: {przekątna:F2}";
                MessageBox.Show(wynik, "Wyniki", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne liczby!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}