using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kol7A;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
    public class Samochód
{
    public string Marka {  get; set; }
    public string Model {  get; set; }
    public string RokProdukcji {  get; set; }
    public decimal Cena {  get; set; }
}
public partial class MainWindow : Window
{
    private List<Samochód> samochody;
    public MainWindow()
    {
        InitializeComponent();
        samochody = new List<Samochód>
            {
                new Samochód { Marka = "Toyota", Model = "Corolla", RokProdukcji = "2018", Cena = 55000 },
                new Samochód { Marka = "Ford", Model = "Focus", RokProdukcji = "2017", Cena = 48000 },
                new Samochód { Marka = "BMW", Model = "X5", RokProdukcji = "2020", Cena = 135000 }
            };
    }
    private void btnZapisz_Click(object sender, RoutedEventArgs e)
    {
        string json = JsonSerializer.Serialize(samochody, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("samochody.json", json);
        MessageBox.Show("Dane zapisane do samochody.json", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}