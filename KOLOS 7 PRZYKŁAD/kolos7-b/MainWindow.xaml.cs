using System.IO;
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

namespace kolos7_b;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnAnalizuj_Click(object sender, RoutedEventArgs e)
    {
        string filePath = "dane_temperatury.txt";

        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);

            List<double> temperatures = new List<double>();
            foreach (var line in lines)
            {
                if (double.TryParse(line, out double temperature))
                {
                    temperatures.Add(temperature);
                }
            }

            if (temperatures.Count > 0)
            {
                double average = temperatures.Average();
                double maxTemperature = temperatures.Max();

                txtŚrednia.Text = average.ToString("F2");
                txtMax.Text = maxTemperature.ToString("F2");
            }
            else
            {
                MessageBox.Show("Plik zawiera niepoprawne dane.");
            }
        }
        else
        {
            MessageBox.Show("Plik dane_temperatury.txt nie istnieje.");
        }
    }
}