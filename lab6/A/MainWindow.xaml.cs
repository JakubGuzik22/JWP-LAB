using System.Reflection.Emit;
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

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public static class Optymalizacja
    {
        public static (double x, double y, double f)
       ZnajdźMinimumFunkcji2D(
       double minX, double maxX, double minY, double maxY,
       long liczbaIteracji, Func<double, double, double> f)
        {
            double? minF = null;
            double? minXPos = null, minYPos = null;

            Random rand = new();

            for (long i = 0; i < liczbaIteracji; i++)
            {
                double x = rand.NextDouble() * (maxX - minX) + minX;
                double y = rand.NextDouble() * (maxY - minY) + minY;

                double fValue = f(x, y);

                if (minF == null || fValue < minF)
                {
                    minF = fValue;
                    minXPos = x;
                    minYPos = y;
                }
            }

            return (minXPos ?? 0, minYPos ?? 0, minF ?? double.MaxValue);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFunkcja1_Click(object sender, RoutedEventArgs e)
        {
            Func<double, double, double> FunkcjaRosenbrocka = (x, y) =>
            {
                return Math.Pow(1 - x, 2) + 100 * Math.Pow(y - x * x, 2);
            };

            var wynik = Optymalizacja.ZnajdźMinimumFunkcji2D(-5, 5, -5, 5, 1000000L, FunkcjaRosenbrocka);

            lblWynikFunkcji1.Content = $"Położenie minimum (x): {wynik.x:F2} \nPołożenie minimum (y): {wynik.y:F2} \nWartość funkcji w tym punkcie: {wynik.f:F2}";
        }

        private void btnFunkcja2_Click(object sender, RoutedEventArgs e)
        {
            Func<double, double, double> Funkcja2 = (x, y) =>
            {
                return Math.Pow(x - 4, 2) + Math.Pow(y + 2, 2);
            };

            var wynik2 = Optymalizacja.ZnajdźMinimumFunkcji2D(-5, 5, -5, 5, 1000000L, Funkcja2);

            lblWynikFunkcji2.Content = $"Położenie minimum (x): {wynik2.x:F2} \nPołożenie minimum (y): {wynik2.y:F2} \nWartość funkcji w tym punkcie: {wynik2.f:F2}";
        }

        private void btnFunckja3_Click(object sender, RoutedEventArgs e)
        {
            Func<double, double, double> Funkcja3 = (x, y) =>
            {
                if (x > -1 && x < 1 && y > -2 && y < 2)
                {
                    return 2 + Math.Pow(y, 2);
                }
                else
                    return 100;
            };

            var wynik3 = Optymalizacja.ZnajdźMinimumFunkcji2D(-5, 5, -5, 5, 1000000L, Funkcja3);

            lblWynikFunkcji3.Content = $"Położenie minimum (x): {wynik3.x:F2} \nPołożenie minimum (y): {wynik3.y:F2} \nWartość funkcji w tym punkcie: {wynik3.f:F2}";
        }
    }
}