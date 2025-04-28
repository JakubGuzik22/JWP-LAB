using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = "C:/Users/Student/Desktop/guzik/lab7-2/WpfApp1/dane.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCzytaj_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik dane.txt nie istnieje!");
                return;
            }

            var numbers = new List<double>();

            try
            {
                var lines = File.ReadLines(filePath);
                if (!lines.Any())
                {
                    MessageBox.Show("Plik jest pusty.");
                    return;
                }

                foreach (var line in lines)
                {
                    if (double.TryParse(line, out var number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine($"Niepoprawna linia: {line}");
                    }
                }

                if (numbers.Count == 0)
                {
                    MessageBox.Show("Brak prawidłowych liczb w pliku.");
                    return;
                }

                lbxWynik.ItemsSource = numbers.Select(n => n.ToString("F3")).ToList();

                var average = numbers.Average();
                var max = numbers.Max();
                var min = numbers.Min();

                lblŚrednia.Content = $"Średnia: {average:F3}";
                lblNajwiększa.Content = $"Największa: {max:F3}";
                lblNajmniejsza.Content = $"Najmniejsza: {min:F3}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }
        }
}